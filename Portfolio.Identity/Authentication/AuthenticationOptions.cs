using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Authentication
{
	public static class AuthenticationOptions
	{
		public static IdentityOptions identityOptions = new IdentityOptions { User = userOptions!, Password = passwordOptions!, SignIn = signInOptions! };
		private static UserOptions userOptions = new UserOptions { RequireUniqueEmail = true };
		private static SignInOptions signInOptions = new SignInOptions { RequireConfirmedAccount = true };
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