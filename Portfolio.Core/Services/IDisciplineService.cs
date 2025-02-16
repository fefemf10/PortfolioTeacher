using Portfolio.Domain.Models;

namespace Portfolio.Domain.Services
{
    public interface IDisciplineService
    {
        Task<Guid> Add(Discipline discipline);
        Task DeleteById(Guid id);
        Task<IEnumerable<Discipline>> GetAll();
        Task<Discipline> GetById(Guid id);
        Task Update(Discipline discipline);
    }
}