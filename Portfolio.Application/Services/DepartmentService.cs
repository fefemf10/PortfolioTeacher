using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Exceptions;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;
using Portfolio.Infrastructure;

namespace Portfolio.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationContext db;

        public DepartmentService(ApplicationContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<Department>> GetAll()
        {
            return await db.Departments.AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<Department>> GetAllRecursive()
        {
            return await db.Departments.Include(d => d.ChildDepartments).Where(d => d.ParentDepartmentId == null).AsNoTracking().ToListAsync();
        }
        public async Task<Department> GetById(Guid id)
        {
            return await db.Departments.FirstOrDefaultAsync(d => d.Id == id) ?? throw new NotFoundByIdException();
        }
        public async Task<Department> GetByIdRecursive(Guid id)
        {
            return await db.Departments.Include(d => d.ChildDepartments).FirstOrDefaultAsync(d => d.Id == id) ?? throw new NotFoundByIdException();
        }
        public async Task<Guid> Add(Department department)
        {
            // Validate parent exists if specified
            if (department.ParentDepartmentId.HasValue)
            {
                var parentExists = await db.Departments.AnyAsync(d => d.Id == department.ParentDepartmentId);
                if (!parentExists)
                    throw new NotFoundByIdException();
            }

            var exists = await db.Departments.AnyAsync(x => x.Name == department.Name);
            if (exists)
                throw new AlreadyExistException();

            await db.Departments.AddAsync(department);
            await db.SaveChangesAsync();
            return department.Id;
        }
        public async Task Update(Department department)
        {
            var existing = await db.Departments.FindAsync(department.Id) ?? throw new NotFoundByIdException();
            if (existing.ParentDepartmentId != department.ParentDepartmentId && department.ParentDepartmentId.HasValue)
            {
                var parentExists = await db.Departments.AnyAsync(d => d.Id == department.ParentDepartmentId);
                if (!parentExists)
                    throw new NotFoundByIdException();
            }
            existing.Name = department.Name;
            existing.ParentDepartmentId = department.ParentDepartmentId;
            await db.SaveChangesAsync();
        }
        public async Task DeleteById(Guid id)
        {
            var department = await db.Departments.Include(d => d.ChildDepartments).FirstOrDefaultAsync(d => d.Id == id) ?? throw new NotFoundByIdException();

            if (department.ChildDepartments.Any())
                throw new InvalidOperationException("Cannot delete department with sub-departments");

            db.Departments.Remove(department);
            await db.SaveChangesAsync();
        }
        public async Task<IEnumerable<Guid>> GetUserIds(Guid departmentId)
        {
            var departmentExists = await db.Departments.AnyAsync(d => d.Id == departmentId);
            if (!departmentExists)
                throw new NotFoundByIdException();

            return await db.Posts.Where(p => p.DepartmentId == departmentId).Select(p => p.UserId).Distinct().ToListAsync();
        }
        public async Task<IEnumerable<User>> GetUsers(Guid departmentId)
        {
            var departmentExists = await db.Departments.AnyAsync(d => d.Id == departmentId);
            if (!departmentExists)
                throw new NotFoundByIdException();
            var userIds = await db.Posts.Where(p => p.DepartmentId == departmentId).Select(p => p.UserId).Distinct().ToListAsync();
            return await db.Users.Where(u => userIds.Contains(u.Id)).ToListAsync();
        }
        public async Task<IEnumerable<Guid>> GetTeachersIds(Guid departmentId)
        {
            var departmentExists = await db.Departments.AnyAsync(d => d.Id == departmentId);
            if (!departmentExists)
                throw new NotFoundByIdException();

            return await db.Posts.Where(p => p.DepartmentId == departmentId)
                .Join(db.Teachers,
                    post => post.UserId,
                    teacher => teacher.Id,
                    (post, teacher) => teacher.Id)
                .Distinct().ToListAsync();
        }
        public async Task<IEnumerable<Teacher>> GetTeachers(Guid departmentId)
        {
            var departmentExists = await db.Departments.AnyAsync(d => d.Id == departmentId);
            if (!departmentExists)
                throw new NotFoundByIdException();
            var allDepartmentIds = await GetChildDepartmentIdsRecursive(departmentId);
            var teacherUserIds = await db.Posts.Where(p => allDepartmentIds.Contains(p.DepartmentId)).Select(p => p.UserId).Distinct().ToListAsync();
            return await db.Teachers.Include(t => t.Posts).Where(t => teacherUserIds.Contains(t.Id)).ToListAsync();
        }
        private async Task<List<Guid>> GetChildDepartmentIdsRecursive(Guid parentDepartmentId)
        {
            var result = new List<Guid> { parentDepartmentId };

            // Получаем непосредственных потомков
            var childIds = await db.Departments.Where(d => d.ParentDepartmentId == parentDepartmentId).Select(d => d.Id).ToListAsync();
            foreach (var childId in childIds)
            {
                result.AddRange(await GetChildDepartmentIdsRecursive(childId));
            }
            return result;
        }
        public async Task<List<Guid>> GetDepartmentIdsByType(DepartmentType departmentType)
        {
            return await db.Departments.Where(department => department.DepartmentType == departmentType).Select(d => d.Id).ToListAsync();
        }
    }
}