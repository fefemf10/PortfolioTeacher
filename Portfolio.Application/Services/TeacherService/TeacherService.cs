using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;
using Portfolio.Infrastructure;

namespace Portfolio.Application.Services.TeacherService
{
    public partial class TeacherService : ITeacherService
    {
        private readonly ApplicationContext db;
        public TeacherService(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<Guid> Add(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public async Task AddInfo(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteById(Guid id)
        {
            db.Teachers.Remove(await db.Teachers.FindAsync(id));
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Teacher>> GetAll()
        {
            return db.Teachers;
        }

        public async Task<IEnumerable<Teacher>> GetAllDependencies()
        {
            throw new NotImplementedException();
        }

        public async Task<Teacher> GetById(Guid id)
        {
            return await db.Teachers.FindAsync(id);
        }

        public async Task<Teacher> GetByIdWithDependencies(Guid id)
        {
            return await db.Teachers
                .Include(x => x.Faculty)
                .Include(x => x.Department)
                .Include(x => x.ScienceProjects)
                .Include(x => x.Universities)
                .Include(x => x.PublicActivities)
                .Include(x => x.Publications)
                .Include(x => x.Awards)
                .Include(x => x.ProfessionalDevelopments)
                .Include(x => x.Works)
                .Include(x => x.AwardStudents)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Teacher teacher)
        {
            throw new NotImplementedException();
        }
    }
}
