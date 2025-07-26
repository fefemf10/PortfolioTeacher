using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace IdentityServer
{
	public static class Configuration
	{
		public static IEnumerable<Client> Clients =>
        [
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
                AllowedGrantTypes = GrantTypes.Code,
				AllowedScopes =
				{
					IdentityServerConstants.StandardScopes.OpenId,
					IdentityServerConstants.StandardScopes.Profile,
					IdentityServerConstants.LocalApi.ScopeName,
					"PortfolioServer",
				},
				RedirectUris = {
					"http://localhost:4000/authentication/login-callback", "https://pteach.ru/authentication/login-callback", "https://tp6tqkw7-443.euw.devtunnels.ms/authentication/login-callback", "http://localhost/authentication/login-callback",
                    "http://localhost:4000/authentication/silent-callback", "https://pteach.ru/authentication/silent-callback",
                    "http://192.168.1.100/authentication/login-callback"
                },
				PostLogoutRedirectUris = { "http://localhost:4000/authentication/logout-callback", "https://pteach.ru/authentication/logout-callback",
					"https://tp6tqkw7-443.euw.devtunnels.ms/authentication/logout-callback", "http://localhost/authentication/logout-callback",
                    "http://192.168.1.100/authentication/logout-callback" },
				RequireClientSecret = false,
				AllowAccessTokensViaBrowser = true,
			}
		];
		public static IEnumerable<ApiResource> ApiResources =>
        [
            new ApiResource("PortfolioServer")
		];
		public static IEnumerable<IdentityResource> IdentityResources =>
        [
            new IdentityResources.OpenId(),
			new IdentityResources.Profile(),
			new IdentityResources.Email()
		];
		public static IEnumerable<ApiScope> ApiScopes =>
        [
            new ApiScope("PortfolioServer"),
			new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
		];
	}
}
