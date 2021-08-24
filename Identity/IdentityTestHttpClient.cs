using IdentityModel.Client;
using Microsoft.Extensions.Options;
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
        private readonly IOptions<DotNetAuthCLIOptions> _options;

        public IdentityTestHttpClient(HttpClient httpClient, IOptions<DotNetAuthCLIOptions> options) {
            _httpClient = httpClient;
            _options = options;
        }

        public string GetTestData()
        {
            var testResult = _httpClient.GetAsync(_options.Value.TestApiEndpoint).GetAwaiter().GetResult();
            var res = testResult.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            Console.WriteLine("STATUS = " + testResult.StatusCode.ToString());
            Console.WriteLine("RESPONSE = " + res);

            return res;
        }
    }
}
