using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using PortfolioShared.Models;
using Duende.IdentityServer.EntityFramework.Storage;
using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Mappers;

namespace IdentityServer
{
	public class SeedData
	{
		public static void EnsureSeedData(string connection, ServerVersion serverVersion)
		{
			var services = new ServiceCollection();
			services.AddLogging();
			services.AddDbContext<ApplicationContext>(options => options.UseMySql(connection, serverVersion));

			services.AddIdentity<IdentityUser<Guid>, IdentityRole<Guid>>(options =>
			{
				options.Password.RequiredLength = 5;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireLowercase = false;
				options.Password.RequireUppercase = false;
				options.Password.RequireDigit = false;
				options.User.RequireUniqueEmail = true;
			})
			.AddEntityFrameworkStores<ApplicationContext>()
			.AddDefaultTokenProviders();

			services.AddOperationalDbContext(options =>
			{
				options.ConfigureDbContext = db => db.UseMySql(connection, serverVersion, opt => opt.MigrationsAssembly(typeof(SeedData).Assembly.FullName));
			});
			services.AddConfigurationDbContext(options =>
			{
				options.ConfigureDbContext = db => db.UseMySql(connection, serverVersion, opt => opt.MigrationsAssembly(typeof(SeedData).Assembly.FullName));
			});

			var serviceProvider = services.BuildServiceProvider();

			using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
			scope.ServiceProvider.GetService<PersistedGrantDbContext>().Database.Migrate();

			ConfigurationDbContext context = scope.ServiceProvider.GetService<ConfigurationDbContext>();
			context.Database.Migrate();
			EnsureSeedData(context);
			var ctx = scope.ServiceProvider.GetService<ApplicationContext>();
			ctx.Database.Migrate();
			EnsureUsers(scope);
		}

		private static void EnsureUsers(IServiceScope scope)
		{
			var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser<Guid>>>();

			var admin = userMgr.FindByEmailAsync("admin@admin.com").Result;
			if (admin is null)
			{
				admin = new IdentityUser<Guid>
				{
					UserName = "admin@admin.com",
					Email = "admin@admin.com",
					EmailConfirmed = true
				};
				var result = userMgr.CreateAsync(admin, "admin").Result;
				if (!result.Succeeded)
				{
					throw new Exception(result.Errors.First().Description);
				}
				result = userMgr.AddClaimAsync(admin,new Claim(ClaimTypes.Role, Roles.Administrator.ToString())).Result;
				if (!result.Succeeded)
				{
					throw new Exception(result.Errors.First().Description);
				}
			}
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
