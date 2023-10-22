using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PortfolioShared.Helpers;
using System.Text;

namespace PortfolioShared
{
	public static class AuthOptions
	{
		public static IConfiguration Configuration = null!;
		public static string Issuer => Configuration["JwtAuth:Issuer"]!;
		public static string Audience => Configuration["JwtAuth:Audience"]!;
		public static string Key => Configuration["JwtAuth:Key"]!;
		public static int AccessTokenLifeTime => Configuration.GetValue<int>("JwtAuth:AccessTokenLifeTime");
		public static int RefreshTokenLifeTime => Configuration.GetValue<int>("JwtAuth:RefreshTokenLifeTime");
		public static SymmetricSecurityKey GetSymmetricSecurityKey => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
	}
}
