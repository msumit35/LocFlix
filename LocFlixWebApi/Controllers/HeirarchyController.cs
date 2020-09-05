using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using LocFlixWebApi.Services.Interfaces;

namespace LocFlixWebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HeirarchyController : ApiController
    {
        private readonly IFileExplorerService _fileExplorerService;

        public HeirarchyController(IFileExplorerService fileExplorerService)
        {
            _fileExplorerService = fileExplorerService;
        }

        [HttpGet]
        [Route("api/Heirarchy")]
        public IHttpActionResult Get(string path = null)
        {
            var folders = _fileExplorerService.GetFolders(path);

            return Ok(folders);
        }

        [HttpGet]
        [Route("api/Heirarchy/SubFoldersAndFiles")]
        public IHttpActionResult GetSubFoldersAndFiles(string path = null)
        {
            var folders = _fileExplorerService.GetSubFoldersAndFiles(path);

            return Ok(folders);
        }

        [HttpGet]
        [Route("api/Heirarchy/Drives")]
        public IHttpActionResult GetDrives()
        {
            var drives = _fileExplorerService.GetDrives();

            return Ok(drives);
        }
    }
}
