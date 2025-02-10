using Microsoft.EntityFrameworkCore;
using PortfolioShared.Models;

namespace PortfolioServer.Repositories
{
    public class DepartmentRepository
    {
        private readonly ApplicationContext db;
        public DepartmentRepository(ApplicationContext db)
        {
            this.db = db;
        }
        public Task<List<Department>> Get()
        {
            return db.Departments.AsNoTracking().ToListAsync();
        }
        public Task<Department?> GetById(Guid guid)
        {
            return db.Departments.FindAsync(guid).AsTask();
        }
    }
}
