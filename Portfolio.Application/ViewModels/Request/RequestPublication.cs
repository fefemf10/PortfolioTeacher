using Portfolio.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Application.ViewModels.Request
{
    public record RequestDissertation([Required] string Topic, [Required] string Specialization, [Required] int YearProtection, [Required] DissertationType Type);
    public record RequestPublication([Required] string Name, [Required] int YearPublication, List<Guid> CoAuthors, List<Guid> Files);
    public record RequestMonography([Required] string Name, [Required] int YearPublication, List<Guid> CoAuthors, List<Guid> Files, string? Publisher, [Required] int Сirculation, [Required] int CountPages) : RequestPublication(Name, YearPublication, CoAuthors, Files);
    public record RequestArticle([Required] string Name, [Required] int YearPublication, List<Guid> CoAuthors, List<Guid> Files, string? Journal, [Required] int IssueNumber, [Required] int PrintedSheets, [Required] int BeginPage, [Required] int EndPage, string? URL) : RequestPublication(Name, YearPublication, CoAuthors, Files);
    public record RequestThesis([Required] string Name, [Required] int YearPublication, List<Guid> CoAuthors, List<Guid> Files, [Required] string Type, [Required] string Collection, [Required] int BeginPage, [Required] int EndPage, [Required] string Place, [Required] DateOnly DateEvent, [Required] int CountPages) : RequestPublication(Name, YearPublication, CoAuthors, Files);
}
