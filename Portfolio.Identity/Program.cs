using Duende.IdentityModel.Client;
using Duende.IdentityServer.Services;
using IdentityServer;
using IdentityServer.Authentication;
using IdentityServer.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using MySqlConnector;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddMvc();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllers();
builder.Services.AddControllersWithViews().AddDataAnnotationsLocalization().AddViewLocalization();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(options =>
//{
//	options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme()
//	{
//		Name = "Authorization",
//		Type = SecuritySchemeType.ApiKey,
//		Scheme = JwtBearerDefaults.AuthenticationScheme,
//		BearerFormat = "JWT",
//		In = ParameterLocation.Header,
//		Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
//	});
//	options.AddSecurityRequirement(new OpenApiSecurityRequirement
//	{
//		{
//			new OpenApiSecurityScheme
//			 {
//				 Reference = new OpenApiReference
//				 {
//					 Type = ReferenceType.SecurityScheme,
//					 Id = JwtBearerDefaults.AuthenticationScheme
//				 }
//			 },
//			 new string[] {}
//		}
//	});
//});
builder.Services.AddDistributedMemoryCache();
builder.Services.AddClientCredentialsTokenManagement()
    .AddClient("PortfolioServer.client", client =>
    {
        client.TokenEndpoint = builder.Configuration["HostIdentity"]! + "/connect/token";
        client.ClientId = "m2m";
        client.ClientSecret = "client_secret";
        client.ClientCredentialStyle = ClientCredentialStyle.PostBody;
    });
builder.Services.AddClientCredentialsHttpClient("PortfolioServer", "PortfolioServer.client", httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration["PortfolioServer:Url"]!);
});
string assembly = typeof(Program).Assembly.GetName().Name!;
var connectionStringBuilder = new MySqlConnectionStringBuilder();
connectionStringBuilder.Server = builder.Configuration["DBHost"];
connectionStringBuilder.Database = builder.Configuration["DBDatabase"];
connectionStringBuilder.UserID = builder.Configuration["DBUser"];
connectionStringBuilder.Password = builder.Configuration["DBPassword"];
string connection = connectionStringBuilder.ConnectionString;
ServerVersion serverVersion = ServerVersion.AutoDetect(connection);
builder.Services.AddDbContext<ApplicationContext>(options => options.UseMySql(connection, serverVersion, opt => opt.MigrationsAssembly(assembly)));

builder.Services.AddIdentity<IdentityUser<Guid>, IdentityRole<Guid>>(AuthenticationOptions.GetIdentityOptions)
    .AddSignInManager<SignInManager<IdentityUser<Guid>>>()
    .AddUserManager<UserManager<IdentityUser<Guid>>>()
    .AddRoles<IdentityRole<Guid>>()
    .AddRoleManager<RoleManager<IdentityRole<Guid>>>()
    .AddEntityFrameworkStores<ApplicationContext>()
    .AddClaimsPrincipalFactory<ClaimsPrincipalFactory>()
    .AddDefaultTokenProviders();

builder.Services.AddIdentityServer()
    .AddAspNetIdentity<IdentityUser<Guid>>()
    .AddInMemoryApiScopes(builder.Configuration.GetSection("IdentityServer:ApiScopes"))
    .AddInMemoryApiResources(builder.Configuration.GetSection("IdentityServer:ApiResources"))
    .AddInMemoryIdentityResources(Configuration.IdentityResources)
    .AddInMemoryClients(builder.Configuration.GetSection("IdentityServer:Clients"))
    .AddOperationalStore(options =>
    {
        options.ConfigureDbContext = b => b.UseMySql(connection, serverVersion, opt => opt.MigrationsAssembly(assembly));
    })
    .AddProfileService<ProfileService>()
    .AddDeveloperSigningCredential();

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

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();

}
//app.UseSwagger();
//app.UseSwaggerUI();
var supportedCultures = new[]
{
    new CultureInfo("en"),
    new CultureInfo("ru"),
};
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("ru"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

app.UseStaticFiles();
app.UseRouting();
app.UseAntiforgery();
app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
});

app.MapControllers();
app.MapDefaultControllerRoute();
app.MapRazorPages();
app.EnsureSeedData();
app.Run();
