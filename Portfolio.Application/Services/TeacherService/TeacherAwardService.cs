using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Exceptions;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;

namespace Portfolio.Application.Services.TeacherService
{
    public class TeacherAwardService : ITeacherAwardService
    {
        private readonly ApplicationContext db;
        public TeacherAwardService(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<Guid> Add(Guid id, Award entity)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Awards).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            Award? award = teacher.Awards.SingleOrDefault(x => x.Name == entity.Name && x.NameOrganization == entity.NameOrganization && x.DateAward == entity.DateAward);
            if (award is not null)
                throw new AlredyExistException();
            teacher.Awards.Add(entity);
            await db.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Delete(Guid id, Guid entityId)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Awards).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            Award? award = teacher.Awards.SingleOrDefault(x => x.Id == entityId) ?? throw new NotFoundByIdException();
            teacher.Awards.Remove(award);
            await db.SaveChangesAsync();
        }

        public async Task<Award> Get(Guid id, Guid entityId)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Awards).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            return teacher.Awards.SingleOrDefault(x => x.Id == entityId) ?? throw new NotFoundByIdException();
        }

        public async Task<IEnumerable<Guid>> GetAll(Guid id)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Awards).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            return teacher.Awards.Select(x => x.Id).ToList();
        }

        public async Task Update(Guid id, Award entity)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Awards).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            Award? award = teacher.Awards.SingleOrDefault(x => x.Id == entity.Id) ?? throw new NotFoundByIdException();
            award.Name = entity.Name;
            award.NameOrganization = entity.NameOrganization;
            award.DateAward = entity.DateAward;
            await db.SaveChangesAsync();
        }
    }
}
