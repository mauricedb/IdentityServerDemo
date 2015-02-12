using System;
using System.Collections.Generic;
using Thinktecture.IdentityServer.Core.Models;

namespace IdentityServerDemo
{
    public class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientName = "MVC Client",
                    ClientId = "mvc",
                    Flow = Flows.Implicit,
                    RedirectUris = new List<string>
                    {
                        "http://localhost:6516",
                        "http://localhost:6516/js.html"
                    },
                    RequireConsent = false
                },
                new Client
                {
                    ClientName = "Headless client",
                    ClientId = "headless",
                    Flow = Flows.ClientCredentials,

                    // List of secrets for roll over
                    ClientSecrets = new List<ClientSecret>
                    {
                        new ClientSecret("secret".Sha256(), "Some client secret",
                            new DateTimeOffset(new DateTime(2020, 1, 1)))
                    },
                    ScopeRestrictions = new List<string>
                    {
                        "api1",
                        "api2"
                    }
                }
            };
        }
    }
}