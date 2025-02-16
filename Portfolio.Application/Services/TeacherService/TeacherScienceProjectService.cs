using Portfolio.Domain.Models;
using Portfolio.Domain.Services;

namespace Portfolio.Application.Services.TeacherService
{
    public class TeacherScienceProjectService : ITeacherScienceProjectService
    {
        private readonly ApplicationContext db;
        public TeacherScienceProjectService(ApplicationContext db)
        {
            this.db = db;
        }

        public Task<Guid> Add(Guid id, ScienceProject entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id, Guid entityId)
        {
            throw new NotImplementedException();
        }

        public Task<ScienceProject> Get(Guid id, Guid entityId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Guid>> GetAll(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Guid id, ScienceProject entity)
        {
            throw new NotImplementedException();
        }
    }
}
