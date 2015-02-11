using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult CallService()
        {

            return View();
        }
    }
}