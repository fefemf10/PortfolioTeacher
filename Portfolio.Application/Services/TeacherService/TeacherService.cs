using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Portfolio.Application.Exceptions;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;
using Portfolio.Infrastructure;
using System.Collections;
using System.Text.Json;

namespace Portfolio.Application.Services.TeacherService
{
    public partial class TeacherService(
        ApplicationContext db,
        ITeacherWorkService tws,
        ITeacherUniversityService tus,
        ITeacherScienceProjectService tsps,
        ITeacherProfessionalDevelopmentService tpds,
        ITeacherAwardService tas,
        IDistributedCache cache) : ITeacherService
    {
        public async Task<Guid> Add(Teacher teacher)
        {
            await db.AddAsync(teacher);
            await db.SaveChangesAsync();
            return teacher.Id;
        }

        public async Task AddInfo(Teacher teacher)
        {
            Teacher t = await db.Teachers.IncludeAll(db).SingleOrDefaultAsync(x => x.Id == teacher.Id) ?? throw new NotFoundByIdException();
            t.Post = teacher.Post;
            t.DateBirthday = teacher.DateBirthday;
            t.AcademicDegree = teacher.AcademicDegree;
            t.AcademicTitle = teacher.AcademicTitle;
            t.FirstName = teacher.FirstName;
            t.LastName = teacher.LastName;
            t.MiddleName = teacher.MiddleName;
            await db.SaveChangesAsync();
            await cache.SetStringAsync("teacherWithDependencies" + teacher.Id, JsonSerializer.Serialize(t));
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

        public async Task<IEnumerable<Teacher>> GetAllFromCache()
        {
            IEnumerable<Teacher> teachers = [];
            var teacherString = await cache.GetStringAsync("teachersWithDependencies");
            if (teacherString != null) teachers = JsonSerializer.Deserialize<IEnumerable<Teacher>>(teacherString) ?? [];
            if (!teachers.Any())
            {
                teachers = await db.Teachers.IncludeAll(db).AsNoTracking().ToListAsync();
                teacherString = JsonSerializer.Serialize(teachers);
                await cache.SetStringAsync("teachersWithDependencies", teacherString);
            }
            return teachers;

        }
        public async Task<Teacher> GetById(Guid id)
        {
            return await db.Teachers.FindAsync(id) ?? throw new NotFoundByIdException();
        }

        public async Task<Teacher> GetByIdFromCache(Guid id)
        {
            Teacher? teacher = null;
            string? teacherString = await cache.GetStringAsync("teacherWithDependencies" + id);
            if (teacherString != null) teacher = JsonSerializer.Deserialize<Teacher>(teacherString);
            if (teacher is null)
            {
                teacher = await db.Teachers.IncludeAll(db).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
                teacherString = JsonSerializer.Serialize(teacher);
                await cache.SetStringAsync("teacherWithDependencies" + id, teacherString);
            }
            return teacher;
        }

        public async Task<TeacherShortInfo> GetByIdShortInfo(Guid id)
        {
            TeacherShortInfo shortInfo = new();
            shortInfo.Works = await tws.GetShortAll(id);
            shortInfo.Universities = await tus.GetShortAll(id);
            shortInfo.ScienceProjects = await tsps.GetShortAll(id);
            shortInfo.ProfessionalDevelopments = await tpds.GetShortAll(id);
            shortInfo.Awards = await tas.GetShortAll(id);
            return shortInfo;
        }

        public async Task<Teacher> GetByIdWithDependencies(Guid id)
        {
            return await db.Teachers.IncludeAll(db).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException(); ;
        }
        public async Task Update(Teacher teacher)
        {
            Teacher t = await db.Teachers.FindAsync(teacher.Id) ?? throw new NotFoundByIdException();
            t = teacher;
            await db.SaveChangesAsync();
        }
    }
}
