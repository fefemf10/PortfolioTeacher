using System.ComponentModel.DataAnnotations;

namespace PortfolioShared.ViewModels.Request
{
	public record RequestDepartment([Required] Guid Id, [Required] string Name);
}
