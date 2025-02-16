using Portfolio.Domain.Models;
using Portfolio.Domain.Services;

namespace Portfolio.Application.Services.TeacherService
{
    public class TeacherUniversityService : ITeacherUniversityService
    {
        private readonly ApplicationContext db;
        public TeacherUniversityService(ApplicationContext db)
        {
            this.db = db;
        }

        public Task<Guid> Add(Guid id, University entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id, Guid entityId)
        {
            throw new NotImplementedException();
        }

        public Task<University> Get(Guid id, Guid entityId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Guid>> GetAll(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Guid id, University entity)
        {
            throw new NotImplementedException();
        }
    }
}
