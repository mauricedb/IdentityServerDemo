using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Owin;
using Thinktecture.IdentityServer.AccessTokenValidation;

namespace Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();

            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions()
            {
                Authority = "http://localhost:12345",
                ValidationMode = ValidationMode.Local,

                RequiredScopes = new[] { "api1" }
            });

            app.UseClaimsTransformation(Transform);


            HttpConfiguration configuration = new HttpConfiguration();
            configuration.MapHttpAttributeRoutes();
            configuration.EnableCors();
            app.UseWebApi(configuration);
        }

        private Task<ClaimsPrincipal> Transform(ClaimsPrincipal incoming)
        {
            incoming.Identities.First().AddClaim(new Claim("app_specific", "some value"));
            return Task.FromResult(incoming);
        }
    }
}