# .NET Auth Console Example

This project shows an example of how to use the Client Credentials authentication protocol to enable a Console app to authenticate with an API.

For simplicity this project requests tokens from the IdentityServer demo application at [https://demo.identityserver.io](https://demo.identityserver.io)  

To make a secured web call, the application uses the test API provided on the Identity Server demo:  
https://demo.identityserver.io/api/test

##### Resources Used in Building This App

[.NET Dependency Injection for Console Apps](https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection-usage)  
[.NET Custom HttpClients](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests)  
[.NET Http Interceptors](https://stackoverflow.com/questions/63260187/httpinterceptor-implementation-in-c-sharp-and-net)  
[.NET Http Requests](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-5.0#generated-clients) (interesting item on using [Polly](https://github.com/App-vNext/Polly) for fault tolerance and resiliency)  

### About Confidential Grants

Some applications, such as "daemon" or background processing. 

### Third-party Libraries

The [IdentityModel library for .NET](https://identitymodel.readthedocs.io/en/latest/index.html) proved to be helpful in setting up this application.

### About Microsoft Libraries

[Microsoft Identity Platform](https://docs.microsoft.com/en-us/azure/active-directory/develop/) does provide some tools for authentication in .NET, but much of it seems to be targeted towards use of Azure Active Directory and it is not clear if it can be used with other identity providers such as Keycloak.

It is assumed that the Identity Platform is setup to support OAuth 2.0 Open ID Connect protocols.

Example of a [daemon application using MSAL.NET](https://docs.microsoft.com/en-us/samples/azure-samples/active-directory-dotnetcore-daemon-v2/ms-identity-daemon/)

Other Microsoft Resources:  
- [Identity Extensions for .NET](https://github.com/AzureAD/azure-activedirectory-identitymodel-extensions-for-dotnet) (Azure Active Directory)

### Third-party Provider Support

There is some direct support for [third-party auth providers](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/social/other-logins?view=aspnetcore-3.1) via Nuget packages, but I don't see any specific to Keycloak.

## Code Explanation

### Configuration

Console apps do not include dependency injection or configuration by default, but they have beend added to this project.

Added the `Microsoft.Configuration.Hosting` Nuget package  


##### Resources on .NET Configuration
[How To Use appsettings.json in Console Apps](https://thecodeblogger.com/2021/05/04/how-to-use-appsettings-json-config-file-with-net-console-applications/)

