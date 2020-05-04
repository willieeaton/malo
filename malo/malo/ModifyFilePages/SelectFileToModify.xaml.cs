using malo.Data;
using malo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace malo.ModifyFilePages
{
    /// <summary>
    /// Interaction logic for SelectFileToModify.xaml
    /// </summary>
    public partial class SelectFileToModify : Page
    {
        public SelectFileToModify()
        {
            InitializeComponent();
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
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        private void btnModifySourcePort_Click(object sender, RoutedEventArgs e)
        {
            var sourcePort = Repository.FindSourcePortByName(lbSourcePorts.SelectedItem.ToString());

            var pwadOptions = new ModifySourcePort(sourcePort);

            NavigationService.Navigate(pwadOptions, sourcePort);

        }
    }
}
