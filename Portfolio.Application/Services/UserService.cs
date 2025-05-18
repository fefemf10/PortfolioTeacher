using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Exceptions;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;
using Portfolio.Infrastructure;

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

        public async Task<UserFile?> GetAvatar(Guid id)
        {
            User user = await GetById(id);
            return user.Avatar;
        }

        public async Task<User> GetById(Guid id)
        {
            return await db.Users.Include(x => x.Avatar).AsNoTracking().SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
        }
        public async Task<IEnumerable<User>> GetByIds(IEnumerable<Guid> ids)
        {
            return await db.Users.AsNoTracking().Where(x => ids.Contains(x.Id)).Include(x => x.Works).Include(x => x.Universities).ToListAsync();
        }

        public async Task UploadAvatar(Guid id, UserFile file)
        {
            db.UserFiles.Add(file);
            User user = await db.Users.FindAsync(id) ?? throw new NotFoundByIdException();
            user.Avatar = file;
            await db.SaveChangesAsync();
        }
    }
}
