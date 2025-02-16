using System.ComponentModel.DataAnnotations;

namespace Portfolio.Application.ViewModels.Request
{
    public record RequestAddDiscipline([Required] string Name);
    public record RequestUpdateDiscipline([Required] Guid Id, [Required] string Name);
}
