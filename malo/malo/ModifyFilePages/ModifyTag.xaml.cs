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
    /// Interaction logic for ModifyTag.xaml
    /// </summary>
    public partial class ModifyTag : Page
    {
        static Tag tagInProgress = new Tag();
        public ModifyTag(Tag tag)
        {
            tagInProgress = tag;
            InitializeComponent();
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
            if(CheckValidity())
            {
                tbTagName.Text = tagInProgress.Name;
                tbDescription.Text = tagInProgress.Description;

                List<Pwad> pwadsInTable = Repository.GetLevelPwads();
                pwadsInTable.AddRange(Repository.GetModPwads());

                List<String> pwadsWithTag = new List<String>();
                List<String> pwadsWithoutTag = new List<String>();

                foreach (Pwad p in pwadsInTable)
                {
                    if (Repository.CheckPwadForTag(p, tagInProgress))
                    {
                        pwadsWithTag.Add(p.Name);
                    }
                    else
                    {
                        pwadsWithoutTag.Add(p.Name);
                    }
                    
                }   
                
                while (lbPwadsWithoutTag.Items.Count > 0)
                {
                    lbPwadsWithoutTag.Items.RemoveAt(0);
                }

                while (lbPwadsWithTag.Items.Count > 0)
                {
                    lbPwadsWithTag.Items.RemoveAt(0);
                }

                foreach (var p in pwadsWithTag)
                {
                    lbPwadsWithTag.Items.Add(p);
                }

                foreach (var p in pwadsWithoutTag)
                {
                    lbPwadsWithoutTag.Items.Add(p);
                }
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

        private void btnDeleteTag_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show($"Are you sure you want to delete {tagInProgress.Name}?", "Delete File?", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                if (Repository.DeleteTagByName(tagInProgress))
                {
                    MessageBox.Show("Tag successfully deleted!", "Success!");

                    Window.GetWindow(this).Close();

                }

                else
                {
                    MessageBox.Show($"Unable to delete tag", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnAddTag_Click(object sender, RoutedEventArgs e)
        {
            tagInProgress.Description = tbDescription.Text;
            var tagPwads = new List<Pwad>();

            foreach(var i in lbPwadsWithTag.Items)
            {
                tagPwads.Add(new Pwad() { Name = i.ToString() });
            }
            if (CheckValidity())
            {
                if (Repository.ModifyTag(tagInProgress, tagPwads))
                {
                    MessageBox.Show($"{tagInProgress.Name} successfully modified.", "Success!");

                    Window.GetWindow(this).Close();
                }

                else
                {
                    MessageBox.Show($"Unable to update file", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
