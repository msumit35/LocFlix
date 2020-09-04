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
            LocFiles = new List<LocFile>();
        }

        public List<LocFile> LocFiles { get; set; }
    }

    public class LocFile
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public bool IsFile { get; set; }
    }
}