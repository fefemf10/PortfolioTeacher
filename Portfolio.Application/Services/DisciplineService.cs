using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Exceptions;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;

namespace Portfolio.Application.Services
{
    public class DisciplineService : IDisciplineService
    {
        private readonly ApplicationContext db;
        public DisciplineService(ApplicationContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<Discipline>> GetAll()
        {
            return await db.Disciplines.AsNoTracking().ToListAsync();
        }
        public async Task<Discipline> GetById(Guid id)
        {
            return await db.Disciplines.FindAsync(id) ?? throw new NotFoundByIdException();
        }
        public async Task<Guid> Add(Discipline discipline)
        {
            Discipline? d = await db.Disciplines.SingleOrDefaultAsync(x => x.Name == discipline.Name);
            if (d is not null)
                throw new AlredyExistException();
            await db.Disciplines.AddAsync(discipline);
            await db.SaveChangesAsync();
            return discipline.Id;
        }
        public async Task Update(Discipline discipline)
        {
            Discipline d = await db.Disciplines.FindAsync(discipline.Id) ?? throw new NotFoundByIdException();
            d.Name = discipline.Name;
            await db.SaveChangesAsync();
        }
        public async Task DeleteById(Guid id)
        {
            Discipline? discipline = await GetById(id);
            await db.Disciplines.Where(x => x.Id == discipline.Id).ExecuteDeleteAsync();
        }
    }
}
