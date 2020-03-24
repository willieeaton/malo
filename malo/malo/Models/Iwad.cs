using System;
using System.Collections.Generic;
using System.Text;

namespace malo.Models
{
    public class Iwad : GameFile
    {
        public string VersionName { get; set; }
        public bool IsConfigured { get; set; }
        public string DescriptiveName { get; set; }
    }
}
