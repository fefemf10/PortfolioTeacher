using Microsoft.AspNetCore.Mvc.Rendering;
using PortfolioShared.Models;
using PortfolioShared.ViewModels.Request;

namespace IdentityServer.Pages.Account.Register;

public class ViewModel
{
	public List<string> RolesList { get; set; } = new List<string>() { Roles.Teacher.ToString(), Roles.Student.ToString() };
	public List<SelectListItem> FacultyDepartments { get; set; }
}
