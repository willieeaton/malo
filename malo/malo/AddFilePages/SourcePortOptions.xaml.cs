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

namespace malo.AddFilePages
{
    /// <summary>
    /// Interaction logic for SourcePortOptions.xaml
    /// </summary>
    public partial class SourcePortOptions : Page
    {
        static public SourcePort sourcePortInProgress;
        public SourcePortOptions(SourcePort sourcePort)
        {
            sourcePortInProgress = sourcePort;
            InitializeComponent();
        }

        private void btnAddSourcePort_Click(object sender, RoutedEventArgs e)
        {
            sourcePortInProgress.Name = tbSourcePortName.Text;
            if (cbCompatibility.SelectedIndex == 0)
            {
                sourcePortInProgress.MaximumCompatibility = null;
            }
            else
            {
                sourcePortInProgress.MaximumCompatibility = (Compatibility)cbCompatibility.SelectedIndex - 1;
            }

            if (CheckIfSourcePortReadyToAdd())
            {
                if (Repository.AddNewSourcePort(sourcePortInProgress))
                {
                    MessageBox.Show($"{sourcePortInProgress.Name} added to database.", "Success!");
                     
                    Window.GetWindow(this).Close();
                }

                else
                {
                    MessageBox.Show($"{sourcePortInProgress.Name} was not able to be added.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private bool CheckValidity()
        {
            if (!CheckDuplicate())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckDuplicate() => Repository.CheckIfSourcePortExistsByFileLocation(sourcePortInProgress);

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (CheckValidity())
            {
                foreach (var a in Enum.GetNames(typeof(Compatibility)))
                {
                    cbCompatibility.Items.Add(a);
                }
                cbCompatibility.SelectedIndex = 0;

                tbFileLocation.Text = sourcePortInProgress.FileFolder;
                sourcePortInProgress.FileName = sourcePortInProgress.FileLocation.Substring(sourcePortInProgress.FileFolder.Length);
                tbFileName.Text = sourcePortInProgress.FileName;
            }
            else
            {
                //handle invalid file info
            }
        }

        private bool CheckIfSourcePortReadyToAdd()
        {
            if(tbSourcePortName.Text.Length < 1)
            {
                MessageBox.Show("Unable to add file: Name cannot be blank.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                //file must have a unique name
            }
            else if (Repository.FindSourcePortByName(tbSourcePortName.Text).FileName != "MALOERROR")
            {
                MessageBox.Show("Unable to add file: An IWAD with this name already exists in the database!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                //file must have a unique name
            }
            else
            {
                return true;
            }
            return false;
        }
    }
}
