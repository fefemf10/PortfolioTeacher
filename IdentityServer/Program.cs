using IdentityServer;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PortfolioShared.Helpers;
using PortfolioShared.Models.Service;

var seed = args.Contains("/seed");
if (seed)
{
	args = args.Except(new[] { "/seed" }).ToArray();
}
seed = true;
var builder = WebApplication.CreateBuilder(args);
string connection = builder.Configuration.GetConnectionString("DefaultConnection")!;
ServerVersion serverVersion = ServerVersion.AutoDetect(connection);

// Add services to the container.
if (seed)
{
	SeedData.EnsureSeedData(connection, serverVersion);
}

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string assembly = typeof(Program).Assembly.GetName().Name!;
builder.Services.AddDbContext<ApplicationContext>(options => options.UseMySql(connection, serverVersion));
builder.Services.AddIdentity<User, Role>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();
builder.Services.AddIdentityServer()
	.AddDeveloperSigningCredential()
	.AddAspNetIdentity<User>()
	.AddConfigurationStore(options => 
		options.ConfigureDbContext = b => b.UseMySql(connection, serverVersion))
	.AddOperationalStore(options =>
		options.ConfigureDbContext = b => b.UseMySql(connection, serverVersion));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseIdentityServer();

app.MapControllers();

app.Run();
