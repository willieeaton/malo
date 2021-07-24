using malo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace malo.Data
{
    public class EstablishDummyData
    {
        public EstablishDummyData()
        {

            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            string databaseLocation = "Data Source=";
            databaseLocation += System.AppDomain.CurrentDomain.BaseDirectory;
            databaseLocation += "malo.db";
            Debug.WriteLine(databaseLocation);
            optionsBuilder.UseSqlite(databaseLocation);
            using (Context context = new Context(optionsBuilder.Options))
            {
                //test data goes here

                Pwad scythe = new Pwad
                {
                    FileName = "scythe.zip",
                    Name = "Scythe",
                    Description = "Scythe by Erik Alm",
                    FileLocation = "C:\\DOOM\\scythe.wad",
                    IsALevelPack = true,
                    IsAMod = false
                };
                context.Pwads.Add(scythe);
                Pwad tenSector = new Pwad
                {
                    FileName = "10sector.zip",
                    Name = "10 Sectors",
                    Description = "Ten Sectors",
                    FileLocation = "C:\\DOOM\\10sector.zip",
                    IsALevelPack = true,
                    IsAMod = false
                };
                context.Pwads.Add(tenSector);

                Iwad doom2Iwad = new Iwad
                {
                    FileName = "doom2.wad",
                    Name = "Doom II",
                    DescriptiveName = "Doom II v1.9",
                    FileLocation = "C:\\DOOM\\doom2.wad"
                };
                context.Iwads.Add(doom2Iwad);

                SourcePort crispyDoom = new SourcePort
                {
                    FileName = "crispy-doom.exe",
                    Name = "Crispy Doom",
                    FileLocation = "C:\\DOOM\\crispy-doom.exe",
                    ConfigFileLocation = "C:\\DOOM\\crispy-doom.cfg",
                    HasCompLevel = false,
                    MaximumCompatibility = Compatibility.LimitRemoving
                };
                context.SourcePorts.Add(crispyDoom);

                context.SaveChanges();

                var readwad = context.Pwads.ToList();
                foreach (Pwad p in readwad)
                {
                    Debug.WriteLine($"PWAD PK ID number {p.Id}");
                    Debug.WriteLine($"Name: {p.Name}");
                    Debug.WriteLine($"Description: {p.Description}");
                    Debug.WriteLine("---");
                }

                new CommandLine(crispyDoom, doom2Iwad, new List<Pwad> { scythe }, "");
            }
        }
    }
}
