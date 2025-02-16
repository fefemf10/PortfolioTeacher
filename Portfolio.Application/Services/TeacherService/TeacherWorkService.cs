using Portfolio.Domain.Models;
using Portfolio.Domain.Services;

namespace Portfolio.Application.Services.TeacherService
{
    public class TeacherWorkService : ITeacherWorkService
    {
        private readonly ApplicationContext db;
        public TeacherWorkService(ApplicationContext db)
        {
            this.db = db;
        }

        public Task<Guid> Add(Guid id, Work entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id, Guid entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Work> Get(Guid id, Guid entityId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Guid>> GetAll(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Guid id, Work entity)
        {
            throw new NotImplementedException();
        }
    }
}
