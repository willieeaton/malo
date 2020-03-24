using System;
using System.Collections.Generic;
using System.Text;

namespace malo.Models
{
    public class Pwad : GameFile
    {
        public bool? RequiresLimitRemoving { get; set; }
        public bool? RequiresBoomSupport { get; set; }
        public bool? RequiresZDoomSupport { get; set; }

        public string Completion { get; set; }
        
        //public something Tags { get; set; } // many-to-many

    }
}
