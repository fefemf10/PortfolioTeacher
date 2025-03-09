namespace Portfolio.Domain.Services
{
    public interface ITeacherDepartmentService
    {
        Task Update(Guid id, Guid departmentId);
    }
}
