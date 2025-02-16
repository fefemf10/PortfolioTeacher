using Portfolio.Domain.Models;

namespace Portfolio.Domain.Services
{
    public interface IDepartmentService
    {
        Task<Guid> Add(Department department);
        Task DeleteById(Guid id);
        Task<IEnumerable<Department>> GetAll();
        Task<Department> GetById(Guid id);
        Task<IEnumerable<Guid>> GetTeachers(Guid id);
        Task Update(Department department);
    }
}