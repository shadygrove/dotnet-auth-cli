using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace dotnet_weather_cli.Providers
{
    public class IdentityDemoProvider
    {
        private HttpClient _httpClient;

        public IdentityDemoProvider(HttpClient httpClient) {
            _httpClient = httpClient;
        }

        public void GetTestData()
        {
            var testResult = _httpClient.GetAsync("https://demo.identityserver.io/api/test").GetAwaiter().GetResult();

            Console.WriteLine("Test Result");

            var res = testResult.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Console.WriteLine("STATUS = " + testResult.StatusCode.ToString());
            Console.WriteLine("RESPONSE = " + res);

            Console.ReadLine();
        }
    }
}
