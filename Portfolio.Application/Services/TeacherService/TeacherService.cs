using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;
using Portfolio.Infrastructure;
using Portfolio.Application.Exceptions;

namespace Portfolio.Application.Services.TeacherService
{
    public partial class TeacherService : ITeacherService
    {
        private readonly ApplicationContext db;
        public TeacherService(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<Guid> Add(Teacher teacher)
        {
            await db.AddAsync(teacher);
            await db.SaveChangesAsync();
            return teacher.Id;
        }

        public async Task AddInfo(Teacher teacher)
        {
            Teacher t = await db.Teachers.FindAsync(teacher.Id) ?? throw new NotFoundByIdException();
            t.Post = teacher.Post;
            t.DateBirthday = teacher.DateBirthday;
            t.AcademicDegree = teacher.AcademicDegree;
            t.AcademicTitle = teacher.AcademicTitle;
            t.FirstName = teacher.FirstName;
            t.LastName = teacher.LastName;
            t.MiddleName = teacher.MiddleName;
            await db.SaveChangesAsync();
        }

        public async Task DeleteById(Guid id)
        {
            db.Teachers.Remove(await db.Teachers.FindAsync(id) ?? throw new NotFoundByIdException());
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Teacher>> GetAll()
        {
            return await db.Teachers.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Teacher>> GetAllDependencies()
        {
            return await db.Teachers.IncludeAll(db).AsNoTracking().ToListAsync();
        }

        public async Task<Teacher> GetById(Guid id)
        {
            return await db.Teachers.FindAsync(id) ?? throw new NotFoundByIdException();
        }

        public async Task<Teacher> GetByIdWithDependencies(Guid id)
        {
            return await db.Teachers.IncludeAll(db).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
        }

        public async Task Update(Teacher teacher)
        {
            Teacher t = await db.Teachers.FindAsync(teacher.Id) ?? throw new NotFoundByIdException();
            t = teacher;
            await db.SaveChangesAsync();
        }
    }
}
