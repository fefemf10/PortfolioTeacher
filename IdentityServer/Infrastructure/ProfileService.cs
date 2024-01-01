using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace IdentityServer.Infrastructure
{
	public class ProfileService : IProfileService
	{
		private readonly UserManager<IdentityUser<Guid>> userManager;
		public ProfileService(UserManager<IdentityUser<Guid>> userManager)
		{
			this.userManager = userManager;
		}
		public virtual async Task GetProfileDataAsync(ProfileDataRequestContext context)
		{
            IdentityUser<Guid>? user = await userManager.GetUserAsync(context.Subject);
            IList<string> roles = await userManager.GetRolesAsync(user!);
            IEnumerable<Claim> requestedClaims = new Claim[]
			{
				new Claim(JwtClaimTypes.Role, roles.First())
			};
			context.IssuedClaims.AddRange(requestedClaims);
		}
		public async Task IsActiveAsync(IsActiveContext context)
		{
			var user = await userManager.GetUserAsync(context.Subject);
			context.IsActive = user is not null;
		}
	}
}
