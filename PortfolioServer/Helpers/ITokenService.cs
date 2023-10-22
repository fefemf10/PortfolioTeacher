using PortfolioShared.Models.Service;

namespace PortfolioShared.Helpers
{
	public interface ITokenService
	{
		string CreateToken(User user, List<Role> roles);
	}
}
