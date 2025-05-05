using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Exceptions;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;
using Portfolio.Infrastructure;

namespace Portfolio.Application.Services.TeacherService
{
    public class TeacherScienceProjectService : ITeacherScienceProjectService
    {
        private readonly ApplicationContext db;
        private readonly IMapper mapper;
        public TeacherScienceProjectService(ApplicationContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<Guid> Add(Guid id, ScienceProject entity)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.ScienceProjects).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            ScienceProject? scienceProject = teacher.ScienceProjects.SingleOrDefault(x => x.Name == entity.Name && x.Director == entity.Director && x.BeginTimeWork == entity.BeginTimeWork && x.EndTimeWork == entity.EndTimeWork);
            if (scienceProject is not null)
                throw new AlreadyExistException();
            teacher.ScienceProjects.Add(entity);
            await db.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Delete(Guid id, Guid entityId)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.ScienceProjects).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            ScienceProject? scienceProject = teacher.ScienceProjects.SingleOrDefault(x => x.Id == entityId) ?? throw new NotFoundByIdException();
            teacher.ScienceProjects.Remove(scienceProject);
            await db.SaveChangesAsync();
        }

        public async Task<ScienceProject> Get(Guid id, Guid entityId)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.ScienceProjects).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            return teacher.ScienceProjects.SingleOrDefault(x => x.Id == entityId) ?? throw new NotFoundByIdException();
        }

        public async Task<IEnumerable<Guid>> GetAll(Guid id)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.ScienceProjects).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            return teacher.ScienceProjects.Select(x => x.Id).ToList();
        }

        public async Task<IEnumerable<ScienceProject>> GetAllEntities(Guid id)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.ScienceProjects).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            return teacher.ScienceProjects;
        }

        public async Task<IEnumerable<ShortItem>> GetShortAll(Guid id)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.ScienceProjects).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            return mapper.Map<IEnumerable<ShortItem>>(teacher.ScienceProjects.ToList()).OrderBy(x => x.Year);
        }

        public async Task Update(Guid id, ScienceProject entity)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.ScienceProjects).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            ScienceProject? scienceProject = teacher.ScienceProjects.SingleOrDefault(x => x.Id == entity.Id) ?? throw new NotFoundByIdException();
            scienceProject.Name = entity.Name;
            scienceProject.Director = entity.Director;
            scienceProject.BeginTimeWork = entity.BeginTimeWork;
            scienceProject.EndTimeWork = entity.EndTimeWork;
            await db.SaveChangesAsync();
        }
    }
}
