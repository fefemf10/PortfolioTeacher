using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Exceptions;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;
using Portfolio.Infrastructure;

namespace Portfolio.Application.Services.TeacherService
{
    public class TeacherUniversityService : ITeacherUniversityService
    {
        private readonly ApplicationContext db;
        public TeacherUniversityService(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<Guid> Add(Guid id, University entity)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Universities).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            University? university = teacher.Universities.SingleOrDefault(x => x.Name == entity.Name && x.Specialization == entity.Specialization && x.Qualification == entity.Qualification && x.YearGraduation == entity.YearGraduation);
            if (university is not null)
                throw new AlredyExistException();
            teacher.Universities.Add(entity);
            await db.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Delete(Guid id, Guid entityId)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Universities).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            University? university = teacher.Universities.SingleOrDefault(x => x.Id == entityId) ?? throw new NotFoundByIdException();
            teacher.Universities.Remove(university);
            await db.SaveChangesAsync();
        }

        public async Task<University> Get(Guid id, Guid entityId)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Universities).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            return teacher.Universities.SingleOrDefault(x => x.Id == entityId) ?? throw new NotFoundByIdException();
        }

        public async Task<IEnumerable<Guid>> GetAll(Guid id)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Universities).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            return teacher.Universities.Select(x => x.Id).ToList();
        }

        public async Task<IEnumerable<University>> GetAllEntities(Guid id)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Universities).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            return teacher.Universities;
        }

        public async Task Update(Guid id, University entity)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Universities).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            University? university = teacher.Universities.SingleOrDefault(x => x.Id == entity.Id) ?? throw new NotFoundByIdException();
            university.Name = entity.Name;
            university.Qualification = entity.Qualification;
            university.Specialization = entity.Specialization;
            university.YearGraduation = entity.YearGraduation;
            await db.SaveChangesAsync();
        }
    }
}
