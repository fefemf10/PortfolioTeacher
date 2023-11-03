using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.VisualBasic;
using PortfolioShared.Models;
using System.Security.Claims;

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
		options.TokenValidationParameters = new TokenValidationParameters { ValidateAudience = false };
		options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
	});

builder.Services.AddAuthorization(options =>
{
	options.DefaultPolicy =
		new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
		.RequireAuthenticatedUser()
		.Build();
	options.AddPolicy(Roles.Administrator.ToString(), builder =>
	{
		builder.RequireClaim(ClaimTypes.Role, Roles.Administrator.ToString());
	});
	options.AddPolicy(Roles.Moderator.ToString(), builder =>
	{
		builder.RequireAssertion(x => x.User.HasClaim(ClaimTypes.Role, Roles.Administrator.ToString())
		|| x.User.HasClaim(ClaimTypes.Role, Roles.Moderator.ToString()));
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
