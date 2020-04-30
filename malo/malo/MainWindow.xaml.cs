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

            var dummyTable = new EstablishDummyData();
        }


        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            List<String> iwads = new List<String>();
            var iwadsInTable = Repository.GetIwads();
            foreach(var i in iwadsInTable)
            {
                iwads.Add(i.Name);
            }

            while(lbIwads.Items.Count > 0)
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
        }

        private void btnLaunch_Click(object sender, RoutedEventArgs e)
        {
            //new CommandLine(sourcePort, iwad, pwads);

        }

        private void btnAddFile_Click(object sender, RoutedEventArgs e)
        {
            AddFileWindow addFileWindow = new AddFileWindow();
            addFileWindow.Show();
        }
    }
}
