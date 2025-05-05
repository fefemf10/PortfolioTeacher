using Portfolio.Domain.Models;

namespace Portfolio.Domain.Services
{
    public interface IDepartmentService
    {
        Task<Guid> Add(Department department);
        Task DeleteById(Guid id);
        Task<IEnumerable<Department>> GetAll();
        Task<IEnumerable<Department>> GetAllRecursive();
        Task<Department> GetById(Guid id);
        Task<Department> GetByIdRecursive(Guid id);
        Task<List<Guid>> GetDepartmentIdsByType(DepartmentType departmentType);
        Task<IEnumerable<Guid>> GetUserIds(Guid departmentId);
        Task<IEnumerable<User>> GetUsers(Guid departmentId);
        Task<IEnumerable<Guid>> GetTeachersIds(Guid departmentId);
        Task<IEnumerable<Teacher>> GetTeachers(Guid departmentId);
        Task Update(Department department);
    }
}