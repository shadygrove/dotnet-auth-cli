using IdentityModel.Client;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using dotnet_weather_cli.Providers;

namespace dotnet_weather_cli
{
    class Program
    {

        static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                    .ConfigureServices((_, services) =>
                    {
                        services.AddSingleton<IdentityDemoProvider>();
                        services.AddHttpClient<IdentityDemoProvider>(_httpClient => {
                            var tokenResponse = _httpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest()
                            {
                                Address = "https://demo.identityserver.io/connect/token",

                                ClientId = "m2m",
                                ClientSecret = "secret",
                                Scope = "api"
                            });

                            var result = tokenResponse.GetAwaiter().GetResult();

                            Console.WriteLine("Token");
                            Console.WriteLine(JsonSerializer.Serialize(result));


                            _httpClient.SetBearerToken(result.AccessToken);
                        });
                    });
                        

        static void Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            Console.WriteLine("Hello World!");

            var http = new HttpClient();

            var idDemoProvider = host.Services.GetService<IdentityDemoProvider>();

            idDemoProvider.GetTestData();
       
        }
    }
}
