using Portfolio.Domain.Models;

namespace Portfolio.Domain.Services
{
    public interface IAdminService
    {
        public Task AddTestUsers(List<Teacher> requestAddTeachers);
    }
}
