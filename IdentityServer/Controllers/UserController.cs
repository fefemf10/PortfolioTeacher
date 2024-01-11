using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PortfolioShared.Models;
using PortfolioShared.ViewModels.Request;
using PortfolioShared.ViewModels.Response;
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
		private readonly UserManager<IdentityUser<Guid>> userManager;
		private readonly RoleManager<IdentityRole<Guid>> roleManager;
		private readonly IHttpClientFactory httpClientFactory;
		public UserController(UserManager<IdentityUser<Guid>> userManager, RoleManager<IdentityRole<Guid>> roleManager, IHttpClientFactory httpClientFactory)
		{
			this.userManager = userManager;
			this.roleManager = roleManager;
			this.httpClientFactory = httpClientFactory;
		}
		[HttpPost]
		public async Task<ActionResult> Add([Required][FromBody] RequestAddUser requestAddUser)
		{
			if (requestAddUser.Role == Roles.Dean.ToString())
			{
				HttpClient httpClient = httpClientFactory.CreateClient("PortfolioServer");
				var usersInRole = await userManager.GetUsersInRoleAsync(requestAddUser.Role);
				foreach (var userInRole in usersInRole)
				{
					ResponseTeacher? responseTeacher = await httpClient.GetFromJsonAsync<ResponseTeacher>($"Teacher/{userInRole.Id}/GetInfo");
					if (requestAddUser.FacultyId == responseTeacher.Faculty.Id)
						return BadRequest();
				}
			}
			else if (requestAddUser.Role == Roles.Deputy.ToString() && requestAddUser.DepartmentId.HasValue)
			{
				HttpClient httpClient = httpClientFactory.CreateClient("PortfolioServer");
				var usersInRole = await userManager.GetUsersInRoleAsync(requestAddUser.Role);
				foreach (var userInRole in usersInRole)
				{
					List<ResponseTeacher>? responseTeachers = await httpClient.GetFromJsonAsync<List<ResponseTeacher>>($"Department/{requestAddUser.DepartmentId}/GetTeacher");
					if (responseTeachers.SingleOrDefault(x => x.Id == userInRole.Id) != null)
						return BadRequest();
				}
			}
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
					JsonContent js = JsonContent.Create(new RequestAddTeacher() { Id = user.Id, Email = user.Email, Role = requestAddUser.Role, FacultyId = requestAddUser.FacultyId, DepartmentId = requestAddUser.DepartmentId });
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
