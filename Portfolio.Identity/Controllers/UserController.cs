using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Domain.Models;
using static Duende.IdentityServer.IdentityServerConstants;

namespace IdentityServer.Controllers
{
	[Authorize(LocalApi.PolicyName, Roles = nameof(Roles.Administrator))]
	[Route("api/[controller]")]
	[ApiController]
	public class UserController(
		UserManager<IdentityUser<Guid>> userManager,
		RoleManager<IdentityRole<Guid>> roleManager,
		IHttpClientFactory httpClientFactory) : ControllerBase
	{
		string[] fio;
        List<IdentityUser<Guid>> listUsers = [];
  //      List<RequestAddTeacher> listAddTeachers = [];
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
		//				if (requestAddUser.FacultyId == responseTeacher.Faculty.Id)
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
		//			HttpResponseMessage httpResponse = await httpClient.PostAsJsonAsync("api/Teacher", new RequestAddTeacher() { Id = user.Id, Email = user.Email, FirstName = requestAddUser.FirstName, LastName = requestAddUser.LastName, MiddleName = requestAddUser.MiddleName, Role = requestAddUser.Role, FacultyId = requestAddUser.FacultyId, DepartmentId = requestAddUser.DepartmentId });
		//			if (httpResponse.IsSuccessStatusCode)
		//				return Ok();
		//		}
		//		await userManager.DeleteAsync(user);
		//	}
		//	return BadRequest();
		//}
		//[HttpPost]
		//public async Task<ActionResult> AddTestUsers()
		//{
  //          fio ??= [.. System.IO.File.ReadAllLines("SeedData/FIO.txt")];
  //          HttpClient httpClient = httpClientFactory.CreateClient("PortfolioServer");
		//	requestFacultyDepartments = await httpClient.GetFromJsonAsync<List<ResponseFacultyDepartments>>($"api/Faculty/departments");
		//	await GenerateDeans();
		//	await GenerateDeputy();
		//	await GenerateTeachers(10);
		//	HttpResponseMessage httpResponse = await httpClient.PostAsJsonAsync($"api/Admin/test-users", listAddTeachers);
		//	if (!httpResponse.IsSuccessStatusCode)
		//	{
		//		foreach (var user in listUsers)
		//			await userManager.DeleteAsync(user);
		//		return BadRequest();
		//	}
		//	return Ok();
		//}
		//private async Task GenerateDeans()
		//{
  //          for (int i = 0; i < requestFacultyDepartments.Count; i++)
  //          {
  //              string email = GenerateEmail("Dean", i);
  //              Guid facultyId = requestFacultyDepartments[i].Id;
  //              //Guid departmentId = requestFacultyDepartments[i].Departments[Random.Shared.Next() % requestFacultyDepartments[i].Departments.Count].Id;
		//		await AddUser(email, Roles.Dean, facultyId, null);
  //          }
  //      }
		//private async Task GenerateDeputy()
		//{
  //          for (int i = 0; i < requestFacultyDepartments.Count; i++)
  //          {
  //              Guid facultyId = requestFacultyDepartments[i].Id;
  //              for (int j = 0; j < requestFacultyDepartments[i].Departments.Count; j++)
		//		{
		//			string email = GenerateEmail("Deputy", j);
		//			Guid departmentId = requestFacultyDepartments[i].Departments[j].Id;
  //                  await AddUser(email, Roles.Deputy, facultyId, departmentId);
  //              }
  //          }
  //      }
		//private async Task GenerateTeachers(int count)
		//{
		//	int countFaculty = requestFacultyDepartments.Count;
		//	int[] countDepartment = new int[countFaculty];
		//	for (int i = 0; i < countFaculty; i++)
		//		countDepartment[i] = requestFacultyDepartments[i].Departments.Count;
  //          for (int i = 0; i < count; i++)
  //          {
  //              string email = GenerateEmail("Teacher", i);
		//		int idFaculty = Random.Shared.Next() % countFaculty;
		//		int idDepartment = Random.Shared.Next() % countDepartment[idFaculty];
  //              Guid facultyId = requestFacultyDepartments[idFaculty].Id;
  //              Guid departmentId = requestFacultyDepartments[idFaculty].Departments[idDepartment].Id;
  //              await AddUser(email, Roles.Deputy, facultyId, departmentId);
  //          }
  //      }
		//private async Task AddUser(string email, Roles role, Guid facultyId, Guid? departmentId)
		//{
  //          var name = GetName(fio[Random.Shared.Next() % fio.Length]);
  //          var user = new IdentityUser<Guid>()
  //          {
		//		Id = Guid.NewGuid(),
  //              UserName = email,
  //              Email = email,
  //              EmailConfirmed = true
  //          };
  //          var result = await userManager.CreateAsync(user, "12345");
		//	if (result.Succeeded)
		//	{
		//		await userManager.AddToRoleAsync(user, role.ToString());
		//		listUsers.Add(user);
		//		listAddTeachers.Add(new RequestAddTeacher() { Id = user.Id, Email = user.Email, FirstName = name.Item2, LastName = name.Item1, MiddleName = name.Item3, Phone = "+79999999999", Role = role, FacultyId = facultyId, DepartmentId = departmentId });
		//	}
		//}
		//private static string GenerateEmail(string prefix, int number) => prefix + number.ToString() + "@yandex.ru";
  //      private static (string, string, string) GetName(string value)
  //      {
  //          var splited = value.Split(' ');
  //          return (splited[0], splited[1], splited[2]);
  //      }
    }
}
