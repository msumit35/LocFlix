using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocFlixWebApi.Models
{
    public class LocRootFolder
    {
        public LocRootFolder()
        {
            Folders = new List<LocFolder>();
            Files = new List<LocFile>();
        }

        public List<LocFolder> Folders { get; set; }
        public List<LocFile> Files { get; set; }
    }

    public class LocFolder
    {
        public string Name { get; set; }
        public string Path { get; set; }
    }

    public class LocFile
    {
        public string Name { get; set; }
        public string Path { get; set; }
    }
}