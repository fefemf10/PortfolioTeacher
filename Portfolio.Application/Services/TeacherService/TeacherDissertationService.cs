using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Exceptions;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;
using Portfolio.Infrastructure;

namespace Portfolio.Application.Services.TeacherService
{
    public partial class TeacherDissertationService : ITeacherDissertationService
    {
        private readonly ApplicationContext db;
        private readonly IMapper mapper;
        public TeacherDissertationService(ApplicationContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<Guid> Add(Guid id, Dissertation entity)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Dissertations).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            Dissertation? dissertation = teacher.Dissertations.SingleOrDefault(x => x.Name == entity.Name && x.YearProtection == entity.YearProtection);
            if (dissertation is not null)
                throw new AlredyExistException();
            teacher.Dissertations.Add(entity);
            await db.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Delete(Guid id, Guid entityId)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Dissertations).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            Dissertation? dissertation = teacher.Dissertations.SingleOrDefault(x => x.Id == entityId) ?? throw new NotFoundByIdException();
            teacher.Dissertations.Remove(dissertation);
            await db.SaveChangesAsync();
        }

        public async Task<Dissertation> Get(Guid id, Guid entityId)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Dissertations).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            return teacher.Dissertations.SingleOrDefault(x => x.Id == entityId) ?? throw new NotFoundByIdException();
        }

        public async Task<IEnumerable<Guid>> GetAll(Guid id)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Dissertations).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            return teacher.Dissertations.Select(x => x.Id).ToList();
        }

        public async Task<IEnumerable<Dissertation>> GetAllEntities(Guid id)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Dissertations).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            return teacher.Dissertations;
        }

        public async Task<IEnumerable<ShortItem>> GetShortAll(Guid id)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Dissertations).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            return mapper.Map<IEnumerable<ShortItem>>(teacher.Dissertations.ToList());
        }
        public async Task Update(Guid id, Dissertation entity)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Dissertations).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            Dissertation? dissertation = teacher.Dissertations.SingleOrDefault(x => x.Id == entity.Id) ?? throw new NotFoundByIdException();
            dissertation.Name = entity.Name;
            dissertation.YearProtection = entity.YearProtection;
            await db.SaveChangesAsync();
        }
    }
}
