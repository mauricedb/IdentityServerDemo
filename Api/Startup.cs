using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Web;
using System.Web.Http;
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


            HttpConfiguration configuration = new HttpConfiguration();
            configuration.MapHttpAttributeRoutes();
            
            app.UseWebApi(configuration);
        }
    }
}