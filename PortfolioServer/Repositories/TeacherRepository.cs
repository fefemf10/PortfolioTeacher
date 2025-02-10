using Microsoft.EntityFrameworkCore;
using PortfolioShared.Models;
using PortfolioShared.ViewModels.Request;
using System;

namespace PortfolioServer.Repositories
{
    public class TeacherRepository
    {
        private readonly ApplicationContext db;
        public TeacherRepository(ApplicationContext db)
        {
            this.db = db;
        }
        public Task<List<Teacher>> Get()
        {
            return db.Teachers.AsNoTracking().ToListAsync();
        }
        public Task<List<Teacher>> GetWithDependencies()
        {
            return db.Teachers.AsNoTracking().Include(x => x.Faculty).Include(x => x.Department).Include(x => x.Publications).ToListAsync();
        }
        public Task<Teacher?> GetById(Guid guid)
        {
            return db.Teachers.FindAsync(guid).AsTask();
        }
        public Task<Guid> Create(RequestTeacher teacher)
        {
            
        }
    }
}
