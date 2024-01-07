using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PortfolioShared.Models;
using PortfolioShared.ViewModels.Request;
using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Controllers
{
	[Authorize(Roles = nameof(Roles.Administrator))]
	[Route("[controller]/[action]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly ApplicationContext db;
		private readonly SignInManager<IdentityUser<Guid>> signInManager;
		private readonly UserManager<IdentityUser<Guid>> userManager;
		private readonly IHubContext<RegistrationHub> hubContext;
		public UserController(ApplicationContext db, SignInManager<IdentityUser<Guid>> signInManager, UserManager<IdentityUser<Guid>> userManager, IHubContext<RegistrationHub> hubContext)
		{
			this.db = db;
			this.signInManager = signInManager;
			this.userManager = userManager;
			this.hubContext = hubContext;
		}
		[HttpPost]
		public async Task<ActionResult> Add([Required][FromBody] RequestAddUser requestAddUser)
		{
			var user = new IdentityUser<Guid>()
			{
				UserName = requestAddUser.Email,
				Email = requestAddUser.Email,
				EmailConfirmed = true
			};

			var result = await userManager.CreateAsync(user, requestAddUser.Password);

			if (result.Succeeded)
			{
				await userManager.AddToRoleAsync(user, requestAddUser.Role);
				await hubContext.Clients.All.SendAsync("Receive2", user.Id, user.Email, requestAddUser.DepartmentId, Enum.Parse<Roles>(requestAddUser.Role));
			}
			return Ok();
		}
	}
}
