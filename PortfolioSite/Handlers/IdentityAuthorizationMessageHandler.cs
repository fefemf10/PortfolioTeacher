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
			List<string> scopes = new();
			configuration.Bind("IdentityServer:Scopes", scopes);
			ConfigureHandler(new[] { configuration["IdentityServer:Url"]! }, scopes);
		}
	}
}
