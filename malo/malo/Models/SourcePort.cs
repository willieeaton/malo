using System;
using System.Collections.Generic;
using System.Text;

namespace malo.Models
{
    public class SourcePort : GameFile
    {
        // Doom was released as open source in 1997 and re-licensed under the GPL in 1999.
        // The code was backported by the community into a program called "DOSDoom" which has been repeatedly
        // forked by various open source projects into a myriad of executables that add various features to DOOM;
        // these are referred to as "source ports".  In this launcher, they are referred to as "Executables".

        // Various source ports add various features to the game, which caused them to develop their own niches.
        // This is why many users in the community keep multiple executables.  For instance, a user might have
        // Chocolate Doom for an experience nearly identical to the original DOS game; Crispy Doom in order to
        // play the game with uncapped framerate and WAD limits removed; PRBoom+ to record speedrun demo files; and
        // GZDoom in order to play user-created levels that take advantage of its advanced scripting features,
        // dynamic lighting, and true 3D environments.


        public bool HasCompLevel { get; set; }
        public Compatibility? MaximumCompatibility { get; set; }
        // Doom source ports add various features to the game, therefore creating "tiers" of compatibility.
        // "Vanilla" PWADs can run on any source port, "limit-removing" PWADs require a port without certain file limitations,
        // "BOOM-", "MBF-", and "ZDOOM-" compatible PWADs are an ascending set of levels that adds features inclusive and additional to 
        // the previous mentioned.

        // Therefore, a "ZDOOM-compatible" source port can run virtually all Doom Engine PWADs, whereas a "limit-removing" port can only
        // run "vanilla" and "limit-removing" PWADs.

        public string VersionName { get; set; }
        public bool IsConfigured { get; set; }
        public string HomepageURL { get; set; }
        public bool IsUserAdded { get; set; }
        public string ConfigFileLocation { get; set; }

    }

}
