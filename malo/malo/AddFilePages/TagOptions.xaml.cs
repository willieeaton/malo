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
    /// Interaction logic for TagOptions.xaml
    /// </summary>
    public partial class TagOptions : Page
    {
        static Tag tagInProgress = new Tag();
        public TagOptions(Tag tag)
        {
            tagInProgress = tag;

            InitializeComponent();
        }

        private void btnAddTag_Click(object sender, RoutedEventArgs e)
        {
            tagInProgress.Name = tbTagName.Text;
            tagInProgress.Description = tbDescription.Text;
            if (CheckValidity())
            {
                Repository.AddNewTag(tagInProgress);

                foreach (var i in lbPwadsWithTag.Items)
                {
                    var pwadToAddTag = new Pwad() { Name = i.ToString() };
                    Repository.AddTagToPwad(tagInProgress, pwadToAddTag);
                }

                Window.GetWindow(this).Close();

            }
            else
            {
                MessageBox.Show("Unable to add tag: Name not unique", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshData();
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

        private bool CheckDuplicate() => Repository.CheckIfTagExistsByName(tagInProgress);

        private void RefreshData()
        {
            tbTagName.Text = tagInProgress.Name;
            tbDescription.Text = tagInProgress.Description;

            List<Pwad> pwadsInTable = Repository.GetLevelPwads();
            pwadsInTable.AddRange(Repository.GetModPwads());

            List<String> pwadsWithoutTag = new List<String>();
            foreach (Pwad p in pwadsInTable)
            {
                pwadsWithoutTag.Add(p.Name);
            }

            while (lbPwadsWithoutTag.Items.Count > 0)
            {
                lbPwadsWithoutTag.Items.RemoveAt(0);
            }

            while (lbPwadsWithTag.Items.Count > 0)
            {
                lbPwadsWithTag.Items.RemoveAt(0);
            }

            foreach (var p in pwadsWithoutTag)
            {
                lbPwadsWithoutTag.Items.Add(p);
            }
            

        }

        private void btnRemoveTag_Click(object sender, RoutedEventArgs e)
        {
            var tagToMove = lbPwadsWithTag.SelectedItem.ToString();

            lbPwadsWithTag.Items.RemoveAt(lbPwadsWithTag.SelectedIndex);
            lbPwadsWithoutTag.Items.Add(tagToMove);
        }

        private void btnAddTagToFile_Click(object sender, RoutedEventArgs e)
        {
            var tagToMove = lbPwadsWithoutTag.SelectedItem.ToString();

            lbPwadsWithoutTag.Items.RemoveAt(lbPwadsWithoutTag.SelectedIndex);
            lbPwadsWithTag.Items.Add(tagToMove);
        }
    }
}
