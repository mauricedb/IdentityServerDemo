using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json.Linq;

namespace Api
{
    [Authorize]
    public class DataController : ApiController
    {
        [Route("api/data")]
        [EnableCors("*", "*","*")]
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            var identities = ((ClaimsPrincipal)User).Identities;
            var claims = from identity in identities from claim in identity.Claims select new {claim.Type, claim.Value};

            return Ok(claims);
        }

    }
}