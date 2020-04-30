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
    }
}
