using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Exceptions;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;

namespace Portfolio.Application.Services.TeacherService
{
    public class TeacherDepartmentService : ITeacherDepartmentService
    {
        private readonly ApplicationContext db;
        public TeacherDepartmentService(ApplicationContext db)
        {
            this.db = db;
        }
        public async Task Update(Guid id, Guid departmentId)
        {
            Teacher? teacher = await db.Teachers.FindAsync(id) ?? throw new NotFoundByIdException();
            Department? department = await db.Departments.FindAsync(id) ?? throw new NotFoundByIdException();
            teacher.DepartmentId = departmentId;
            await db.SaveChangesAsync();
        }
    }
}
