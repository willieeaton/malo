using malo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace malo.Data
{
    public class CommandLine
    {
        // Fortunately, most Doom source ports execute from the command line using the same arguments.  This class builds a
        // command line command out of needed parameters and arguments.
        public SourcePort SourcePort { get; set; }
        public Iwad Iwad  { get; set; }
        public List<Pwad> Pwads { get; set; }
        private string command;

        public CommandLine(SourcePort sourcePort, Iwad iwad, List<Pwad> pwads)
        {
            SourcePort = sourcePort;
            Iwad = iwad;
            Pwads = pwads;
            var launchGame = new ProcessStartInfo();
            launchGame.WorkingDirectory = sourcePort.FileFolder;
            launchGame.FileName = sourcePort.FileLocation;
            launchGame.Arguments += "-iwad \"" + iwad.FileLocation + "\"";
            //if (!String.IsNullOrEmpty(sourcePort.ConfigFileLocation))
            //{
            //    launchGame.Arguments += " -config \"" + sourcePort.ConfigFileLocation + "\"";
            //}

            if (Pwads.Any()) // PWADs are optional.  If launched without PWADs, the command line doesn't need the -file argument.
            {
                command += " -file ";
                foreach (Pwad p in Pwads)
                {
                    command += "\"" + p.FileLocation + "\" "; // encloses file path and name in quotes
                }
                command = command.Remove(command.Length - 1); //just getting rid of that trailing space at the end
                launchGame.Arguments += command;
            }
            Debug.WriteLine(launchGame.Arguments);
            Process.Start(launchGame);
        }

    }
}
