using Duende.IdentityServer.Hosting.LocalApiAuthentication;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using Duende.IdentityServer.Test;
using IdentityModel.Client;
using IdentityServer;
using IdentityServer.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MySqlConnector;
using PortfolioShared.Authentication;
using System.Globalization;

var seed = args.Contains("/seed");
if (seed)
{
	args = args.Except(new[] { "/seed" }).ToArray();
}
seed = false;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddMvc();
builder.Services.AddSignalR();
builder.Services.AddTransient<RegistrationHub>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllers();
builder.Services.AddControllersWithViews().AddDataAnnotationsLocalization().AddViewLocalization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme()
	{
		Name = "Authorization",
		Type = SecuritySchemeType.ApiKey,
		Scheme = JwtBearerDefaults.AuthenticationScheme,
		BearerFormat = "JWT",
		In = ParameterLocation.Header,
		Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
	});
	options.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			 {
				 Reference = new OpenApiReference
				 {
					 Type = ReferenceType.SecurityScheme,
					 Id = JwtBearerDefaults.AuthenticationScheme
				 }
			 },
			 new string[] {}
		}
	});
});
string assembly = typeof(Program).Assembly.GetName().Name!;
var connectionStringBuilder = new MySqlConnectionStringBuilder(builder.Configuration.GetConnectionString("DefaultConnection")!);
connectionStringBuilder.UserID = builder.Configuration["DBUser"];
connectionStringBuilder.Password = builder.Configuration["DBPassword"];
if (builder.Configuration["DBHost"] is not null)
	connectionStringBuilder.Server = builder.Configuration["DBHost"];
string connection = connectionStringBuilder.ConnectionString;
ServerVersion serverVersion = ServerVersion.AutoDetect(connection);

if (seed)
{
	SeedData.EnsureSeedData(connection, serverVersion);
}
builder.Services.AddHttpClient("PortfolioServer", httpClient =>
{
	httpClient.BaseAddress = new Uri(builder.Configuration["PortfolioServer:Url"]!);
	var response = httpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
	{
		Address = "https://localhost:7001/connect/token",
		ClientId = "m2m",
		ClientSecret = "client_secret",
		ClientCredentialStyle = ClientCredentialStyle.PostBody,
	}).GetAwaiter().GetResult();
	httpClient.SetBearerToken(response.AccessToken);
});
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
	//.AddConfigurationStore(options =>
	//{
	//	options.ConfigureDbContext = b => b.UseMySql(connection, serverVersion, opt => opt.MigrationsAssembly(assembly));
	//})
	//.AddOperationalStore(options =>
	//{
	//	options.ConfigureDbContext = b => b.UseMySql(connection, serverVersion, opt => opt.MigrationsAssembly(assembly));
	//})
	.AddProfileService<ProfileService>()
	.AddDeveloperSigningCredential();

	builder.Services.AddScoped<ICorsPolicyService>(sp => {
		var logger = sp.GetRequiredService<ILogger<DefaultCorsPolicyService>>();
		return new DefaultCorsPolicyService(logger)
		{
			AllowAll = true
		};
	});
JsonWebTokenHandler.DefaultInboundClaimTypeMap.Clear();
builder.Services.AddLocalApiAuthentication();

builder.Services.AddCors(options =>
{
	options.AddPolicy("MyPolicy", builder =>
	{
		builder
		.AllowAnyOrigin()
		.AllowAnyHeader()
		.AllowAnyMethod();
	});
});

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	app.UseHsts();
	
}
app.UseSwagger();
app.UseSwaggerUI();
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
app.UseCors("MyPolicy");
//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();
app.UseIdentityServer();
app.MapControllers();
app.MapDefaultControllerRoute();
app.MapRazorPages();
app.MapHub<RegistrationHub>("/RegistrationHub");
app.Run();
