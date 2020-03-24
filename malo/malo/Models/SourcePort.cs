using System;
using System.Collections.Generic;
using System.Text;

namespace malo.Models
{
    public class SourcePort : GameFile
    {
        public bool HasCompLevel { get; set; }
        public bool? IsLimitRemoving { get; set; }
        public bool? HasBoomSupport { get; set; }
        public bool? HasZDoomSupport { get; set; }
        public string VersionName { get; set; }
        public bool IsConfigured { get; set; }
        public string HomepageURL { get; set; }
        public bool IsUserAdded { get; set; }

    }

}
