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

            if (Pwads.Any())
            {
                command += " -file ";
                foreach (Pwad p in Pwads)
                {
                    command += "\"" + p.FileLocation + "\" ";
                }
                command = command.Remove(command.Length - 1);
                launchGame.Arguments += command;
            }
            Debug.WriteLine(launchGame.Arguments);
            Process.Start(launchGame);
        }

    }
}
