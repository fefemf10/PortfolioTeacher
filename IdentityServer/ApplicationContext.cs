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
	}
}
