using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortfolioShared.Helpers;
using PortfolioShared.Models.Service;

namespace IdentityServer
{
	public class ApplicationContext : IdentityDbContext<User, Role, Guid>
	{
		public ApplicationContext() : base()
		{
		}
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{
		}
	}
}
