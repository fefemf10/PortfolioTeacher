using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace PortfolioSite.Handlers
{
	public class IdentityAuthorizationMessageHandler : AuthorizationMessageHandler
	{
		private readonly IConfiguration configuration;
		public IdentityAuthorizationMessageHandler(IConfiguration configuration, IAccessTokenProvider provider, NavigationManager navigation) : base(provider, navigation)
		{
			this.configuration = configuration;
			ConfigureHandler(new[] { configuration["IdentityServer:Url"]! }, new[] { configuration["IdentityServer:Scope"]! });
		}
	}
}
