using Microsoft.AspNetCore.Identity;
using PortfolioShared.Models.Service;

namespace PortfolioShared.Helpers
{
	public static class RoleInitializer
	{
		private static string adminEmail = "admin@test.com";
		private static string adminPassword = "admin";
		private static string[] roles = { "Admin", "Moderator", "Teacher", "Student"};
		public static async Task Initialize(UserManager<User> userManager, RoleManager<Role> roleManager)
		{
			foreach (var role in roles)
			{
				if (!await roleManager.RoleExistsAsync(role))
					await roleManager.CreateAsync(new Role(role));
			}
			if (await userManager.FindByEmailAsync(adminEmail) is null)
			{
				User admin = new User { Id = Guid.NewGuid(), Email = adminEmail, UserName = adminEmail };
				IdentityResult result = await userManager.CreateAsync(admin, adminPassword);
				if (result.Succeeded)
					await userManager.AddToRoleAsync(admin, "Admin");
			}
		}
	}
}
