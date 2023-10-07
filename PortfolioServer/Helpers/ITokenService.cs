using PortfolioServer.Models.Service;

namespace PortfolioServer.Helpers
{
	public interface ITokenService
	{
		string CreateToken(User user, List<Role> roles);
	}
}
