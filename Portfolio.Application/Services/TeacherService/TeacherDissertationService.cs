using Portfolio.Domain.Models;
using Portfolio.Domain.Services;

namespace Portfolio.Application.Services.TeacherService
{
    public partial class TeacherDissertationService : ITeacherDissertationService
    {
        private readonly ApplicationContext db;
        public TeacherDissertationService(ApplicationContext db)
        {
            this.db = db;
        }

        public Task<Guid> Add(Guid id, Dissertation entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id, Guid entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Dissertation> Get(Guid id, Guid entityId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Guid>> GetAll(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Guid id, Dissertation entity)
        {
            throw new NotImplementedException();
        }
    }
}
