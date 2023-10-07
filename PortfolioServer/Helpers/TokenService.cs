using PortfolioServer.Models.Service;
using System.IdentityModel.Tokens.Jwt;

namespace PortfolioServer.Helpers
{
	public class TokenService : ITokenService
	{
		private readonly IConfiguration configuration;
		public TokenService(IConfiguration configuration)
		{
			this.configuration = configuration;
		}
		public string CreateToken(User user, List<Role> roles)
		{
			var token = user.CreateClaims(roles).CreateJwtToken(configuration);
			var tokenHandler = new JwtSecurityTokenHandler();
			return tokenHandler.WriteToken(token);
		}
	}
}
