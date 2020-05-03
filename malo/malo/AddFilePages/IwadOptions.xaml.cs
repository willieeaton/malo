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
    /// Interaction logic for IwadOptions.xaml
    /// </summary>
    public partial class IwadOptions : Page
    {
        static public Iwad iwadInProgress = new Iwad();

        public IwadOptions(Iwad iwad)
        {
            iwadInProgress = iwad;

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

        private bool CheckDuplicate() => Repository.CheckIfIwadExistsByFileLocation(iwadInProgress);
        private void btnAddWad_Click(object sender, RoutedEventArgs e)
        {
            iwadInProgress.Name = tbIwadName.Text;
            if (CheckIfWadReadyToAdd())
            {
                if (Repository.AddNewIwad(iwadInProgress))
                {
                    MessageBox.Show($"{iwadInProgress.Name} added to database.", "Success!");

                    Window.GetWindow(this).Close();
                }

                else
                {
                    MessageBox.Show($"{iwadInProgress.Name} was not able to be added.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private bool CheckIfWadReadyToAdd()
        {
            if (tbIwadName.Text.Length < 1)
            {
                MessageBox.Show("Unable to add file: Name cannot be blank.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                //file must have a unique name
            }
            else if (Repository.FindIwadByName(tbIwadName.Text).FileName != "MALOERROR")
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
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            if (CheckValidity())
            {
                tbFileLocation.Text = iwadInProgress.FileFolder;
                iwadInProgress.FileName = iwadInProgress.FileLocation.Substring(iwadInProgress.FileFolder.Length);
                tbFileName.Text = iwadInProgress.FileName;
                tbIwadName.Text = Iwad.LookupIwadByFilename(iwadInProgress.FileName);
            }
            else
            {
                //handle invalid file info
            }

        }
    }
}
