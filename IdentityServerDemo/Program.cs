using System;
using Microsoft.Owin.Hosting;
using Thinktecture.IdentityServer.Core.Logging;

namespace IdentityServerDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            LogProvider.SetCurrentLogProvider(new DiagnosticsTraceLogProvider());

            using (WebApp.Start<Startup>("http://localhost:12345"))
            {
                Console.ReadLine();
            }
        }
    }
}