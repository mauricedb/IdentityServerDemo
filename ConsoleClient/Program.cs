using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ConsoleClient
{
    class Program
    {
        //http://jwt.io/

        static void Main(string[] args)
        {
            // Client Credential Flow

            var dictionary = new Dictionary<string, string>()
            {
                {"grant_type", "client_credentials"},
                {"scope", "api1"},
                {"client_id", "headless"},
                {"client_secret", "secret"}
            };

            var client = new HttpClient();
            var response = client.PostAsync(
                new Uri("http://localhost:12345/connect/token"),
                new FormUrlEncodedContent(dictionary)).Result;

            response.EnsureSuccessStatusCode();


            var json = response.Content.ReadAsStringAsync().Result;
            var j = JObject.Parse(json);
            var accessToken = j["access_token"].ToString();
            var expiresIn = j["expires_in"].ToString();

            Console.WriteLine(accessToken);
            Console.WriteLine(expiresIn);

            Console.ReadLine();

        }
    }
}
