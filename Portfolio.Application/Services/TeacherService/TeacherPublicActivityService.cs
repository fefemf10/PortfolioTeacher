using Portfolio.Domain.Models;
using Portfolio.Domain.Services;

namespace Portfolio.Application.Services.TeacherService
{
    public class TeacherPublicActivityService : ITeacherPublicActivityService
    {
        private readonly ApplicationContext db;
        public TeacherPublicActivityService(ApplicationContext db)
        {
            this.db = db;
        }

        public Task<Guid> Add(Guid id, PublicActivity entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id, Guid entityId)
        {
            throw new NotImplementedException();
        }

        public Task<PublicActivity> Get(Guid id, Guid entityId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Guid>> GetAll(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Guid id, PublicActivity entity)
        {
            throw new NotImplementedException();
        }
    }
}
