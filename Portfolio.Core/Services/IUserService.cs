using Portfolio.Domain.Models;

namespace Portfolio.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(Guid id);
        Task<IEnumerable<User>> GetByIds(IEnumerable<Guid> ids);
    }
}