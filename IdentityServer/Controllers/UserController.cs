using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PortfolioShared.Models;
using PortfolioShared.ViewModels.Request;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using static Duende.IdentityServer.IdentityServerConstants;

namespace IdentityServer.Controllers
{
	[Authorize(LocalApi.PolicyName, Roles = nameof(Roles.Administrator))]
	[Route("[controller]/[action]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly ApplicationContext db;
		private readonly UserManager<IdentityUser<Guid>> userManager;
		private readonly RoleManager<IdentityRole<Guid>> roleManager;
		private readonly IHttpClientFactory httpClientFactory;
		public UserController(ApplicationContext db, UserManager<IdentityUser<Guid>> userManager, RoleManager<IdentityRole<Guid>> roleManager, IHttpClientFactory httpClientFactory)
		{
			this.db = db;
			this.userManager = userManager;
			this.roleManager = roleManager;
			this.httpClientFactory = httpClientFactory;
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
				if (await roleManager.RoleExistsAsync(requestAddUser.Role))
				{
					await userManager.AddToRoleAsync(user, requestAddUser.Role);
					HttpClient httpClient = httpClientFactory.CreateClient("PortfolioServer");
					JsonContent js = JsonContent.Create(new RequestAddTeacher() { Id = user.Id, Email = user.Email, Role = requestAddUser.Role, DepartmentId = requestAddUser.DepartmentId });
					HttpResponseMessage httpResponse = await httpClient.PostAsync("Teacher/AddTeacher", js);
					if (httpResponse.IsSuccessStatusCode)
						return Ok();
				}
				await userManager.DeleteAsync(user);
			}
			return BadRequest();
		}
	}
}
