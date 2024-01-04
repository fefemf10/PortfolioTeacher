﻿using Blazored.LocalStorage;
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using BlazorPro.BlazorSize;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PortfolioShared.Models;
using PortfolioSite;
using PortfolioSite.Extensions;
using PortfolioSite.Handlers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.Services.AddScoped<IResizeListener, ResizeListener>();

builder.Services.AddScoped<ApiAuthorizationMessageHandler>();
builder.Services.AddHttpClient("PortfolioServer", httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration["PortfolioServer:Url"]!);
}).AddHttpMessageHandler<ApiAuthorizationMessageHandler>();
//.ConfigureHttpClient(httpClient =>
//{

//    httpClient.GetJsonWebKeySetAsync();
//});

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
