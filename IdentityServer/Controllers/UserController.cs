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
		[HttpPost]
		public async Task<ActionResult> AddTestUsers()
		{
			HttpClient httpClient = httpClientFactory.CreateClient("PortfolioServer");
			List<RequestFacultyDepartment> requestFacultyDepartments = await httpClient.GetFromJsonAsync<List<RequestFacultyDepartment>>($"Faculty/GetWithDepartment");
			List<RequestDepartment> requestDepartments = await httpClient.GetFromJsonAsync<List<RequestDepartment>>("Department/Get");
			List<RequestAddTeacher> listAddTeachers = [];

            int countDean = 5;
			int countDeputy = 25;
			for (int i = 0; i < countDean; i++)
			{
				string Email = GenerateEmail("Dean", i);

				Guid facultyId = requestFacultyDepartments[i].Id;
				Guid? departmentId = null;
				if (Random.Shared.Next() % 2 == 0)
				{
					var f = requestFacultyDepartments.Find(x => x.Id == facultyId);
					departmentId = f.Departments[Random.Shared.Next() % f.Departments.Count].Id;
				}

				var user = new IdentityUser<Guid>()
				{
					UserName = Email,
					Email = Email,
					EmailConfirmed = true
				};

				var result = await userManager.CreateAsync(user, "12345");

				if (result.Succeeded)
				{
					if (await roleManager.RoleExistsAsync(Roles.Dean.ToString()))
					{
						await userManager.AddToRoleAsync(user, Roles.Dean.ToString());
                        listAddTeachers.Add(new RequestAddTeacher() { Id = user.Id, Email = user.Email, Role = Roles.Dean.ToString(), FacultyId = facultyId, DepartmentId = departmentId });
					}
				}
				else
				{
					return BadRequest();
				}
			}
			for (int i = 0; i < countDeputy; i++)
			{
				string Email = GenerateEmail("Deputy", i);

				Guid departmentId = requestDepartments[i].Id;
				Guid facultyId = Guid.NewGuid();
				foreach (var faculty in requestFacultyDepartments)
				{
					var department = faculty.Departments.FirstOrDefault(y => y.Id == departmentId);
					if (department is not null)
					{
						facultyId = faculty.Id;
						break;
					}
				}
				var user = new IdentityUser<Guid>()
				{
					UserName = Email,
					Email = Email,
					EmailConfirmed = true
				};

				var result = await userManager.CreateAsync(user, "12345");

				if (result.Succeeded)
				{
					if (await roleManager.RoleExistsAsync(Roles.Deputy.ToString()))
					{
						await userManager.AddToRoleAsync(user, Roles.Deputy.ToString());
                        listAddTeachers.Add(new RequestAddTeacher() { Id = user.Id, Email = user.Email, Role = Roles.Deputy.ToString(), FacultyId = facultyId, DepartmentId = departmentId });
					}
				}
				else
				{
					return BadRequest();
				}
			}
			for (int i = 0; i < 1000; i++)
			{
				string Email = GenerateEmail("Teacher", i);

				Guid departmentId = requestDepartments[Random.Shared.Next() % 25].Id;
				Guid facultyId = Guid.NewGuid();
				foreach (var faculty in requestFacultyDepartments)
				{
					var department = faculty.Departments.FirstOrDefault(y => y.Id == departmentId);
					if (department is not null)
					{
						facultyId = faculty.Id;
						break;
					}
				}
				var user = new IdentityUser<Guid>()
				{
					UserName = Email,
					Email = Email,
					EmailConfirmed = true
				};

				var result = await userManager.CreateAsync(user, "12345");

				if (result.Succeeded)
				{
					if (await roleManager.RoleExistsAsync(Roles.Teacher.ToString()))
					{
						await userManager.AddToRoleAsync(user, Roles.Teacher.ToString());
                        listAddTeachers.Add(new RequestAddTeacher() { Id = user.Id, Email = user.Email, Role = Roles.Teacher.ToString(), FacultyId = facultyId, DepartmentId = departmentId });
					}
				}
				else
				{
					return BadRequest();
				}
			}
			JsonContent js = JsonContent.Create(listAddTeachers);
            HttpResponseMessage httpResponse = await httpClient.PostAsync("Teacher/AddTestTeacher", js);
            if (!httpResponse.IsSuccessStatusCode)
            {
				foreach (var user in listAddTeachers)
				{
					var identity = new IdentityUser<Guid>()
					{
						UserName = user.Email,
						Email = user.Email,
						EmailConfirmed = true
					};
					await userManager.DeleteAsync(identity);
				}
                return BadRequest();
            }
            return Ok();
		}

		private string GenerateEmail(string prefix, int number)
		{
			return prefix + number.ToString() + "@yandex.ru";
		}

	}
}
