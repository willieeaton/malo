using System;
using System.Collections.Generic;
using System.Text;

namespace malo.Models
{
    public enum Compatibility
    {
        Vanilla,
        LimitRemoving,
        BoomCompatible,
        ZDoomCompatible
    }

    public enum CompletionLevel
    {
        NotStarted,
        InProgress,
        Replaying,
        Abandoned,
        Completed
    }

    public class Pwad : GameFile
    {
        // The Doom engine (IDTech1) contains the code to run the game, but the actual assets are contained in "WAD" files.
        // Short for "Where's All the Data", WAD files contain the graphics, audio, level design, etc.

        // A PWAD, short for "Patch WAD", and referred to in this launcher as "Level Packs" and "Mods", are external 
        // WAD files, made by users, that add extra data to the game.  Most of them are either user-made levels, or gameplay
        // modifiers.  Some, also called "Total Conversions", are attempts to transform a Doom engine game into a new
        // experience entirely.  PWADs are not required to start the Doom engine, but are very popular among the classic
        // Doom community.

        public Pwad()
        {
            PwadTags = new List<PwadTag>();
        }

        public Compatibility? RequiredCompatibility { get; set; }
        public CompletionLevel? Completion { get; set; }
        public ICollection<PwadTag> PwadTags { get; set; } // many-to-many

        public bool IsAMod { get; set; }
        public bool IsALevelPack { get; set; }

    }
}
