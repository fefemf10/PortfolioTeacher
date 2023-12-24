using PortfolioShared.Models;

namespace IdentityServer.Pages.Account.Register;

public class ViewModel
{
	public List<string> RolesList { get; set; } = new List<string>() { Roles.Teacher.ToString(), Roles.Student.ToString() };
}
