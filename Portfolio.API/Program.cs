using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Portfolio.API;
using Portfolio.API.Middleware;
using Portfolio.Infrastructure;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(options =>
{
    options.Filters.Add<LoggingFilter>();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly(), typeof(Portfolio.Application.AppMappingProfile).Assembly);

builder.Services.AddAPIServices();
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
builder.Configuration.AddUserSecrets<Program>();
var connectionStringBuilder = new MySqlConnectionStringBuilder();
connectionStringBuilder.Server = builder.Configuration["DBHost"];
connectionStringBuilder.Database = builder.Configuration["DBDatabase"];
connectionStringBuilder.UserID = builder.Configuration["DBUser"];
connectionStringBuilder.Password = builder.Configuration["DBPassword"];
connectionStringBuilder.Port = 3306;
Console.WriteLine(builder.Configuration["DBHost"]);
Console.WriteLine(builder.Configuration["DBDatabase"]);
Console.WriteLine(builder.Configuration["DBUser"]);
Console.WriteLine(builder.Configuration["DBPassword"]);
string connection = connectionStringBuilder.ConnectionString;
Console.WriteLine(connection);
ServerVersion serverVersion = ServerVersion.AutoDetect(connection);
builder.Services.AddDbContext<ApplicationContext>(options => options.UseMySql(connection, serverVersion, opt => opt.MigrationsAssembly(typeof(ApplicationContext).Assembly)));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
	{
		options.Authority = builder.Configuration["IdentityServer:Url"];
        options.RequireHttpsMetadata = false;
		options.TokenValidationParameters.ValidateAudience = false;
		options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
	});

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("ApiScope", policy =>
	{
		policy.RequireAuthenticatedUser();
		policy.RequireClaim("scope", builder.Configuration["IdentityServer:Scope"]!);
	});

builder.Services.AddCors();
builder.Services.AddStackExchangeRedisCache(options => {
    options.Configuration = builder.Configuration["RedisCache"];
    options.InstanceName = "local";
});
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.All;
    options.ForwardLimit = null;
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
    options.AllowedHosts.Clear();
});
var app = builder.Build();
app.UseForwardedHeaders();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
});
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseSwaggerUI(options =>
    //{
    //	//options.OAuthUsePkce();
    //});
}
app.UseAuthentication();
app.UseAuthorization();
app.MapDefaultControllerRoute().RequireAuthorization("ApiScope");
using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationContext>();
    context.Database.Migrate();
}
app.Run();