﻿using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PortfolioSite;
using PortfolioSite.Extensions;
using System.Globalization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

CultureInfo[] supportedCultures = new[] { CultureInfo.GetCultureInfo("en-US"), CultureInfo.GetCultureInfo("ru-RU") };

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

var app = builder.Build();
await app.SetDefaultCulture();
await app.RunAsync();
