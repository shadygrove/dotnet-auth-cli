# .NET Auth Console Example

This project shows an example of how to use the Client Credentials authentication protocol to enable a Console app to authenticate with an API.

For simplicity this project requests tokens from the IdentityServer demo application at [https://demo.identityserver.io](https://demo.identityserver.io)  

### About Confidential Grants

Some applications, such as "daemon" or background processing. 

### Third-party Libraries

The [IdentityModel library for .NET](https://identitymodel.readthedocs.io/en/latest/index.html) proved to be helpful in setting up this application.

### About Microsoft Libraries

[Microsoft Identity Platform](https://docs.microsoft.com/en-us/azure/active-directory/develop/) does provide some tools for authentication in .NET, but much of it seems to be targeted towards use of Azure Active Directory and it is not clear if it can be used with other identity providers such as Keycloak.

It is assumed that the Identity Platform is setup to support OAuth 2.0 Open ID Connect protocols.

Example of a [daemon application using MSAL.NET](https://docs.microsoft.com/en-us/samples/azure-samples/active-directory-dotnetcore-daemon-v2/ms-identity-daemon/)


## Code Explanation

### Configuration

Console apps do not include dependency injection or configuration by default, but they have beend added to this project.

Added the `Microsoft.Configuration.Hosting` Nuget package  


##### Resources on .NET Configuration
[How To Use appsettings.json in Console Apps](https://thecodeblogger.com/2021/05/04/how-to-use-appsettings-json-config-file-with-net-console-applications/)

