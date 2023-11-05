using IdentityModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PortfolioServer;
using PortfolioShared.Models;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
HubConnection connection;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
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
builder.Services.AddDbContext<ApplicationContext>(options =>
	{
		string connection = builder.Configuration.GetConnectionString("DefaultConnection")!;
		ServerVersion version = ServerVersion.AutoDetect(connection);
		options.UseMySql(connection, version);
	});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
	{
		options.Authority = builder.Configuration["IdentityServer:Url"];
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateAudience = false,
			ValidTypes = new[] { "at+jwt" }
		};
	});

builder.Services.AddAuthorization(options =>
{
	options.DefaultPolicy =
		new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
		.RequireAuthenticatedUser()
		.Build();
	options.AddPolicy("IdentityServer", pBuilder =>
	{
		pBuilder.RequireClaim(JwtClaimTypes.Issuer, builder.Configuration["IdentityServer:Url"]!).RequireClaim(JwtClaimTypes.Role, Roles.IdentityServer.ToString());
	});
	options.AddPolicy(Roles.Administrator.ToString(), builder =>
	{
		builder.RequireClaim(JwtClaimTypes.Role, Roles.Administrator.ToString());
	});
	options.AddPolicy(Roles.Moderator.ToString(), builder =>
	{
		builder.RequireAssertion(x => x.User.HasClaim(JwtClaimTypes.Role, Roles.Administrator.ToString())
		|| x.User.HasClaim(JwtClaimTypes.Role, Roles.Moderator.ToString()));
	});
	options.AddPolicy(Roles.Teacher.ToString(), builder =>
	{
		builder.RequireAssertion(x => x.User.HasClaim(JwtClaimTypes.Role, Roles.Administrator.ToString())
		|| x.User.HasClaim(JwtClaimTypes.Role, Roles.Moderator.ToString())
		|| x.User.HasClaim(JwtClaimTypes.Role, Roles.Teacher.ToString()));
	});
	options.AddPolicy(Roles.Student.ToString(), builder =>
	{
		builder.RequireAssertion(x => x.User.HasClaim(JwtClaimTypes.Role, Roles.Administrator.ToString())
		|| x.User.HasClaim(JwtClaimTypes.Role, Roles.Moderator.ToString())
		|| x.User.HasClaim(JwtClaimTypes.Role, Roles.Teacher.ToString())
		|| x.User.HasClaim(JwtClaimTypes.Role, Roles.Student.ToString()));
	});
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

connection = new HubConnectionBuilder().WithAutomaticReconnect().WithUrl("https://localhost:7001/RegistrationHub").Build();
connection.On<Guid, string, Roles>("Receive", (Id, Email, Role) =>
{
	using (var scope = app.Services.CreateAsyncScope())
	{
		var db = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
		switch (Role)
		{
			case Roles.Teacher:
				db.Teachers.Add(new Teacher() { Id = Id, Email = Email });
				db.SaveChanges();
				break;
			case Roles.Student:
				db.Students.Add(new Student() { Id = Id, Email = Email });
				db.SaveChanges();
				break;
		}
	}
});
connection.StartAsync();
app.UseCors("MyPolicy");
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute();

app.Run();