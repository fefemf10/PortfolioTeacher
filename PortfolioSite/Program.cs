using Blazored.LocalStorage;
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using BlazorPro.BlazorSize;
using IdentityModel;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using PortfolioShared.Models;
using PortfolioSite;
using PortfolioSite.Extensions;
using PortfolioSite.Handlers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<IResizeListener, ResizeListener>();

builder.Services.AddScoped<ApiAuthorizationMessageHandler>();
builder.Services.AddScoped<IdentityAuthorizationMessageHandler>();
builder.Services.AddHttpClient("PortfolioServer", httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration["PortfolioServer:Url"]!);
}).AddHttpMessageHandler<ApiAuthorizationMessageHandler>();
builder.Services.AddHttpClient("IdentityServer", httpClient =>
{
	httpClient.BaseAddress = new Uri(builder.Configuration["IdentityServer:Url"]!);
 //   var response1 = await httpClient.RequestAuthorizationCodeTokenAsync(new AuthorizationCodeTokenRequest
 //   {
	//	Address = "https://localhost:7001/connect/token",
	//	ClientId = "PortfolioSite",
	//	ClientCredentialStyle = ClientCredentialStyle.PostBody,
	//});
	//var response2 = await httpClient.RequestBackchannelAuthenticationTokenAsync(new BackchannelAuthenticationTokenRequest
	//{
	//	Address = "https://localhost:7001/connect/token",
	//	ClientId = "PortfolioSite",
 //       GrantType = GrantTypes.AuthorizationCode,
 //       AuthenticationRequestId
	//	ClientCredentialStyle = ClientCredentialStyle.PostBody,
	//});
	//httpClient.SetBearerToken(response2.AccessToken);
}).AddHttpMessageHandler<IdentityAuthorizationMessageHandler>();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Oidc", options.ProviderOptions);
    options.UserOptions.NameClaim = JwtClaimTypes.Name;
    options.UserOptions.RoleClaim = JwtClaimTypes.Role;
});

builder.Services.AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrap5Providers()
    .AddFontAwesomeIcons();
builder.Services.AddMediaQueryService();
builder.Services.AddResizeListener();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .Build();
});
builder.Services.AddCascadingAuthenticationState();
var app = builder.Build();
await app.SetDefaultCulture();
await app.RunAsync();
