using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Exceptions;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;

namespace Portfolio.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationContext db;
        private readonly IFacultyService facultyService;
        public DepartmentService(ApplicationContext db, IFacultyService facultyService)
        {
            this.db = db;
            this.facultyService = facultyService;
        }
        public async Task<IEnumerable<Guid>> GetTeachers(Guid id)
        {
            Department d = await db.Departments.FindAsync(id) ?? throw new NotFoundByIdException();
            return await db.Teachers.Where(x => x.DepartmentId == d.Id).Select(x => x.Id).ToListAsync();
        }
        public async Task<IEnumerable<Department>> GetAll()
        {
            return await db.Departments.AsNoTracking().ToListAsync();
        }
        public async Task<Department> GetById(Guid id)
        {
            return await db.Departments.FindAsync(id) ?? throw new NotFoundByIdException();
        }
        public async Task<Guid> Add(Department department)
        {
            Faculty faculty = await facultyService.GetById(department.FacultyId);
            Department? d = await db.Departments.SingleOrDefaultAsync(x => x.Name == department.Name);
            if (d is not null)
                throw new AlredyExistException();
            await db.Departments.AddAsync(department);
            await db.SaveChangesAsync();
            return department.Id;
        }
        public async Task Update(Department department)
        {
            Faculty faculty = await facultyService.GetById(department.FacultyId);
            Department d = await db.Departments.FindAsync(department.Id) ?? throw new NotFoundByIdException();
            d.Name = department.Name;
            await db.SaveChangesAsync();
        }
        public async Task DeleteById(Guid id)
        {
            db.Departments.Remove(await db.Departments.FindAsync(id) ?? throw new NotFoundByIdException());
            await db.SaveChangesAsync();
        }
    }
}
