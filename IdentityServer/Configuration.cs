using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityModel;
using System.Security.Claims;

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
				ClientId = "PortfolioSite",
				ClientSecrets = { new Secret("client_secret".ToSha256()) },
				AllowedGrantTypes = GrantTypes.Code,
				AllowedScopes =
				{
					IdentityServerConstants.StandardScopes.OpenId,
					IdentityServerConstants.StandardScopes.Profile,
					"PortfolioServer",
				},
				RedirectUris = { "https://localhost:4001/authentication/login-callback" },
				PostLogoutRedirectUris = { "https://localhost:4001/authentication/logout-callback" },
				RequireClientSecret = false,
				RequirePkce = true,
				RequireConsent = false,
				AccessTokenLifetime = 3600,
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
					Name = ClaimTypes.Role,
					UserClaims = new List<string> { ClaimTypes.Role }
				},

		};
		public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
		{
			new ApiScope("PortfolioServer")
		};
	}
}
