using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Exceptions;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;
using Portfolio.Infrastructure;

namespace Portfolio.Application.Services.TeacherService
{
    public class TeacherProfessionalDevelopmentService : ITeacherProfessionalDevelopmentService
    {
        private readonly ApplicationContext db;
        public TeacherProfessionalDevelopmentService(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<Guid> Add(Guid id, ProfessionalDevelopment entity)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.ProfessionalDevelopments).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            ProfessionalDevelopment? professionalDevelopment = teacher.ProfessionalDevelopments.SingleOrDefault(x => x.Name == entity.Name && x.NumberDocument == entity.NumberDocument && x.SeriaDocument == entity.SeriaDocument && x.DateСompletion == entity.DateСompletion && x.ListeningTime == entity.ListeningTime && x.NameDocument == entity.NameDocument && x.NameOrganization == entity.NameOrganization);
            if (professionalDevelopment is not null)
                throw new AlredyExistException();
            teacher.ProfessionalDevelopments.Add(entity);
            await db.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Delete(Guid id, Guid entityId)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.ProfessionalDevelopments).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            ProfessionalDevelopment? professionalDevelopment = teacher.ProfessionalDevelopments.SingleOrDefault(x => x.Id == entityId) ?? throw new NotFoundByIdException();
            teacher.ProfessionalDevelopments.Remove(professionalDevelopment);
            await db.SaveChangesAsync();
        }

        public async Task<ProfessionalDevelopment> Get(Guid id, Guid entityId)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.ProfessionalDevelopments).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            return teacher.ProfessionalDevelopments.SingleOrDefault(x => x.Id == entityId) ?? throw new NotFoundByIdException();
        }

        public async Task<IEnumerable<Guid>> GetAll(Guid id)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.ProfessionalDevelopments).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            return teacher.ProfessionalDevelopments.Select(x => x.Id).ToList();
        }

        public async Task Update(Guid id, ProfessionalDevelopment entity)
        {
            Teacher? teacher = await db.Teachers.Include(x => x.ProfessionalDevelopments).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
            ProfessionalDevelopment? professionalDevelopment = teacher.ProfessionalDevelopments.SingleOrDefault(x => x.Id == entity.Id) ?? throw new NotFoundByIdException();
            professionalDevelopment.Name = entity.Name;
            professionalDevelopment.NameDocument = entity.NameDocument;
            professionalDevelopment.NameOrganization = entity.NameOrganization;
            professionalDevelopment.SeriaDocument = entity.SeriaDocument;
            professionalDevelopment.NumberDocument = entity.NumberDocument;
            professionalDevelopment.DateСompletion = entity.DateСompletion;
            professionalDevelopment.ListeningTime = entity.ListeningTime;
            await db.SaveChangesAsync();
        }
    }
}
