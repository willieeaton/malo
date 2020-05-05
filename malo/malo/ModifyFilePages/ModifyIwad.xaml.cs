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
    /// Interaction logic for ModifyIwad.xaml
    /// </summary>
    public partial class ModifyIwad : Page
    {
        static Iwad iwadInProgress = new Iwad();
        public ModifyIwad(Iwad iwad)
        {
            InitializeComponent();

            iwadInProgress = iwad;
        }


        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            iwadInProgress.Name = tbIwadName.Text;

            if (CheckValidity())
            {
                if (Repository.ModifyIwad(iwadInProgress))
                {
                    MessageBox.Show($"{iwadInProgress.Name} successfully modified.", "Success!");

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
                tbFileLocation.Text = iwadInProgress.FileFolder;
                iwadInProgress.FileName = iwadInProgress.FileLocation.Substring(iwadInProgress.FileFolder.Length);
                tbFileName.Text = iwadInProgress.FileName;
                tbIwadName.Text = iwadInProgress.Name;
            }
        }

        private void btnDeleteFile_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Are you sure you want to delete {iwadInProgress.Name}?", "Delete File?", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                if (Repository.DeleteIwadByName(iwadInProgress))
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

