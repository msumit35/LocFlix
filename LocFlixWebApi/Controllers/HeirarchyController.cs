using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using LocFlixWebApi.Helpers;

namespace LocFlixWebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HeirarchyController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(string path = null)
        {
            var folders = new GenerateStructure().GetFolders(path);

            return Ok(folders);
        }
    }
}
