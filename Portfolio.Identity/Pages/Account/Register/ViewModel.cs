using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Portfolio.Domain.Models;

namespace IdentityServer.Pages.Account.Register;

public class ViewModel
{
	public List<SelectListItem> FacultyDepartments { get; set; }
	public List<SelectListItem> RolesList { get; set; }
}
