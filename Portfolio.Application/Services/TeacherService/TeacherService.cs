using Portfolio.Domain.Models;
using Portfolio.Domain.Services;

namespace Portfolio.Application.Services.TeacherService
{
    public partial class TeacherService : ITeacherService
    {
        private readonly ApplicationContext db;
        public TeacherService(ApplicationContext db)
        {
            this.db = db;
        }

        public Task<Guid> Add(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public Task AddInfo(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Teacher>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Teacher>> GetAllDependencies()
        {
            throw new NotImplementedException();
        }

        public Task<Teacher> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Teacher> GetByIdWithDependencies(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Teacher teacher)
        {
            throw new NotImplementedException();
        }
    }
}
