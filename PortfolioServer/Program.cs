using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PortfolioShared;
using PortfolioShared.Helpers;
using PortfolioShared.Models;
using PortfolioShared.Models.Service;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
	{
		Name = "Authorization",
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer",
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
					 Id = "Bearer"
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
	.AddJwtBearer(options =>
	{
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidIssuer = AuthOptions.Issuer,
			ValidateAudience = true,
			ValidAudience = AuthOptions.Audience,
			ValidateLifetime = true,
			IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey,
			ValidateIssuerSigningKey = true,
			ClockSkew = TimeSpan.Zero
		};
		options.Authority = AuthOptions.ServerURL;
	});

//builder.Services.AddIdentityCore<User>(options =>
//	{
//		options.Password.RequireDigit = true;
//		options.Password.RequireNonAlphanumeric = false;
//		options.Password.RequiredLength = 10;
//		options.Lockout.MaxFailedAccessAttempts = 10;
//		options.User.RequireUniqueEmail = true;
//	})
//	.AddRoles<IdentityRole>()
//	.AddEntityFrameworkStores<ApplicationContext>();
builder.Services.AddScoped<ITokenService, TokenService>();
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

builder.Services.AddIdentity<User, Role>(options =>
	{
		options.Password.RequiredLength = 5;
		options.Password.RequireNonAlphanumeric = false;
		options.Password.RequireLowercase = false;
		options.Password.RequireUppercase = false;
		options.Password.RequireDigit = false;
		options.User.RequireUniqueEmail = true;
	})
	.AddRoleManager<RoleManager<Role>>()
	.AddUserManager<UserManager<User>>()
	.AddSignInManager<SignInManager<User>>()
	.AddEntityFrameworkStores<ApplicationContext>();

AuthOptions.Configuration = builder.Configuration;
builder.Services.AddCors();
var app = builder.Build();
app.UseCors(builder => builder.AllowAnyOrigin());
using (var scope = app.Services.CreateScope())
{
	var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
	var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
	//DbInitializer.Initialize(dbContext);
	await RoleInitializer.Initialize(userManager);
	dbContext.SaveChanges();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
