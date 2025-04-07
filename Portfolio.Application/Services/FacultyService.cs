using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Portfolio.Application.Exceptions;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;
using Portfolio.Infrastructure;
using System.Text.Json;

namespace Portfolio.Application.Services
{
    public class FacultyService : IFacultyService
    {
        private readonly ApplicationContext db;
        private readonly IDistributedCache cache;
        public FacultyService(ApplicationContext db, IDistributedCache cache)
        {
            this.db = db;
            this.cache = cache;
        }
        public async Task<IEnumerable<Guid>> GetTeachersIds(Guid id)
        {
            Faculty f = await db.Faculties.Include(x => x.Departments).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            var teachers =
            from department in f.Departments
            from teacher in db.Teachers
            where teacher.FacultyId == id
            select teacher.Id;
            return teachers;
        }
        public async Task<IEnumerable<Faculty>> GetAll()
        {
            return await db.Faculties.AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<Faculty>> GetAllWithDepartments()
        {
            return await db.Faculties.Include(x => x.Departments).AsNoTracking().ToListAsync();
        }
        public async Task<Faculty> GetById(Guid id)
        {
            return await db.Faculties.FindAsync(id) ?? throw new NotFoundByIdException();
        }
        public async Task<Faculty> GetByIdWithDepartments(Guid id)
        {
            return await db.Faculties.Include(x => x.Departments).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
        }
        public async Task<Guid> Add(Faculty faculty)
        {
            Faculty? f = await db.Faculties.SingleOrDefaultAsync(x => x.Name == faculty.Name && x.FullName == faculty.FullName);
            if (f is not null)
                throw new AlredyExistException();
            await db.Faculties.AddAsync(f);
            await db.SaveChangesAsync();
            return faculty.Id;
        }
        public async Task Update(Faculty faculty)
        {
            Faculty f = await db.Faculties.FindAsync(faculty.Id) ?? throw new NotFoundByIdException();
            f.Name = faculty.Name;
            f.FullName = faculty.FullName;
            await db.SaveChangesAsync();
        }
        public async Task DeleteById(Guid id)
        {
            db.Faculties.Remove(await db.Faculties.FindAsync(id) ?? throw new NotFoundByIdException());
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Teacher>> GetTeachers(Guid id)
        {
            IEnumerable<Teacher> teachers = [];
            string? teachersString = await cache.GetStringAsync("facultyTeachers" + id);
            if (teachersString is not null) teachers = JsonSerializer.Deserialize<IEnumerable<Teacher>>(teachersString) ?? [];
            if (!teachers.Any())
            {
                Faculty f = await db.Faculties.FindAsync(id) ?? throw new NotFoundByIdException();
                teachers = await db.Teachers.IncludeAll(db).Where(x => x.FacultyId == id).AsNoTracking().ToListAsync();
                teachersString = JsonSerializer.Serialize(teachers);
                await cache.SetStringAsync("facultyTeachers" + id, teachersString, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                });
            }
            return teachers;
        }
    }
}
