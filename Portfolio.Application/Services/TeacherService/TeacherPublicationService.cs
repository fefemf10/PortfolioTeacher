using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Exceptions;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;
using Portfolio.Infrastructure;

namespace Portfolio.Application.Services.TeacherService
{
    public class TeacherPublicationService : ITeacherPublicationService
    {
        private readonly ApplicationContext db;
        public TeacherPublicationService(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<Guid> Add(Guid id, Publication entity)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Publications).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            Publication? publication = teacher.Publications.SingleOrDefault(x => x.Name == entity.Name && x.CoAuthor == entity.CoAuthor && x.Size == entity.Size && x.OutputData == entity.OutputData && x.Form == entity.Form);
            if (publication is not null)
                throw new AlredyExistException();
            teacher.Publications.Add(entity);
            await db.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Delete(Guid id, Guid entityId)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Publications).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            Publication? publication = teacher.Publications.SingleOrDefault(x => x.Id == entityId) ?? throw new NotFoundByIdException();
            teacher.Publications.Remove(publication);
            await db.SaveChangesAsync();
        }

        public async Task<Publication> Get(Guid id, Guid entityId)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Publications).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            return teacher.Publications.SingleOrDefault(x => x.Id == entityId) ?? throw new NotFoundByIdException();
        }

        public async Task<IEnumerable<Guid>> GetAll(Guid id)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Publications).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            return teacher.Publications.Select(x => x.Id).ToList();
        }

        public async Task Update(Guid id, Publication entity)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Awards).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            Publication? publication = teacher.Publications.SingleOrDefault(x => x.Id == entity.Id) ?? throw new NotFoundByIdException();
            publication.Name = entity.Name;
            publication.OutputData = entity.OutputData;
            publication.Size = entity.Size;
            publication.CoAuthor = entity.CoAuthor;
            publication.Form = entity.Form;
            await db.SaveChangesAsync();
        }
    }
}
