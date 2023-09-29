using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PortfolioServer.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var host = builder.Configuration["DBHOST"] ?? "localhost";
var port = builder.Configuration["DBPORT"] ?? "3306";
var user = builder.Configuration["DBUSER"] ?? "root";
var password = builder.Configuration["DBPASSWORD"] ?? "1234";
builder.Services.AddDbContext<ApplicationContext>(
                    options =>
                    {
                        string connection = $"Host={host};Port={port};Database=portfolio;Username={user};Password={password};";
                        ServerVersion version = ServerVersion.AutoDetect(connection);
                        options.UseMySql(connection, version);
                    });

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    DbInitializer.Initialize(dbContext);
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
