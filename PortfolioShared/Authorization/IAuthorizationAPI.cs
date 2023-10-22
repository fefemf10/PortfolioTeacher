using PortfolioShared.Models.Service;
using PortfolioShared.ViewModels.Request;
using PortfolioShared.ViewModels.Response;

namespace PortfolioShared.Authorization
{
	public interface IAuthorizationAPI
	{
		Task<ResponseLogin> Login(RequestLogin requestLogin);
		Task<ResponseRegistration> Register(RequestRegistration requestRegistration);
		Task Logout();
		Task<User> GetUserInfo();
	}
}
