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
using malo.Data;
using System.Diagnostics;

namespace malo.AddFilePages
{
    /// <summary>
    /// Interaction logic for PwadOptions.xaml
    /// </summary>
    public partial class PwadOptions : Page
    {
        static public Pwad pwadInProgress = new Pwad();
        public PwadOptions(Pwad pwad)
        {
            pwadInProgress = pwad;

            InitializeComponent();
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

        private bool CheckDuplicate() => Repository.CheckIfPwadExistsByFileLocation(pwadInProgress);

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            if (CheckValidity())
            {
                foreach (var a in Enum.GetNames(typeof(Compatibility)))
                {
                    cbCompatibility.Items.Add(a);
                }
                cbCompatibility.SelectedIndex = 0;

                tbFileLocation.Text = pwadInProgress.FileFolder;
                pwadInProgress.FileName = pwadInProgress.FileLocation.Substring(pwadInProgress.FileFolder.Length);
                tbFileName.Text = pwadInProgress.FileName;
            }
            else
            {
                //handle invalid file info
            }

        }

        private void btnAddWad_Click(object sender, RoutedEventArgs e)
        {
            pwadInProgress.Name = tbPwadName.Text;
            pwadInProgress.IsALevelPack = (bool)chkIsALevelPack.IsChecked; //casting nullable bool into bool
            pwadInProgress.IsAMod = (bool)chkIsAMod.IsChecked;
            if(cbCompatibility.SelectedIndex == 0)
            {
                pwadInProgress.RequiredCompatibility = null;
            }
            else
            {
                pwadInProgress.RequiredCompatibility = (Compatibility)cbCompatibility.SelectedIndex - 1;
            }
            pwadInProgress.Description = tbDescription.Text;

            if (CheckIfWadReadyToAdd())
            {
                if (Repository.AddNewPwad(pwadInProgress))
                {
                    MessageBox.Show($"{pwadInProgress.Name} added to database.", "Success!");

                    Window.GetWindow(this).Close();
                }

                else
                {
                    MessageBox.Show($"{pwadInProgress.Name} was not able to be added.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private bool CheckIfWadReadyToAdd()
        {
            if(tbPwadName.Text.Length < 1)
            {
                MessageBox.Show("Unable to add file: Name cannot be blank.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                //file must have a unique name
            }
            else if(chkIsALevelPack.IsChecked == false && chkIsALevelPack.IsChecked == false)
            {
                MessageBox.Show("Unable to add file: PWAD must contain some levels or be a mod!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                //file must contain levels or be a gameplay mod
            }
            else if(Repository.FindPwadByName(tbPwadName.Text).FileName != "MALOERROR")
            {
                MessageBox.Show("Unable to add file: A PWAD with this name already exists in the database!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
