using IdentityModel.Client;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.Options;
using dotnet_auth_cli.Identity;

namespace dotnet_auth_cli
{
    class Program
    {
        static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                    .ConfigureAppConfiguration((hostingContext, configuration) => {
                        // See docs for configuration info
                        // https://docs.microsoft.com/en-us/dotnet/core/extensions/configuration-providers#file-configuration-provider
                        IHostEnvironment env = hostingContext.HostingEnvironment;

                        configuration
                            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);
                    })
                    .ConfigureServices((hostCtx, services) =>
                    {
                        var optionsConfig = hostCtx.Configuration.GetSection("WeatherCLIOptions");
                        services.Configure<DotNetAuthCLIOptions>(optionsConfig);

                        services.AddSingleton<IdentityRepository>();
                        services.AddHttpClientWithBearer<IdentityTestHttpClient>();
                    });
                        

        static void Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            bool redo = true;
            while (redo) {
                RunTest(host);

                Console.WriteLine("");
                Console.WriteLine("Do it again? y/n");
                string yn = Console.ReadLine();
                redo = yn.ToLower() == "y";
            }
        }

        private static void RunTest(IHost host)
        {
            var idDemoProvider = host.Services.GetService<IdentityTestHttpClient>();

            var testResult = idDemoProvider.GetTestData();

            Console.WriteLine("API Test Result:");
            Console.WriteLine(testResult);
        }
    }
}
