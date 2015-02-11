using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
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
                SigningCertificate = X509.LocalMachine.My.SubjectDistinguishedName.Find("CN=testcert", validOnly:false).First()
            };

            app.UseIdentityServer(options);

            app.UseWelcomePage();
        }
    }
}
