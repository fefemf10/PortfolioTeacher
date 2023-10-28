﻿using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using BlazorPro.BlazorSize;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PortfolioSite;
using PortfolioSite.Extensions;
using PortfolioSite.Services;
var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<IResizeListener, ResizeListener>();

//builder.Services.Configure<IdentityServerSettings>(builder.Configuration.GetSection("IdentityServer"));
//builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
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
builder.Services.AddAuthorizationCore();
var app = builder.Build();
await app.SetDefaultCulture();
await app.RunAsync();
