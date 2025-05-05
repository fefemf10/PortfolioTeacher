using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Domain.Models;
using System.ComponentModel.DataAnnotations;
using static Duende.IdentityServer.IdentityServerConstants;

namespace IdentityServer.Controllers
{
    public class RequestAddTeacher
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        [Required]
        public byte Gender { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
    }
    [Authorize(LocalApi.PolicyName, Roles = nameof(Roles.Administrator))]
	[Route("api/[controller]")]
	[ApiController]
	public class UserController(
		UserManager<IdentityUser<Guid>> userManager,
		RoleManager<IdentityRole<Guid>> roleManager,
		IHttpClientFactory httpClientFactory) : ControllerBase
	{
		string[] fio;
        List<RequestAddTeacher> listUsers = [];
        //List<RequestAddTeacher> listAddTeachers = [];
        //List<ResponseFacultyDepartments> requestFacultyDepartments;
        //      [HttpPost]
        //public async Task<ActionResult> Add([Required][FromBody] RequestAddUser requestAddUser)
        //{
        //	HttpClient httpClient = httpClientFactory.CreateClient("PortfolioServer");
        //	{
        //		var usersInRole = await userManager.GetUsersInRoleAsync(requestAddUser.Role.ToString());
        //		if (requestAddUser.Role == Roles.Dean)
        //		{
        //			foreach (var userInRole in usersInRole)
        //			{
        //				ResponseTeacher? responseTeacher = await httpClient.GetFromJsonAsync<ResponseTeacher>($"api/Teacher/{userInRole.Id}/GetInfo");
        //				if (requestAddUser.ParentDepartmentId == responseTeacher.Faculty.Id)
        //					return BadRequest();
        //			}
        //		}
        //		else if (requestAddUser.Role == Roles.Deputy)
        //		{
        //			foreach (var userInRole in usersInRole)
        //			{
        //				List<ResponseTeacher>? responseTeachers = await httpClient.GetFromJsonAsync<List<ResponseTeacher>>($"api/Department/{requestAddUser.DepartmentId}/GetTeacher");
        //				if (responseTeachers.SingleOrDefault(x => x.Id == userInRole.Id) != null)
        //					return BadRequest();
        //			}
        //		}
        //	}
        //	if (await roleManager.RoleExistsAsync(requestAddUser.Role.ToString()))
        //	{
        //		var user = new IdentityUser<Guid>()
        //		{
        //			UserName = requestAddUser.Email,
        //			Email = requestAddUser.Email,
        //			EmailConfirmed = true
        //		};

        //		var result = await userManager.CreateAsync(user, requestAddUser.Password);
        //		if (result.Succeeded)
        //		{
        //			await userManager.AddToRoleAsync(user, requestAddUser.Role.ToString());
        //			HttpResponseMessage httpResponse = await httpClient.PostAsJsonAsync("api/Teacher", new RequestAddTeacher() { Id = user.Id, Email = user.Email, FirstName = requestAddUser.FirstName, LastName = requestAddUser.LastName, MiddleName = requestAddUser.MiddleName, Role = requestAddUser.Role, ParentDepartmentId = requestAddUser.ParentDepartmentId, DepartmentId = requestAddUser.DepartmentId });
        //			if (httpResponse.IsSuccessStatusCode)
        //				return Ok();
        //		}
        //		await userManager.DeleteAsync(user);
        //	}
        //	return BadRequest();
        //}
        [HttpDelete]
        public async Task<ActionResult> DeleteTestUsers(List<RequestAddTeacher> requestAddTeachers)
		{
			foreach (var teacher in requestAddTeachers)
			{
				await userManager.DeleteAsync(await userManager.FindByEmailAsync(teacher.Email));
			}
            return Ok();
		}
		[HttpPost]
		public async Task<ActionResult<List<RequestAddTeacher>>> AddTestUsers()
		{
			fio ??= [.. System.IO.File.ReadAllLines("SeedData/FIO.txt")];
			await GenerateDeans(5);
			await GenerateDeputy(10);
			await GenerateTeachers(10);
			return Ok(listUsers);
		}
		private async Task GenerateDeans(int count)
		{
            for (int i = 0; i < count; i++)
            {
                string email = GenerateEmail("Dean", i);
                await AddUser(email, Roles.Dean);
            }
        }
		private async Task GenerateDeputy(int count)
		{
			for (int i = 0; i < count; i++)
			{
				string email = GenerateEmail("Deputy", i);
				await AddUser(email, Roles.Deputy);
			}
		}
		private async Task GenerateTeachers(int count)
		{
			for (int i = 0; i < count; i++)
			{
				string email = GenerateEmail("Teacher", i);
				await AddUser(email, Roles.Teacher);
			}
		}
		private async Task AddUser(string email, Roles role)
		{
			var name = GetName(fio[Random.Shared.Next() % fio.Length]);
			var user = new IdentityUser<Guid>()
			{
				Id = Guid.NewGuid(),
				UserName = email,
				Email = email,
				EmailConfirmed = true
			};
			var result = await userManager.CreateAsync(user, "12345");
			if (result.Succeeded)
			{
				await userManager.AddToRoleAsync(user, role.ToString());
				listUsers.Add(new RequestAddTeacher{ Id = user.Id, Email = user.Email, LastName = name.Item1, FirstName = name.Item2, MiddleName = name.Item3, Gender = 0, Phone = "+79598765432" });
			}
		}
		private static string GenerateEmail(string prefix, int number) => prefix + number.ToString() + "@yandex.ru";
		private static (string, string, string) GetName(string value)
		{
			var splited = value.Split(' ');
			return (splited[0], splited[1], splited[2]);
		}
	}
}
