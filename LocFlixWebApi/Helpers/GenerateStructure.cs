using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using LocFlixWebApi.Models;

namespace LocFlixWebApi.Helpers
{
    public class GenerateStructure
    {
        private string _rootPath = ConfigurationManager.AppSettings["RootPath"];
        private string[] _videoFormats = ConfigurationManager.AppSettings["VideoFormats"].Split(',');
        private LocRootFolder _heirarchy = new LocRootFolder();

        public LocRootFolder GetFolders(string path)
        {
            path = string.IsNullOrEmpty(path) || path == "/" ? _rootPath : _rootPath + path;
            var folders = Directory.GetDirectories(path);
            var files = Directory.GetFiles(path);
            foreach (var folder in folders)
            {
                var relativePath = folder.Replace(_rootPath, string.Empty);
                _heirarchy.Folders.Add( new LocFolder
                {
                    Name = Path.GetFileName(folder),
                    Path = relativePath
                });
            }

            foreach (var file in files)
            {
                var ext = Path.GetExtension(file).Split('.')[1];
                if (_videoFormats.Contains(ext))
                {
                    var relativePath = file.Replace(_rootPath, string.Empty);
                    _heirarchy.Files.Add(new LocFile
                    {
                        Name = Path.GetFileName(file),
                        Path = relativePath
                    });
                }
            }

            return _heirarchy;
        }
    }
}