using System;
using System.Collections.Generic;
using System.Text;

namespace malo.Models
{
    public class GameFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FileLocation { get; set; }
        public string FileName { get; set; }

        public string FileFolder
        {
            get => FileLocation.Substring(0, FileLocation.LastIndexOf('\\') + 1);
        }
    }
}
