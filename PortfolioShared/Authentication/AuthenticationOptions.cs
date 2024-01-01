using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace PortfolioShared.Authentication
{
	public static class AuthenticationOptions
	{
		public static IdentityOptions identityOptions = new IdentityOptions { User = userOptions!, Password = passwordOptions! };
		private static UserOptions userOptions = new UserOptions { RequireUniqueEmail = true };
		private static PasswordOptions passwordOptions = new PasswordOptions
		{
			RequiredLength = 5,
			RequireNonAlphanumeric = false,
			RequireLowercase = false,
			RequireUppercase = false,
			RequireDigit = false
		};

		public static void GetIdentityOptions(IdentityOptions options)
		{
			options.User = userOptions;
			options.Password = passwordOptions;
		}
		//Password.RequiredLength = 5,
		//Password.RequireNonAlphanumeric = false,
		//Password.RequireLowercase = false,
		//Password.RequireUppercase = false,
		//Password.RequireDigit = false,
		//User.RequireUniqueEmail = true
	}
}
