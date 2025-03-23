using Portfolio.Domain.Models;

namespace Portfolio.Domain.Services
{
    public interface ITeacherDisciplineService
    {
        Task<IEnumerable<Guid>> GetAll(Guid id);
        Task<IEnumerable<Discipline>> GetAllEntities(Guid id);
        Task<Discipline> Get(Guid id, Guid entityId);
        Task Add(Guid id, Guid entityId);
        Task Delete(Guid id, Guid entityId);
    }
}
