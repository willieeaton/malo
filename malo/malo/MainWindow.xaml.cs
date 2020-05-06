using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using malo.Data;
using malo.Models;
using System.Diagnostics;


namespace malo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            //var dummyTable = new EstablishDummyData();
        }


        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshData();

            //new EstablishDummyData();
        }

        private void btnLaunch_Click(object sender, RoutedEventArgs e)
        {
            var sourcePortSelected = lbSourcePorts.SelectedItem.ToString();
            var sourcePort = Repository.FindSourcePortByName(sourcePortSelected);

            var iwadSelected = lbIwads.SelectedItem.ToString();
            var iwad = Repository.FindIwadByName(iwadSelected);

            var pwads = new List<Pwad>();

            foreach (var p in lbLevelPwads.SelectedItems)
            {
                var pwadSelected = p.ToString();

                var pwadToAdd = Repository.FindPwadByName(pwadSelected);
                if (pwadToAdd.FileName != "MALOERROR")
                {
                    pwads.Add(pwadToAdd);
                }
                else
                {
                    // dialog box here about a missing file; still allow running the rest
                }

            }

            foreach (var p in lbModPwads.SelectedItems)
            {
                var pwadSelected = p.ToString();

                var pwadToAdd = Repository.FindPwadByName(pwadSelected);
                if (pwadToAdd.FileName != "MALOERROR")
                {
                    pwads.Add(pwadToAdd);
                }
                else
                {
                    // dialog box here about a missing file; still allow running the rest
                }

            }

            if (sourcePort.FileName == "MALOERROR" || iwad.FileName == "MALOERROR")
            {
                // dialog box here; fail to run
            }
            else
            {
                new CommandLine(sourcePort, iwad, pwads);
            }
        }

        private void btnAddFile_Click(object sender, RoutedEventArgs e)
        {
            AddFileWindow addFileWindow = new AddFileWindow();
            addFileWindow.Closed += AddFileWindowClosed; // adds an event for when the window closes
            addFileWindow.Show();
        }
        
        public void AddFileWindowClosed(object sender, System.EventArgs e)
        {
            RefreshData();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshData();

            //cbLevelPwadTags.SelectedIndex = 0;
            //cbModPwadTags.SelectedIndex = 0;
        }

        public void RefreshData()
        {
            List<String> iwads = new List<String>();
            var iwadsInTable = Repository.GetIwads();
            foreach (var i in iwadsInTable)
            {
                iwads.Add(i.Name);
            }

            while (lbIwads.Items.Count > 0)
            {
                lbIwads.Items.RemoveAt(0);
            }

            foreach (var i in iwads)
            {
                lbIwads.Items.Add(i);
            }

            List<String> sourcePorts = new List<String>();
            var sourcePortsInTable = Repository.GetSourcePorts();
            foreach (var s in sourcePortsInTable)
            {
                sourcePorts.Add(s.Name);
            }

            while (lbSourcePorts.Items.Count > 0)
            {
                lbSourcePorts.Items.RemoveAt(0);
            }

            foreach (var s in sourcePorts)
            {
                lbSourcePorts.Items.Add(s);
            }

            List<String> levelPwads = new List<String>();
            var levelPwadsInTable = Repository.GetLevelPwads();
            foreach (var p in levelPwadsInTable)
            {
                levelPwads.Add(p.Name);
            }

            while (lbLevelPwads.Items.Count > 0)
            {
                lbLevelPwads.Items.RemoveAt(0);
            }

            foreach (var p in levelPwads)
            {
                lbLevelPwads.Items.Add(p);
            }

            List<String> modPwads = new List<String>();
            var modPwadsInTable = Repository.GetModPwads();
            foreach (var p in modPwadsInTable)
            {
                modPwads.Add(p.Name);
            }

            while (lbModPwads.Items.Count > 0)
            {
                lbModPwads.Items.RemoveAt(0);
            }

            foreach (var p in modPwads)
            {
                lbModPwads.Items.Add(p);
            }

            List<String> tags = new List<String>();
            var tagsInTable = Repository.GetTags();

            while (cbLevelPwadTags.Items.Count > 0)
            {
                cbLevelPwadTags.Items.RemoveAt(0);
            }

            while (cbModPwadTags.Items.Count > 0)
            {
                cbModPwadTags.Items.RemoveAt(0);
            }

            cbLevelPwadTags.Items.Add("Click here to filter by user-defined tags");
            cbModPwadTags.Items.Add("Click here to filter by user-defined tags");

            if(tagsInTable.Any())
            {
                foreach(Tag t in tagsInTable)
                {
                    cbLevelPwadTags.Items.Add(t.Name);
                    cbModPwadTags.Items.Add(t.Name);
                }
            }
            else
            {
                cbLevelPwadTags.Items.Add("No tags found");
                cbModPwadTags.Items.Add("No tags found");
            }

        }

        private void btnModifyFile_Click(object sender, RoutedEventArgs e)
        {
            ModifyFileWindow modifyFileWindow = new ModifyFileWindow();
            modifyFileWindow.Closed += ModifyFileWindowClosed; // adds an event for when the window closes
            modifyFileWindow.Show();
        }

        public void ModifyFileWindowClosed(object sender, System.EventArgs e)
        {
            RefreshData();
        }

        private void cbLevelPwadTags_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //RefreshData();
            if (cbLevelPwadTags.SelectedIndex == -1)
            {
                return;
            }
            List<String> levelPwads = new List<String>();
            var levelPwadsInTable = Repository.GetLevelPwads();
            if (cbLevelPwadTags.SelectedIndex == 0)
            {
                return;
            }
            else if (cbLevelPwadTags.SelectedItem.ToString() == "No tags found")
            {
                return;
            }
            var tagSelected = cbLevelPwadTags.SelectedItem.ToString();
            foreach (var p in levelPwadsInTable)
            {
                if (Repository.CheckPwadForTag(p, new Tag() { Name = cbLevelPwadTags.SelectedItem.ToString() }))
                {
                    levelPwads.Add(p.Name);
                }
            }

            while (lbLevelPwads.Items.Count > 0)
            {
                lbLevelPwads.Items.RemoveAt(0);
            }

            foreach (var p in levelPwads)
            {
                lbLevelPwads.Items.Add(p);
            }
        }

        private void cbModPwadTags_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //RefreshData();
            if (cbModPwadTags.SelectedIndex == -1)
            {
                return;
            }
            List<String> modPwads = new List<String>();
            var modPwadsInTable = Repository.GetModPwads();
            if (cbModPwadTags.SelectedIndex == 0)
            {
                return;
            }
            else if (cbModPwadTags.SelectedItem.ToString() == "No tags found")
            {
                return;
            }
            var tagSelected = cbModPwadTags.SelectedItem.ToString();
            foreach (var p in modPwadsInTable)
            {
                if (Repository.CheckPwadForTag(p, new Tag() { Name = cbModPwadTags.SelectedItem.ToString() }))
                {
                    modPwads.Add(p.Name);
                }
            }

            while (lbModPwads.Items.Count > 0)
            {
                lbModPwads.Items.RemoveAt(0);
            }

            foreach (var p in modPwads)
            {
                lbModPwads.Items.Add(p);
            }
        }

    }
}

