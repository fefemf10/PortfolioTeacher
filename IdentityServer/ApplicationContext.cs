using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer
{
	public class ApplicationContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<IdentityRole<Guid>>().HasData(Array.ConvertAll(Enum.GetNames<PortfolioShared.Models.Roles>(), x => new IdentityRole<Guid>(x) { Id = Guid.NewGuid(), NormalizedName = x.ToUpper() }));
		}
	}
}
