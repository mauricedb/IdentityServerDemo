using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var identities = ((ClaimsPrincipal) User).Identities;
            var claims = from identity in identities from claim in identity.Claims select claim;


            return View(claims.ToList());
        }

        public async Task<ActionResult> CallService()
        {
            var url = "http://localhost:19348/api/data";
            var token = ((ClaimsPrincipal) User).FindFirst("at").Value;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetStringAsync(url);
            var json = JArray.Parse(response);


            return View(json);
        }
    }
}