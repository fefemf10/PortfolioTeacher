using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.EntityFramework.Storage;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PortfolioShared.Helpers;
using PortfolioShared.Models.Service;

namespace IdentityServer
{
	public class SeedData
	{
		public static void EnsureSeedData(string connection, ServerVersion serverVersion)
		{
			var services = new ServiceCollection();
			services.AddLogging();
			services.AddDbContext<ApplicationContext>(options => options.UseMySql(connection, serverVersion));

			services
				.AddIdentity<User, Role>()
				.AddEntityFrameworkStores<ApplicationContext>()
				.AddDefaultTokenProviders();

			services.AddOperationalDbContext(options =>
					options.ConfigureDbContext = db => db.UseMySql(connection, serverVersion)
			);
			services.AddConfigurationDbContext(options =>
					options.ConfigureDbContext = db => db.UseMySql(connection, serverVersion)
			);

			var serviceProvider = services.BuildServiceProvider();

			using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
			scope.ServiceProvider.GetService<PersistedGrantDbContext>().Database.EnsureCreated();

			ConfigurationDbContext context = scope.ServiceProvider.GetService<ConfigurationDbContext>();
			context.Database.EnsureCreated();
			EnsureSeedData(context);
		}
		private static void EnsureSeedData(ConfigurationDbContext context)
		{
			if (!context.Clients.Any())
			{
				context.Clients.AddRange(Configuration.Clients.Select(x => x.ToEntity()).ToArray());
				context.SaveChanges();
			}
			if (!context.IdentityResources.Any())
			{
				context.IdentityResources.AddRange(Configuration.IdentityResources.Select(x => x.ToEntity()).ToArray());
				context.SaveChanges();
			}
			if (!context.ApiScopes.Any())
			{
				context.ApiScopes.AddRange(Configuration.ApiScopes.Select(x => x.ToEntity()).ToArray());
				context.SaveChanges();
			}
			if (!context.ApiResources.Any())
			{
				context.ApiResources.AddRange(Configuration.ApiResources.Select(x => x.ToEntity()).ToArray());
				context.SaveChanges();
			}
		}
	}
}
