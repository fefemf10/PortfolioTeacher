using Microsoft.AspNetCore.Mvc.Rendering;

namespace IdentityServer.Pages.Account.Register;

public class ViewModel
{
	public List<SelectListItem> FacultyDepartments { get; set; }
	public List<SelectListItem> RolesList { get; set; }
}
