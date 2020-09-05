using LocFlixWebApi.Models;
using LocFlixWebApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace LocFlixWebApi.Services
{
    public class FileExplorerService : IFileExplorerService
    {
        private string _rootPath = ConfigurationManager.AppSettings["RootPath"];
        private string[] _videoFormats = ConfigurationManager.AppSettings["VideoFormats"].Split(',');
        private LocRootFolder _heirarchy = new LocRootFolder();
        private string[] _ignoreFolders = ConfigurationManager.AppSettings["IgnoreFolders"].Split(',');

        public LocRootFolder GetFolders(string path)
        {
            path = string.IsNullOrEmpty(path) || path == "/" ? _rootPath : _rootPath + path;
            var folders = Directory.GetDirectories(path);
            var files = Directory.GetFiles(path);
            foreach (var folder in folders)
            {
                var relativePath = folder.Replace(_rootPath, string.Empty);
                var filename = Path.GetFileName(folder);

                if (!_ignoreFolders.Contains(filename))
                {
                    _heirarchy.LocFiles.Add(new LocFile
                    {
                        Name = filename,
                        Path = relativePath
                    });
                }
            }

            foreach (var file in files)
            {
                var ext = Path.GetExtension(file).Split('.')[1];
                if (_videoFormats.Contains(ext))
                {
                    var relativePath = file.Replace(_rootPath, string.Empty);
                    _heirarchy.LocFiles.Add(new LocFile
                    {
                        Name = Path.GetFileName(file),
                        Path = relativePath,
                        IsFile = true
                    });
                }
            }

            return _heirarchy;
        }

        public LocRootFolder GetSubFoldersAndFiles(string path)
        {
            var folders = Directory.GetDirectories(path);
            var files = Directory.GetFiles(path);
            foreach (var folderPath in folders)
            {
                var filename = Path.GetFileName(folderPath);
                if (!_ignoreFolders.Contains(filename))
                {
                    _heirarchy.LocFiles.Add(new LocFile
                    {
                        Name = filename,
                        Path = folderPath
                    });
                }
            }

            foreach (var filePath in files)
            {
                var ext = Path.GetExtension(filePath).Split('.')[1];
                if (_videoFormats.Contains(ext))
                {
                    _heirarchy.LocFiles.Add(new LocFile
                    {
                        Name = Path.GetFileName(filePath),
                        Path = filePath,
                        IsFile = true
                    });
                }
            }

            return _heirarchy;
        }

        public IEnumerable<DriveInfo> GetDrives()
        {
            var drives = DriveInfo.GetDrives();

            return drives;
        }
    }
}