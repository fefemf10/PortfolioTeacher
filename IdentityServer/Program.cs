using IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var seed = args.Contains("/seed");
if (seed)
{
	args = args.Except(new[] { "/seed" }).ToArray();
}

var builder = WebApplication.CreateBuilder(args);

string assembly = typeof(Program).Assembly.GetName().Name!;
string connection = builder.Configuration.GetConnectionString("DefaultConnection")!;
ServerVersion serverVersion = ServerVersion.AutoDetect(connection);

if (seed)
{
	SeedData.EnsureSeedData(connection, serverVersion);
}

builder.Services.AddDbContext<ApplicationContext>(options => options.UseMySql(connection, serverVersion, opt => opt.MigrationsAssembly(assembly)));
builder.Services.AddIdentity<IdentityUser<Guid>, IdentityRole<Guid>>(options =>
{
	options.Password.RequiredLength = 5;
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequireLowercase = false;
	options.Password.RequireUppercase = false;
	options.Password.RequireDigit = false;
	options.User.RequireUniqueEmail = true;
})
	.AddEntityFrameworkStores<ApplicationContext>()
	.AddDefaultTokenProviders();

builder.Services.AddIdentityServer()
	.AddAspNetIdentity<IdentityUser<Guid>>()
	.AddConfigurationStore(options =>
	{
		options.ConfigureDbContext = b => b.UseMySql(connection, serverVersion, opt => opt.MigrationsAssembly(assembly));
	})
	.AddOperationalStore(options =>
	{
		options.ConfigureDbContext = b => b.UseMySql(connection, serverVersion, opt => opt.MigrationsAssembly(assembly));
	})
	.AddDeveloperSigningCredential();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();
app.UseStaticFiles();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();
app.MapDefaultControllerRoute();
app.Run();
