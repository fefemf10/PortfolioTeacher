using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Mappers;
using IdentityServer.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Domain.Models;

namespace IdentityServer
{
    public static class SeedData
    {
        public static void EnsureSeedData(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();
                scope.ServiceProvider.GetRequiredService<ApplicationContext>().Database.Migrate();
                EnsureUsers(scope);
            }
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
