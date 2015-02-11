using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;

namespace WebApplication1
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();

            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = "Cookies"
            });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions()
            {
                
                Authority = "http://localhost:12345",
                ClientId = "mvc",
                RedirectUri = "http://localhost:6516",
                ResponseType = "id_token token",
                Scope = "openid evision be",
                

                UseTokenLifetime = false,
                SignInAsAuthenticationType = "Cookies",

                Notifications = new OpenIdConnectAuthenticationNotifications()
                {
                    SecurityTokenValidated = async n =>
                    {
                        var sub = n.AuthenticationTicket.Identity.FindFirst("sub");
                        var name = n.AuthenticationTicket.Identity.FindFirst("name");

                        var id = new ClaimsIdentity(n.AuthenticationTicket.Identity.AuthenticationType);
                        id.AddClaim(sub);
                        id.AddClaim(name);

                        var token = n.ProtocolMessage.AccessToken;
                        var tokenCLaom = new Claim("at", token);
                        id.AddClaim(tokenCLaom);

                        n.AuthenticationTicket = new AuthenticationTicket(id, n.AuthenticationTicket.Properties);
                    }
                }
                
            });

        }
    }
}