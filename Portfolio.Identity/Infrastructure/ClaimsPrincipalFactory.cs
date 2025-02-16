using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace IdentityServer.Infrastructure
{
	public class ClaimsPrincipalFactory : UserClaimsPrincipalFactory<IdentityUser<Guid>>
	{
		public ClaimsPrincipalFactory(UserManager<IdentityUser<Guid>> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
		{

		}
		protected override async Task<ClaimsIdentity> GenerateClaimsAsync(IdentityUser<Guid> user)
		{
			IList<string> roles = await UserManager.GetRolesAsync(user);
			var identity = await base.GenerateClaimsAsync(user);
			identity.AddClaim(new Claim(JwtClaimTypes.Role, roles.First()));
			return identity;
		}
	}
}
