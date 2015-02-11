using System;
using System.Collections.Generic;
using System.IdentityModel.Services;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.WsFederation;
using Owin;
using Thinktecture.IdentityServer.Core.Configuration;
using Thinktecture.IdentityServer.Core.Services;
using Thinktecture.IdentityServer.Core.Services.InMemory;
using Thinktecture.IdentityModel;

namespace IdentityServerDemo
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            var scope = new InMemoryScopeStore(Scopes.Get());
            var client = new InMemoryClientStore(Clients.Get());
            var users = new InMemoryUserService(Users.Get());

            var factory = new IdentityServerServiceFactory();
            factory.UserService = new Registration<IUserService>(users);
            factory.ScopeStore=new Registration<IScopeStore>(scope);
            factory.ClientStore=new Registration<IClientStore>(client);

            var options = new IdentityServerOptions()
            {
                RequireSsl = false,
                Factory = factory,
                SiteName = "My Test Provider",
                AuthenticationOptions = new AuthenticationOptions()
                {IdentityProviders = ConfigureIpds
                    
                },
                SigningCertificate = X509.LocalMachine.My.SubjectDistinguishedName.Find("CN=testcert", validOnly:false).First(),
            };

            app.UseIdentityServer(options);

            app.UseWelcomePage();
        }

        void ConfigureIpds(IAppBuilder app, string signInAsType)
        {
            var wsFed = new WsFederationAuthenticationOptions
            {
                AuthenticationType = "adfs",
                Caption = "Signing with ADFS",
                MetadataAddress = "",
                Wtrealm = "urn:evision",
                SignInAsAuthenticationType = signInAsType
            };


            var googleOptions = new GoogleOAuth2AuthenticationOptions()
            {
                AuthenticationType = "google",
                Caption = "Sign in with Google",
                ClientId = "936550414368-lj6k0md1ncivv85mh696sle5flcr0u1i.apps.googleusercontent.com",
                ClientSecret = "tM9HJMr79kBQ8w6dGhMEUM_p",
                SignInAsAuthenticationType = signInAsType
            };

            app.UseGoogleAuthentication(googleOptions);
        }
       }
}
