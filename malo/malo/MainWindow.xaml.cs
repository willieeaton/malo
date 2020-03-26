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

            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            string databaseLocation = "Data Source=";
            databaseLocation += System.AppDomain.CurrentDomain.BaseDirectory;
            databaseLocation += "malo.db";
            Debug.WriteLine(databaseLocation);
            optionsBuilder.UseSqlite(databaseLocation);
            using (Context context = new Context(optionsBuilder.Options))
            {
                //test adding some partial data

                //Pwad gamewad = new Pwad
                //    { Name = "Scythe", Description = "Testing Scythe"};
                //context.Pwads.Add(gamewad);
                //gamewad = new Pwad
                //{ Name = "Ancient Aliens", Description = "A 32-level megawad by Skillsaw" };
                //context.Pwads.Add(gamewad);

                context.SaveChanges();

                var readwad = context.Pwads.ToList();
                foreach (Pwad p in readwad)
                {
                    Debug.WriteLine($"PWAD PK ID number {p.Id}");
                    Debug.WriteLine($"Name: {p.Name}");
                    Debug.WriteLine($"Description: {p.Description}"); 
                    Debug.WriteLine("---");
                }
            }
        
        }
    }
}
