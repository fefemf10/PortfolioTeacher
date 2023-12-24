﻿using Blazored.LocalStorage;
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using BlazorPro.BlazorSize;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PortfolioSite;
using PortfolioSite.Extensions;
using PortfolioSite.Handlers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
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
var app = builder.Build();
await app.SetDefaultCulture();
await app.RunAsync();
