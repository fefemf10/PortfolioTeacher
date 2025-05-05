using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Exceptions;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;
using Portfolio.Infrastructure;

namespace Portfolio.Application.Services.TeacherService
{
    public class TeacherAwardService : ITeacherAwardService
    {
        private readonly ApplicationContext db;
        private readonly IMapper mapper;
        public TeacherAwardService(ApplicationContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<Guid> Add(Guid id, Award entity)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Awards).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            Award? award = teacher.Awards.SingleOrDefault(x => x.Name == entity.Name && x.NameOrganization == entity.NameOrganization && x.DateAward == entity.DateAward);
            if (award is not null)
                throw new AlreadyExistException();
            teacher.Awards.Add(entity);
            await db.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Delete(Guid id, Guid entityId)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Awards).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            Award? award = teacher.Awards.SingleOrDefault(x => x.Id == entityId) ?? throw new NotFoundByIdException();
            teacher.Awards.Remove(award);
            await db.SaveChangesAsync();
        }

        public async Task<Award> Get(Guid id, Guid entityId)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Awards).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            return teacher.Awards.SingleOrDefault(x => x.Id == entityId) ?? throw new NotFoundByIdException();
        }

        public async Task<IEnumerable<Guid>> GetAll(Guid id)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Awards).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            return teacher.Awards.Select(x => x.Id).ToList();
        }

        public async Task<IEnumerable<Award>> GetAllEntities(Guid id)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Awards).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            return teacher.Awards;
        }

        public async Task<IEnumerable<ShortItem>> GetShortAll(Guid id)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Awards).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            return mapper.Map<IEnumerable<ShortItem>>(teacher.Awards.ToList()).OrderBy(x => x.Year);
        }

        public async Task Update(Guid id, Award entity)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.Awards).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            Award? award = teacher.Awards.SingleOrDefault(x => x.Id == entity.Id) ?? throw new NotFoundByIdException();
            award.Name = entity.Name;
            award.NameOrganization = entity.NameOrganization;
            award.DateAward = entity.DateAward;
            await db.SaveChangesAsync();
        }
    }
}
