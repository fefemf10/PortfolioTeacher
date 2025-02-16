using Portfolio.Domain.Models;
using Portfolio.Domain.Services;

namespace Portfolio.Application.Services.TeacherService
{
    public class TeacherDisciplineService : ITeacherDisciplineService
    {
        private readonly ApplicationContext db;
        public TeacherDisciplineService(ApplicationContext db)
        {
            this.db = db;
        }

        public Task<Guid> Add(Guid id, Discipline entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id, Guid entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Discipline> Get(Guid id, Guid entityId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Guid>> GetAll(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Guid id, Discipline entity)
        {
            throw new NotImplementedException();
        }
    }
}
