using System;
using System.Net.Http;
using Thinktecture.IdentityModel.Client;

namespace ConsoleClient
{
    internal class Program
    {
        // http://jwt.io/
        // https://tools.ietf.org/html/rfc6750

        private static void Main(string[] args)
        {
            // Client Credential Flow

            //var dictionary = new Dictionary<string, string>()
            //{
            //    {"grant_type", "client_credentials"},
            //    {"scope", "api1"},
            //    {"client_id", "headless"},
            //    {"client_secret", "secret"}
            //};

            //var client = new HttpClient();
            //var response = client.PostAsync(
            //    new Uri("http://localhost:12345/connect/token"),
            //    new FormUrlEncodedContent(dictionary)).Result;

            //response.EnsureSuccessStatusCode();


            //var json = response.Content.ReadAsStringAsync().Result;
            //var j = JObject.Parse(json);
            //var accessToken = j["access_token"].ToString();
            //var expiresIn = j["expires_in"].ToString();


            var client = new OAuth2Client(
                new Uri("http://localhost:12345/connect/token"),
                "headless",
                "secret"
                );

            var response = client.RequestClientCredentialsAsync("api1").Result;
            var accessToken = response.AccessToken;

            Console.WriteLine(accessToken);

            Console.WriteLine();

            var client2 = new HttpClient();
            client2.SetBearerToken(accessToken);
            var result2 = client2.GetStringAsync("http://localhost:19348/api/data").Result;
            Console.WriteLine(result2);


            Console.ReadLine();
        }
    }
}