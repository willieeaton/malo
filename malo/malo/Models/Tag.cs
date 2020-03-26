﻿using System;
using System.Collections.Generic;
using System.Text;

namespace malo.Models
{
    public class Tag
    {
        public Tag()
        {
            PwadTags = new List<PwadTag>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //public something Color { get; set; }

        public ICollection<PwadTag> PwadTags { get; set; } // many-to-many
    }
}
