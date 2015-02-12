using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Api
{
    [Authorize]
    public class DataController : ApiController
    {
        [Route("api/data")]
        [EnableCors("*", "*", "*")]
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            var identities = ((ClaimsPrincipal) User).Identities;
            var claims = from identity in identities from claim in identity.Claims select new {claim.Type, claim.Value};

            return Ok(claims);
        }
    }
}