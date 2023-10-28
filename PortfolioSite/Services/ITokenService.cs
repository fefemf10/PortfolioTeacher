using IdentityModel.Client;

namespace PortfolioSite.Services
{
	public interface ITokenService
	{
		Task<TokenResponse> GetToken(string scope);
	}
}
