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
    public partial class ModifyPwad : Page
    {
        static Pwad pwadInProgress = new Pwad();

        public ModifyPwad(Pwad pwad)
        {
            InitializeComponent();

            pwadInProgress = pwad;
        }

        private void btnDeleteFile_Click(object sender, RoutedEventArgs e)
        {

                if (MessageBox.Show($"Are you sure you want to delete {pwadInProgress.Name}?", "Delete File?", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                {
                    if (Repository.DeletePwadByName(pwadInProgress))
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

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            pwadInProgress.Name = tbPwadName.Text;
            if (cbCompatibility.SelectedIndex == 0)
            {
                pwadInProgress.RequiredCompatibility = null;
            }    
            else
            {
                pwadInProgress.RequiredCompatibility = (Compatibility)cbCompatibility.SelectedIndex - 1; ;
            }
            pwadInProgress.IsAMod = (bool)chkIsAMod.IsChecked;
            pwadInProgress.IsALevelPack = (bool)chkIsALevelPack.IsChecked;

            if (CheckValidity())
            {
                if (Repository.ModifyPwad(pwadInProgress))
                {
                    MessageBox.Show($"{pwadInProgress.Name} successfully modified.", "Success!");

                    Window.GetWindow(this).Close();
                }

                else
                {
                    MessageBox.Show($"Unable to update file", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        private bool CheckValidity()
        {
            return true;
        }
        private void RefreshData()
        {
            if (CheckValidity())
            {
                foreach (var a in Enum.GetNames(typeof(Compatibility)))
                {
                    cbCompatibility.Items.Add(a);
                }

                if (pwadInProgress.RequiredCompatibility == null)
                {
                    cbCompatibility.SelectedIndex = 0;
                }
                else
                {
                    cbCompatibility.SelectedIndex = (int)pwadInProgress.RequiredCompatibility;
                }

                tbFileLocation.Text = pwadInProgress.FileFolder;
                pwadInProgress.FileName = pwadInProgress.FileLocation.Substring(pwadInProgress.FileFolder.Length);
                tbFileName.Text = pwadInProgress.FileName;
                tbPwadName.Text = pwadInProgress.Name;
                tbDescription.Text = pwadInProgress.Description;

                if(pwadInProgress.IsALevelPack)
                {
                    chkIsALevelPack.IsChecked = true;
                }

                if(pwadInProgress.IsAMod)
                {
                    chkIsAMod.IsChecked = true;
                }
            }
        }
    }
}
