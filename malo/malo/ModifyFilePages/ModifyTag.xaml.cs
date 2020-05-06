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
    }
}
