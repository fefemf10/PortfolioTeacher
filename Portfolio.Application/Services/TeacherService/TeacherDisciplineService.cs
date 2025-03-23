using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Exceptions;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;
using Portfolio.Infrastructure;

namespace Portfolio.Application.Services.TeacherService
{
    public class TeacherDisciplineService : ITeacherDisciplineService
    {
        private readonly ApplicationContext db;
        public TeacherDisciplineService(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task Add(Guid id, Guid entityId)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Disciplines).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            Discipline? disciplineTeacher = teacher.Disciplines.SingleOrDefault(x => x.Id == entityId);
            if (disciplineTeacher is not null) throw new AlredyExistException();
            Discipline? discipline = await db.Disciplines.FindAsync(entityId) ?? throw new NotFoundByIdException();
            teacher.Disciplines.Add(discipline);
            await db.SaveChangesAsync();
        }

        public async Task Delete(Guid id, Guid entityId)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Disciplines).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            Discipline? discipline = teacher.Disciplines.SingleOrDefault(x => x.Id == entityId) ?? throw new NotFoundByIdException();
            teacher.Disciplines.Remove(discipline);
            await db.SaveChangesAsync();
        }

        public async Task<Discipline> Get(Guid id, Guid entityId)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Disciplines).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            return teacher.Disciplines.SingleOrDefault(x => x.Id == entityId) ?? throw new NotFoundByIdException();
        }

        public async Task<IEnumerable<Guid>> GetAll(Guid id)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Disciplines).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            return teacher.Disciplines.Select(x => x.Id).ToList();
        }

        public async Task<IEnumerable<Discipline>> GetAllEntities(Guid id)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Disciplines).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            return teacher.Disciplines.ToList();
        }
    }
}
