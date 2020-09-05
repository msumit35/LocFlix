using LocFlixWebApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocFlixWebApi.Services.Interfaces
{
    public interface IFileExplorerService
    {
        LocRootFolder GetFolders(string path);

        LocRootFolder GetSubFoldersAndFiles(string path);

        IEnumerable<DriveInfo> GetDrives();
    }
}
