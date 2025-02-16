using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Exceptions;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;

namespace Portfolio.Application.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext db;
        public UserService(ApplicationContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<User>> GetAll()
        {
            return await db.Users.AsNoTracking().ToListAsync();
        }
        public async Task<User> GetById(Guid id)
        {
            return await db.Users.FindAsync(id) ?? throw new NotFoundByIdException();
        }
        public async Task<IEnumerable<User>> GetByIds(IEnumerable<Guid> ids)
        {
            return await db.Users.Where(x => ids.Contains(x.Id)).Include(x => x.Works).Include(x => x.Universities).ToListAsync();
        }
    }
}
