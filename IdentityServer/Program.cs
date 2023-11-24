using Duende.IdentityServer.Services;
using IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var seed = args.Contains("/seed");
if (seed)
{
	args = args.Except(new[] { "/seed" }).ToArray();
}
seed = false;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllers();
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
	.AddSignInManager<SignInManager<IdentityUser<Guid>>>()
	.AddUserManager<UserManager<IdentityUser<Guid>>>()
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

	builder.Services.AddScoped<ICorsPolicyService>(sp => {
		var logger = sp.GetRequiredService<ILogger<DefaultCorsPolicyService>>();
		return new DefaultCorsPolicyService(logger)
		{
			AllowAll = true
		};
	}); ;

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
app.UseCors("MyPolicy");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAntiforgery();
app.UseIdentityServer();
app.UseAuthorization();
app.MapControllers();
app.MapRazorPages();
app.MapHub<RegistrationHub>("/RegistrationHub");
app.Run();
