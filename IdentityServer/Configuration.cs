using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace IdentityServer
{
	public static class Configuration
	{
		public static IEnumerable<Client> Clients => new Client[]
		{
			new Client
			{
				ClientId = "m2m",
				ClientSecrets = { new Secret("client_secret".ToSha256()) },
				AllowedGrantTypes = GrantTypes.ClientCredentials,
				AllowedScopes =
				{
					IdentityServerConstants.StandardScopes.OpenId,
					IdentityServerConstants.StandardScopes.Profile,
					"PortfolioServer",
				}
			},
			new Client
			{
				ClientId = "interactive",
				ClientSecrets = { new Secret("client_secret".ToSha256()) },
				AllowedGrantTypes = GrantTypes.Code,
				AllowedScopes =
				{
					IdentityServerConstants.StandardScopes.OpenId,
					IdentityServerConstants.StandardScopes.Profile,
					"PortfolioServer",
				},
				RedirectUris = {"https://localhost:2001/signin-oidc"},
				PostLogoutRedirectUris = {"https://localhost:2001/signout-callback-oidc"},

				RequireConsent = false,

				AccessTokenLifetime = 5,

				AllowOfflineAccess = true
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
			new IdentityResource
				{
					Name = "role",
					UserClaims = new List<string> { "role" }
				},

		};
		public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
		{
			new ApiScope("PortfolioServer")
		};
	}
}
