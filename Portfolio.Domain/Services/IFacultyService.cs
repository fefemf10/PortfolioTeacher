using Portfolio.Domain.Models;

namespace Portfolio.Domain.Services
{
    public interface IFacultyService
    {
        Task<Guid> Add(Faculty faculty);
        Task DeleteById(Guid id);
        Task<IEnumerable<Faculty>> GetAll();
        Task<IEnumerable<Faculty>> GetAllWithDepartments();
        Task<Faculty> GetById(Guid id);
        Task<Faculty> GetByIdWithDepartments(Guid id);
        Task<IEnumerable<Guid>> GetTeachers(Guid id);
        Task Update(Faculty faculty);
    }
}