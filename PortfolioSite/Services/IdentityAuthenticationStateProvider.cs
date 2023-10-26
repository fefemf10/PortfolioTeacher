using Microsoft.AspNetCore.Components.Authorization;
using PortfolioShared.ViewModels.Request;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using PortfolioShared.Authorization;
using PortfolioShared.Models.Service;
using PortfolioShared.ViewModels.Response;

namespace PortfolioSite.Services
{
	public class IdentityAuthenticationStateProvider : AuthenticationStateProvider
	{
		private ResponseUser user;
		private readonly IAuthorizationAPI authorizationAPI;

		public IdentityAuthenticationStateProvider(IAuthorizationAPI authorizationAPI)
		{
			this.authorizationAPI = authorizationAPI;
		}

		public async Task Login(RequestLogin requestLogin)
		{
			Task<ResponseLogin> _ = authorizationAPI.Login(requestLogin);
			_.Wait();
			ResponseLogin responseLogin = _.Result;
			user = new ResponseUser(responseLogin.Guid, responseLogin.Email, responseLogin.AccessToken, responseLogin.RefreshToken, true);
			NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
		}

		public async Task<ResponseRegistration> Register(RequestRegistration requestRegistration)
		{
			await authorizationAPI.Register(requestRegistration);
			NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
			return new ResponseRegistration(Guid.NewGuid(), "", "", "");
		}

		public async Task Logout()
		{
			await authorizationAPI.Logout();
			user = null;
			NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
		}

		private async Task<ResponseUser> GetUserInfo()
		{
			if (user is not null) return user;
			user = await authorizationAPI.GetUserInfo();
			return user;
		}

		public override async Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			var identity = new ClaimsIdentity();
			try
			{
				var userInfo = await GetUserInfo();
				if (userInfo.IsAuthenticated)
				{
					//var claims = new[] { new Claim(ClaimTypes.Name, userInfo.UserName) }.Concat(userInfo.ExposedClaims.Select(c => new Claim(c.Key, c.Value)));
					//identity = new ClaimsIdentity(claims, "Server authentication");
				}
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine("Request failed:" + ex.ToString());
			}

			return new AuthenticationState(new ClaimsPrincipal(identity));
		}
	}
}
