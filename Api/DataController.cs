using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json.Linq;

namespace Api
{
    [Route("api/data")]
    [Authorize]
    public class DataController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            var identities = ((ClaimsPrincipal)User).Identities;
            var claims = from identity in identities from claim in identity.Claims select new {claim.Type, claim.Value};

            return Ok(claims);
        }

    }
}