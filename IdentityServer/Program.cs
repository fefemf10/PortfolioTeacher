using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using Duende.IdentityServer.Test;
using IdentityServer;
using IdentityServer.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
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
builder.Services.AddControllersWithViews().AddDataAnnotationsLocalization().AddViewLocalization();
string assembly = typeof(Program).Assembly.GetName().Name!;
var connectionStringBuilder = new MySqlConnectionStringBuilder(builder.Configuration.GetConnectionString("DefaultConnection")!);
connectionStringBuilder.UserID = builder.Configuration["DBUser"];
connectionStringBuilder.Password = builder.Configuration["DBPassword"];
connectionStringBuilder.Server = builder.Configuration["DBHost"];
string connection = connectionStringBuilder.ConnectionString;
ServerVersion serverVersion = ServerVersion.AutoDetect(connection);

if (seed)
{
	SeedData.EnsureSeedData(connection, serverVersion);
}

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
app.UseIdentityServer();
app.UseAuthorization();
app.MapControllers();
app.MapRazorPages();
app.MapHub<RegistrationHub>("/RegistrationHub");
app.Run();
