using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Web;
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
                ResponseType = "id_token",
                Scope = "openid evision",
                

                UseTokenLifetime = false,
                SignInAsAuthenticationType = "Cookies",

                //Notifications = new OpenIdConnectAuthenticationNotifications()
                //{
                //    SecurityTokenValidated = async n =>
                //    {
                        
                //    }
                //}
                
            });

        }
    }
}