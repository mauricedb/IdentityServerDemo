using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api
{
    [Route("api/data")]
    [Authorize]
    public class DataController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            return Ok();
        }

    }
}