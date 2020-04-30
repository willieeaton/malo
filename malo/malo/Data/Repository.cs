using malo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;

namespace malo.Data
{
    static class Repository
    {
        // static class for general functions that access the database 

        static public List<Iwad> GetIwads()
        {
            var iwads = new List<Iwad>();
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            string databaseLocation = "Data Source=";
            databaseLocation += System.AppDomain.CurrentDomain.BaseDirectory;
            databaseLocation += "malo.db";
            optionsBuilder.UseSqlite(databaseLocation);
            using (Context context = new Context(optionsBuilder.Options))
            {
                iwads.AddRange(context.Iwads.ToList<Iwad>());
            }

            return iwads;
        }

        static public List<SourcePort> GetSourcePorts()
        {
            var sourcePorts = new List<SourcePort>();
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            string databaseLocation = "Data Source=";
            databaseLocation += System.AppDomain.CurrentDomain.BaseDirectory;
            databaseLocation += "malo.db";
            optionsBuilder.UseSqlite(databaseLocation);
            using (Context context = new Context(optionsBuilder.Options))
            {
                sourcePorts.AddRange(context.SourcePorts.ToList<SourcePort>());
            }

            return sourcePorts;
        }

        static public List<Pwad> GetLevelPwads()
        {
            var pwads = new List<Pwad>();
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            string databaseLocation = "Data Source=";
            databaseLocation += System.AppDomain.CurrentDomain.BaseDirectory;
            databaseLocation += "malo.db";
            optionsBuilder.UseSqlite(databaseLocation);
            using (Context context = new Context(optionsBuilder.Options))
            {
                pwads.AddRange(context.Pwads.ToList<Pwad>());
            }

            return pwads;
        }

        static public List<Pwad> GetModPwads()
        {
            var pwads = new List<Pwad>();
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            string databaseLocation = "Data Source=";
            databaseLocation += System.AppDomain.CurrentDomain.BaseDirectory;
            databaseLocation += "malo.db";
            optionsBuilder.UseSqlite(databaseLocation);
            using (Context context = new Context(optionsBuilder.Options))
            {
                pwads.AddRange(context.Pwads.ToList<Pwad>());
            }

            return pwads;
        }
    }
}
