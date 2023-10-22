using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PortfolioShared.Helpers;
using PortfolioShared.Models.Service;
using PortfolioShared.ViewModels.Request;
using PortfolioShared.ViewModels.Response;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace PortfolioShared.Cotrollers.Service
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
		private readonly ApplicationContext db;
		private readonly UserManager<User> userManager;
		private readonly RoleManager<Role> roleManager;
		private readonly ITokenService tokenService;
		private readonly IConfiguration configuration;
		public AuthController(ApplicationContext db, ITokenService tokenService, UserManager<User> userManager, RoleManager<Role> roleManager, IConfiguration configuration)
		{
			this.db = db;
			this.tokenService = tokenService;
			this.userManager = userManager;
			this.roleManager = roleManager;
			this.configuration = configuration;
		}
		[HttpPost("registration")]
        public async Task<ActionResult<ResponseUser>> RegistrationAsync([FromBody] RequestRegistration requestRegistration)
        {
			User managedUser = new User() { Id = Guid.NewGuid(), UserName = requestRegistration.Email, Email = requestRegistration.Email };
			var result = await userManager.CreateAsync(managedUser, requestRegistration.Password!);
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError(string.Empty, error.Description);
			}
			if (!result.Succeeded) return BadRequest();
			await userManager.AddToRoleAsync(managedUser, requestRegistration.Teacher!.Value ? "Teacher" : "Student");
			return await Login(new RequestLogin() { Email = requestRegistration.Email, Password = requestRegistration.Password });
        }
		[HttpPost("login")]
		public async Task<ActionResult<ResponseUser>> Login([FromBody] RequestLogin requestLogin)
		{
			User? user = await userManager.FindByEmailAsync(requestLogin.Email!);
			if (user is null)
				return BadRequest("Bad credentials");
			bool isPasswordValid = await userManager.CheckPasswordAsync(user, requestLogin.Password!);
            if (!isPasswordValid)
				return BadRequest("Bad credentials");
			
			var roleIds = await db.UserRoles.Where(role => role.UserId == user.Id).Select(identityUserRole => identityUserRole.RoleId).ToListAsync();
			var roles = db.Roles.Where(role => roleIds.Contains(role.Id)).ToList();

			string accessToken = tokenService.CreateToken(user, roles);
			user.RefreshToken = configuration.GenerateRefreshToken();
			user.RefreshTokenExpityTime = DateTimeOffset.Now.AddMinutes(AuthOptions.RefreshTokenLifeTime);
			await userManager.UpdateAsync(user);
			return Ok(new ResponseUser(user.Id, user.Email!, accessToken, user.RefreshToken));
		}
		[HttpPost("refreshToken")]
		public async Task<ActionResult<AuthTokens>> RefreshToken([FromBody] AuthTokens tokens)
		{
			if (tokens is null)
				return BadRequest("Invalid client request");
			var principal = configuration.GetPrincipalFromExpiredToken(tokens.AccessToken);
			if (principal is null)
				return BadRequest("Invalid access token or refresh token");

			var id = principal.Identity!.Name;
			User? user = await userManager.FindByIdAsync(id);
			
			if (user is null || user.RefreshToken != tokens.RefreshToken || user.RefreshTokenExpityTime <= DateTimeOffset.Now)
				return BadRequest("Invalid access token or refresh token");

			var newAccessToken = configuration.CreateToken(principal.Claims.ToList());
			var newRefreshToken = configuration.GenerateRefreshToken(); 
			
			user.RefreshToken = newRefreshToken;
			await userManager.UpdateAsync(user);

			return new AuthTokens(new JwtSecurityTokenHandler().WriteToken(newAccessToken), newRefreshToken); ; 
		}
		[Authorize]
		[HttpPost("revokeToken")]
		public async Task<ActionResult<string>> RevokeToken([FromBody] Guid Guid)
		{
			User? user = await userManager.FindByIdAsync(Guid.ToString());
			if (user is null)
				return BadRequest("Invalid GUID");
			user.RefreshToken = null;
			await userManager.UpdateAsync(user);
			return Ok();
		}
		[Authorize]
		[HttpGet]
		public ActionResult Test()
		{
			return Ok();
		}
	}
}
