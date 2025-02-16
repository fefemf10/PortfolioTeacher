using Microsoft.AspNetCore.Mvc.Rendering;
using Portfolio.Domain.Models;

namespace IdentityServer.Pages.Account.Register;

public class ViewModel
{
	public List<string> RolesList { get; set; } = new List<string>() { Roles.Teacher.ToString(), Roles.Student.ToString() };
	public List<SelectListItem> FacultyDepartments { get; set; }
}
