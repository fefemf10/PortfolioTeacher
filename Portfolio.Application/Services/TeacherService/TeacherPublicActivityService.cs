using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Exceptions;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;
using Portfolio.Infrastructure;

namespace Portfolio.Application.Services.TeacherService
{
    public class TeacherPublicActivityService : ITeacherPublicActivityService
    {
        private readonly ApplicationContext db;
        public TeacherPublicActivityService(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<Guid> Add(Guid id, PublicActivity entity)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.PublicActivities).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            PublicActivity? publicActivity = teacher.PublicActivities.SingleOrDefault(x => x.Name == entity.Name);
            if (publicActivity is not null)
                throw new AlredyExistException();
            teacher.PublicActivities.Add(entity);
            await db.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Delete(Guid id, Guid entityId)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.PublicActivities).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            PublicActivity? publicActivity = teacher.PublicActivities.SingleOrDefault(x => x.Id == entityId) ?? throw new NotFoundByIdException();
            teacher.PublicActivities.Remove(publicActivity);
            await db.SaveChangesAsync();
        }

        public async Task<PublicActivity> Get(Guid id, Guid entityId)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.PublicActivities).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            return teacher.PublicActivities.SingleOrDefault(x => x.Id == entityId) ?? throw new NotFoundByIdException();
        }

        public async Task<IEnumerable<Guid>> GetAll(Guid id)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.PublicActivities).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            return teacher.PublicActivities.Select(x => x.Id).ToList();
        }

        public async Task<IEnumerable<PublicActivity>> GetAllEntities(Guid id)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.PublicActivities).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            return teacher.PublicActivities;
        }

        public async Task Update(Guid id, PublicActivity entity)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.PublicActivities).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            PublicActivity? publicActivity = teacher.PublicActivities.SingleOrDefault(x => x.Id == entity.Id) ?? throw new NotFoundByIdException();
            publicActivity.Name = entity.Name;
            await db.SaveChangesAsync();
        }
    }
}
