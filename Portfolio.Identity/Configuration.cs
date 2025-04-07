using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace IdentityServer
{
	public static class Configuration
	{
		public static IEnumerable<Client> Clients => new Client[]
		{
			new Client
			{
				ClientId = "m2m",
				ClientSecrets = { new Secret("client_secret".Sha256()) },
				AllowedGrantTypes = GrantTypes.ClientCredentials,
				AllowedScopes =
				{
					IdentityServerConstants.StandardScopes.OpenId,
					IdentityServerConstants.StandardScopes.Profile,
					IdentityServerConstants.LocalApi.ScopeName,
					"PortfolioServer",
				}
			},
			new Client
			{
				ClientId = "PortfolioSite",
                ClientSecrets = { new Secret("client_secret".Sha256()) },
                AllowedGrantTypes = GrantTypes.Code,
				AllowedScopes =
				{
					IdentityServerConstants.StandardScopes.OpenId,
					IdentityServerConstants.StandardScopes.Profile,
					IdentityServerConstants.LocalApi.ScopeName,
					"PortfolioServer",
				},
				RedirectUris = {
					"http://localhost:4000/authentication/login-callback", "http://pteach.ru/authentication/login-callback",
					"http://localhost:4000/authentication/silent-callback", "http://pteach.ru/authentication/silent-callback"  },
				PostLogoutRedirectUris = { "http://localhost:4000/authentication/logout-callback", "http://pteach.ru/authentication/logout-callback" },
				RequireClientSecret = true
			}
		};
		public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
		{
			new ApiResource("PortfolioServer")
		};
		public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
		{
			new IdentityResources.OpenId(),
			new IdentityResources.Profile(),
			new IdentityResources.Email()
		};
		public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
		{
			new ApiScope("PortfolioServer"),
			new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
		};
	}
}
