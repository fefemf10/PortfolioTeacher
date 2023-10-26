using Microsoft.AspNetCore.Identity;
using PortfolioShared.Models;
using PortfolioShared.Models.Service;
using System.Security.Claims;

namespace PortfolioShared.Helpers
{
	public static class RoleInitializer
	{
		private static string adminEmail = "admin@test.com";
		private static string adminPassword = "admin";
		public static async Task Initialize(UserManager<User> userManager)
		{
			if (await userManager.FindByEmailAsync(adminEmail) is null)
			{
				User admin = new User { Id = Guid.NewGuid(), Email = adminEmail, UserName = adminEmail };
				IdentityResult result = userManager.CreateAsync(admin, adminPassword).GetAwaiter().GetResult();
				if (result.Succeeded)
					userManager.AddClaimAsync(admin, new Claim(ClaimTypes.Role, Roles.Administrator.ToString())).GetAwaiter().GetResult();
			}
		}
	}
}
