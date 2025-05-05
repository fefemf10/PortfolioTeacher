using Portfolio.Domain.Models;

namespace Portfolio.Application.ViewModels.Request
{
    public record RequestPost(PostType PostType, Guid DepartmentId);
}
