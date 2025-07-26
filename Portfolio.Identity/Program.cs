using Duende.IdentityModel.Client;
using Duende.IdentityServer.Services;
using Duende.IdentityServer.Validation;
using IdentityServer;
using IdentityServer.Authentication;
using IdentityServer.Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using MySqlConnector;
using Portfolio.Identity.Middleware;
using Portfolio.Identity.Validator;
using System.Globalization;
using System.Reflection;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddAntiforgery();
builder.Configuration.AddUserSecrets<Program>();

var connectionStringBuilder = new MySqlConnectionStringBuilder()
{
    Server = builder.Configuration["DBHost"],
    Database = builder.Configuration["DBDatabase"],
    UserID = builder.Configuration["DBUser"],
    Password = builder.Configuration["DBPassword"]
};
string connection = connectionStringBuilder.ConnectionString;
builder.Services.AddDbContext<ApplicationContext>(context =>
    context.UseMySql(connection, ServerVersion.AutoDetect(connection), opt => opt.MigrationsAssembly(Assembly.GetExecutingAssembly())));

builder.Services.AddIdentity<IdentityUser<Guid>, IdentityRole<Guid>>(AuthenticationOptions.GetIdentityOptions)
    .AddSignInManager<SignInManager<IdentityUser<Guid>>>()
    .AddUserManager<UserManager<IdentityUser<Guid>>>()
    .AddRoles<IdentityRole<Guid>>()
    .AddRoleManager<RoleManager<IdentityRole<Guid>>>()
    .AddEntityFrameworkStores<ApplicationContext>()
    .AddClaimsPrincipalFactory<ClaimsPrincipalFactory>()
    .AddDefaultTokenProviders();

builder.Services.AddTransient<IRedirectUriValidator, WildcardRedirectUriValidator>();
builder.Services.AddIdentityServer()
    .AddAspNetIdentity<IdentityUser<Guid>>()
    .AddInMemoryApiScopes(builder.Configuration.GetSection("IdentityServer:ApiScopes"))
    .AddInMemoryApiResources(builder.Configuration.GetSection("IdentityServer:ApiResources"))
    .AddInMemoryIdentityResources(Configuration.IdentityResources)
    .AddInMemoryClients(builder.Configuration.GetSection("IdentityServer:Clients"))
    .AddServerSideSessions()
    .AddOperationalStore(store =>
    {
        store.ConfigureDbContext = context =>
            context.UseMySql(connection, ServerVersion.AutoDetect(connection), opt => opt.MigrationsAssembly(Assembly.GetExecutingAssembly()));
    })
    .AddProfileService<ProfileService>()
    .AddDeveloperSigningCredential();

builder.Services.ConfigureApplicationCookie(options => {
    options.Cookie.SameSite = SameSiteMode.Strict;
    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
});

builder.Services.AddScoped<ICorsPolicyService>(sp =>
{
    var logger = sp.GetRequiredService<ILogger<DefaultCorsPolicyService>>();
    return new DefaultCorsPolicyService(logger)
    {
        AllowAll = true
    };
});
JsonWebTokenHandler.DefaultInboundClaimTypeMap.Clear();
builder.Services.AddLocalApiAuthentication();

builder.Services.AddCors();
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.All;
    options.ForwardLimit = null;
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
    options.AllowedHosts.Clear();
});
var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseForwardedHeaders();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    //app.UseHsts();
}
app.UsePathBase("/id");
app.UseRouting();
app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
});
app.MapControllers();
app.EnsureSeedData();
app.Run();
