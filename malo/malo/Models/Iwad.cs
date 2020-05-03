using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace malo.Models
{
    public class Iwad : GameFile
    {
        // The Doom engine (IDTech1) contains the code to run the game, but the actual assets are contained in "WAD" files.
        // Short for "Where's All the Data", WAD files contain the graphics, audio, level design, etc.

        // An IWAD, short for "Internal WAD", and referred to in this launcher as the "Game", contains the specific assets
        // found in the base game itself.  Some of them are commercial products, some are shareware, and some have been
        // released separately as free and/or open-source projects.  The Doom engine cannot run without at least some form
        // of IWAD.  

        public string VersionName { get; set; }
        public bool IsConfigured { get; set; }
        public string DescriptiveName { get; set; }

        static public string LookupIwadByFilename(string filename)
        {
            //This is just a test/placeholder for the actual database-lookup-based function that will go here later.
            if(filename == "doom.wad")
            {
                return "Ultimate Doom";
            }
            else if(filename == "doom1.wad")
            {
                return "Shareware Doom";
            }
            else if(filename == "doom2.wad")
            {
                return "Doom II";
            }
            else if(filename == "heretic.wad")
            {
                return "Heretic";
            }
            else if(filename == "hexen.wad")
            {
                return "Hexen";
            }
            return "";
        }
    }
}
