using malo.Models;
using Microsoft.Win32;
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
    /// Interaction logic for SelectFileType.xaml
    /// </summary>
    public partial class SelectFileType : Page
    {
        public SelectFileType()
        {
            InitializeComponent();
        }


        private void btnIwad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "WAD files (*.wad)|*.wad|All files (*.*)|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };

            openFileDialog.ShowDialog();
        }

        private void btnPwad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "WAD and PK3 files (*.wad;*.pk3)|*.wad;*.pk3|All files (*.*)|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };

            if (openFileDialog.ShowDialog() == true)
            {
                NavigationService.Navigate(new PwadOptions(new Pwad()
                {
                    FileLocation = openFileDialog.FileName
                }));
            }
        }

        private void btnSourcePort_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Executable files (*.wad)|*.exe|All files (*.*)|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };

            openFileDialog.ShowDialog();
        }
    }
}
