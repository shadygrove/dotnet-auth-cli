using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace dotnet_auth_cli.Identity
{
    public class IdentityTestHttpClient
    {
        private readonly HttpClient _httpClient;

        public IdentityTestHttpClient(HttpClient httpClient) {
            _httpClient = httpClient;
        }

        public string GetTestData()
        {
            var testResult = _httpClient.GetAsync("https://demo.identityserver.io/api/test").GetAwaiter().GetResult();
            var res = testResult.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            Console.WriteLine("STATUS = " + testResult.StatusCode.ToString());
            Console.WriteLine("RESPONSE = " + res);

            return res;
        }
    }
}
