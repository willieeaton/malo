using System;
using System.Collections.Generic;
using System.Text;

namespace malo.Models
{
    public class SourcePort : GameFile
    {
        public bool HasCompLevel { get; set; }
        public Compatibility? MaximumCompatibility { get; set; }
        public string VersionName { get; set; }
        public bool IsConfigured { get; set; }
        public string HomepageURL { get; set; }
        public bool IsUserAdded { get; set; }

    }

}
