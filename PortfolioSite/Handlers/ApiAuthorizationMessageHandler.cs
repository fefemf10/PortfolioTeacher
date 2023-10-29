using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace PortfolioSite.Handlers
{
	public class ApiAuthorizationMessageHandler : AuthorizationMessageHandler
	{
		private readonly IConfiguration configuration;
		public ApiAuthorizationMessageHandler(IConfiguration configuration, IAccessTokenProvider provider, NavigationManager navigation) : base(provider, navigation)
		{
			this.configuration = configuration;
			ConfigureHandler(new[] { configuration["PortfolioServer:Url"]! }, new[] { configuration["PortfolioServer:Scope"]! });
		}
	}
}
