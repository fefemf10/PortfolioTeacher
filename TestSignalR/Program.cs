using Microsoft.AspNetCore.SignalR.Client;
using PortfolioShared.Models;


string url = "https://localhost:7001/RegistrationHub";
HubConnection connection = new HubConnectionBuilder().WithAutomaticReconnect().WithUrl(url).Build();
connection.On<Guid, string, Roles>("Receive", (Id, Email, Role) =>
{
	Console.WriteLine($"{Id} {Email} {Role}");
});
await connection.StartAsync();
Console.ReadKey();