using System.ComponentModel.DataAnnotations;

namespace Portfolio.Application.ViewModels.Request
{
	public record RequestAddDepartment([Required] string Name, [Required] Guid FaculyId);
	public record RequestUpdateDepartment([Required] Guid Id, [Required] string Name, [Required] Guid FaculyId);
}
