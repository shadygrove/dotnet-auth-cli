using dotnet_auth_cli.Identity.Models;
using IdentityModel.Client;
using Microsoft.Extensions.DependencyInjection;
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
    public static class ServiceCollectionExtensions
    {
        public static void AddHttpClientWithBearer<TClient>(this IServiceCollection services) where TClient : class
        {
            services.AddHttpClient<TClient>((_svc, _httpClient) => {
                var settings = _svc.GetService<IOptions<DotNetAuthCLIOptions>>();
                var idRepo = _svc.GetService<IdentityRepository>();

                var discDoc = _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
                {
                    Address = settings.Value.IdentityServerUri
                }).GetAwaiter().GetResult();

                idRepo.SaveDiscoveryDocument(new DiscoveryDocument(discDoc));
                
                var cachedDiscDoc = idRepo.GetDiscoveryDocument();
                var tokenResponse = _httpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest()
                {
                    Address = cachedDiscDoc.TokenEndpoint,

                    ClientId = "m2m",
                    ClientSecret = "secret",
                    Scope = "api"
                });

                var result = tokenResponse.GetAwaiter().GetResult();

                Console.WriteLine("Token");
                Console.WriteLine(JsonSerializer.Serialize(result));

                _httpClient.SetBearerToken(result.AccessToken);
            });
        }
    }
}
