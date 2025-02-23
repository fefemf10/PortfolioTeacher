using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Exceptions;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;
using Portfolio.Infrastructure;

namespace Portfolio.Application.Services.TeacherService
{
    public class TeacherWorkService : ITeacherWorkService
    {
        private readonly ApplicationContext db;
        public TeacherWorkService(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<Guid> Add(Guid id, Work entity)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Works).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            Work? work = teacher.Works.SingleOrDefault(x => x.Name == entity.Name && x.Post == entity.Post && x.BeginTimeWork == entity.BeginTimeWork && x.EndTimeWork == entity.EndTimeWork);
            if (work is not null)
                throw new AlredyExistException();
            teacher.Works.Add(entity);
            await db.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Delete(Guid id, Guid entityId)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Works).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            Work? work = teacher.Works.SingleOrDefault(x => x.Id == entityId) ?? throw new NotFoundByIdException();
            teacher.Works.Remove(work);
            await db.SaveChangesAsync();
        }

        public async Task<Work> Get(Guid id, Guid entityId)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Works).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            return teacher.Works.SingleOrDefault(x => x.Id == entityId) ?? throw new NotFoundByIdException();
        }

        public async Task<IEnumerable<Guid>> GetAll(Guid id)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Works).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            return teacher.Works.Select(x => x.Id).ToList();
        }

        public async Task Update(Guid id, Work entity)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Awards).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            Work? work = teacher.Works.SingleOrDefault(x => x.Id == entity.Id) ?? throw new NotFoundByIdException();
            work.Name = entity.Name;
            work.Post = entity.Post;
            work.BeginTimeWork = entity.BeginTimeWork;
            work.EndTimeWork = entity.EndTimeWork;
            await db.SaveChangesAsync();
        }
    }
}
