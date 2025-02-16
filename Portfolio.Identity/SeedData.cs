using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Mappers;
using IdentityServer.Authentication;
using Portfolio.Domain.Models;

namespace IdentityServer
{
	public class SeedData
	{
		public static void EnsureSeedData(string connection, ServerVersion serverVersion)
		{
			var services = new ServiceCollection();
			services.AddLogging();
			services.AddDbContext<ApplicationContext>(options => options.UseMySql(connection, serverVersion));

			services.AddIdentity<IdentityUser<Guid>, IdentityRole<Guid>>(AuthenticationOptions.GetIdentityOptions)
			.AddEntityFrameworkStores<ApplicationContext>()
			.AddDefaultTokenProviders();

			//services.AddOperationalDbContext(options =>
			//{
			//	options.ConfigureDbContext = db => db.UseMySql(connection, serverVersion, opt => opt.MigrationsAssembly(typeof(SeedData).Assembly.FullName));
			//});
			//services.AddConfigurationDbContext(options =>
			//{
			//	options.ConfigureDbContext = db => db.UseMySql(connection, serverVersion, opt => opt.MigrationsAssembly(typeof(SeedData).Assembly.FullName));
			//});

			var serviceProvider = services.BuildServiceProvider();

			using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
			//scope.ServiceProvider.GetService<PersistedGrantDbContext>().Database.Migrate();

			//ConfigurationDbContext context = scope.ServiceProvider.GetService<ConfigurationDbContext>();
			//context.Database.Migrate();
			//EnsureSeedData(context);
			var ctx = scope.ServiceProvider.GetService<ApplicationContext>();
			ctx.Database.Migrate();
			EnsureUsers(scope);
		}

		private static void EnsureUsers(IServiceScope scope)
		{
			var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser<Guid>>>();
			var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
			var user = userMgr.FindByEmailAsync("admin@admin.com").Result;
			if (user is null)
			{
				user = new IdentityUser<Guid>
				{
					UserName = "admin@admin.com",
					Email = "admin@admin.com",
					EmailConfirmed = true,
				};
				userMgr.CreateAsync(user, "admin").Wait();
				userMgr.AddToRoleAsync(user, Roles.Administrator.ToString()).Wait();
			}
		}
		private static void EnsureSeedData(ConfigurationDbContext db)
		{
			if (!db.Clients.Any())
			{
				db.Clients.AddRange(Configuration.Clients.Select(x => x.ToEntity()).ToArray());
				db.SaveChanges();
			}
			if (!db.IdentityResources.Any())
			{
				db.IdentityResources.AddRange(Configuration.IdentityResources.Select(x => x.ToEntity()).ToArray());
				db.SaveChanges();
			}
			if (!db.ApiScopes.Any())
			{
				db.ApiScopes.AddRange(Configuration.ApiScopes.Select(x => x.ToEntity()).ToArray());
				db.SaveChanges();
			}
			if (!db.ApiResources.Any())
			{
				db.ApiResources.AddRange(Configuration.ApiResources.Select(x => x.ToEntity()).ToArray());
				db.SaveChanges();
			}
		}
	}
}
