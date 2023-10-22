using Microsoft.AspNetCore.Identity;

namespace PortfolioShared.Models.Service
{
	public class User : IdentityUser<Guid>
	{
		public Teacher Teacher { get; set; }
		public Student Student { get; set; }
		public string? RefreshToken { get; set; }
		public DateTimeOffset RefreshTokenExpityTime { get; set; }
	}
}
