using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
//using Microsoft.OpenApi.Models;
using MySqlConnector;
using PortfolioShared.Models;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
{
    using FileStream disciplineStream = File.OpenRead("SeedData/Discipline.json");
    ApplicationContext.disciplinesData = JsonSerializer.Deserialize<Discipline[]>(disciplineStream);
    using FileStream facultyStream = File.OpenRead("SeedData/Faculty.json");
    ApplicationContext.facultiesData = JsonSerializer.Deserialize<Faculty[]>(facultyStream);
    using FileStream departmentStream = File.OpenRead("SeedData/Department.json");
    ApplicationContext.departmentData = JsonSerializer.Deserialize<Department[]>(departmentStream);
}
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(options =>
//{
//	options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
//	{
//		Type = SecuritySchemeType.OAuth2,
//		Flows = new OpenApiOAuthFlows
//		{
//			AuthorizationCode = new OpenApiOAuthFlow
//			{
//				AuthorizationUrl = new Uri(builder.Configuration["IdentityServer:Url"] + "/connect/authorize"),
//				TokenUrl = new Uri(builder.Configuration["IdentityServer:Url"] + "/connect/token"),
//				Scopes = new Dictionary<string, string>
//				{
//					{"PortfolioServer", "PortfolioServer"}
//				}
//			},
//		}
//	});
//	options.AddSecurityRequirement(new OpenApiSecurityRequirement
//	{
//		{
//			new OpenApiSecurityScheme
//			{
//				Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
//			},
//			new[] { "PortfolioServer" }
//		}
//	});
//});
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

builder.Services.AddDbContext<ApplicationContext>(options =>
    {
        var connectionStringBuilder = new MySqlConnectionStringBuilder(builder.Configuration.GetConnectionString("DefaultConnection")!);
        connectionStringBuilder.UserID = builder.Configuration["DBUser"];
        connectionStringBuilder.Password = builder.Configuration["DBPassword"];
        if (builder.Configuration["DBHost"] is not null)
            connectionStringBuilder.Server = builder.Configuration["DBHost"];
        string connection = connectionStringBuilder.ConnectionString;
        ServerVersion version = ServerVersion.AutoDetect(connection);
        options.UseMySql(connection, version);
    });
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.Authority = builder.Configuration["IdentityServer:Url"];
        options.TokenValidationParameters.ValidateAudience = false;
        options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
    });

builder.Services.AddAuthorization(options =>
{
	options.AddPolicy("ApiScope", policy =>
	{
        policy.RequireAuthenticatedUser();
		policy.RequireClaim("scope", builder.Configuration["IdentityServer:Scope"]!);
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
 //   app.UseSwagger();
	//app.UseSwaggerUI(options =>
	//{
	//	//options.OAuthUsePkce();
	//});
}

app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute().RequireAuthorization("ApiScope");

app.Run();