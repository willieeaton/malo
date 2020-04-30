using System;
using System.Collections.Generic;
using System.Text;

namespace malo.Models
{
    public class PwadTag
    {
        // Many-to-Many mapping table.  A PWAD can have any number of Tags; a Tag can be used among any number of PWADs.

        public int PwadId { get; set; }
        public Pwad Pwad { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
