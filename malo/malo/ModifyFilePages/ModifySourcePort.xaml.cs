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
    /// Interaction logic for ModifySourcePort.xaml
    /// </summary>
    public partial class ModifySourcePort : Page
    {
        static SourcePort sourcePortInProgress = new SourcePort();
        public ModifySourcePort(SourcePort sourcePort) 
        {
            InitializeComponent();

            sourcePortInProgress = sourcePort;
        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
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

            if (CheckValidity())
            {
                if (Repository.ModifySourcePort(sourcePortInProgress))
                {
                    MessageBox.Show($"{sourcePortInProgress.Name} successfully modified.", "Success!");

                    Window.GetWindow(this).Close();
                }

                else
                {
                    MessageBox.Show($"Unable to update file", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public bool CheckValidity()
        {
            return true;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            if (CheckValidity())
            {
                foreach (var a in Enum.GetNames(typeof(Compatibility)))
                {
                    cbCompatibility.Items.Add(a);
                }
                
                if(sourcePortInProgress.MaximumCompatibility == null)
                {
                    cbCompatibility.SelectedIndex = 0;
                }
                else
                {
                    cbCompatibility.SelectedIndex = (int)sourcePortInProgress.MaximumCompatibility + 1;
                }    

                tbFileLocation.Text = sourcePortInProgress.FileFolder;
                sourcePortInProgress.FileName = sourcePortInProgress.FileLocation.Substring(sourcePortInProgress.FileFolder.Length);
                tbFileName.Text = sourcePortInProgress.FileName;
                tbSourcePortName.Text = sourcePortInProgress.Name;
            }
        }

        private void btnDeleteFile_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Are you sure you want to delete {sourcePortInProgress.Name}?", "Delete File?", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                if (Repository.DeleteSourcePortByName(sourcePortInProgress))
                {
                    MessageBox.Show("File successfully deleted!", "Success!");

                    Window.GetWindow(this).Close();

                }

                else
                {
                    MessageBox.Show($"Unable to delete file", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
