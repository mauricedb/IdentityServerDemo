using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityServer.Core.Models;

namespace IdentityServerDemo
{
    public class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
           {
               new Client()
               {
                   ClientName = "MVC Client",
                   ClientId = "mvc",

                   Flow = Flows.Implicit,
                   RedirectUris = new List<string>()
                   {
                       "http://localhost:6516"
                   },
                   RequireConsent = false
               }
           };
        }
    }
}
