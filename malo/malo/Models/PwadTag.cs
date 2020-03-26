using System;
using System.Collections.Generic;
using System.Text;

namespace malo.Models
{
    public class PwadTag
    {
        public int PwadId { get; set; }
        public Pwad Pwad { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
