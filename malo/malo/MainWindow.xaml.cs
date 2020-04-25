using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using malo.Data;
using malo.Models;
using System.Diagnostics;


namespace malo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            var dummyTable = new EstablishDummyData();
        }

        private void btnLaunch_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //new CommandLine(sourcePort, iwad, pwads);
        }

        private void btnRefresh_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
