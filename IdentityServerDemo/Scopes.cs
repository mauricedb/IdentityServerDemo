using System.Collections.Generic;
using Thinktecture.IdentityServer.Core.Models;

namespace IdentityServerDemo
{
    public class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            var scopes = new List<Scope>();

            scopes.Add(StandardScopes.OpenId);
            //scopes.Add(StandardScopes.Profile);

            var eVisionScope = new Scope
            {
                Enabled = true,
                Type = ScopeType.Identity,
                Name = "evision",
                Claims = new List<ScopeClaim>
                {
                    new ScopeClaim("name", true)
                }
            };
            scopes.Add(eVisionScope);

            var api1 = new Scope
            {
                Enabled = true,
                Type = ScopeType.Resource,
                Name = "api1"
            };
            scopes.Add(api1);

            return scopes;
        }
    }
}