using System;
using System.Collections.Generic;
using System.Text;

namespace malo.Models
{
    class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //public something Color { get; set; }

        //public something Pwad(s) { get; set; } // many-to-many
    }
}
