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
        public Pwad()
        {
            PwadTags = new List<PwadTag>();
        }

        public Compatibility? RequiredCompatibility { get; set; }
        public CompletionLevel? Completion { get; set; }
        public ICollection<PwadTag> PwadTags { get; set; } // many-to-many

    }
}
