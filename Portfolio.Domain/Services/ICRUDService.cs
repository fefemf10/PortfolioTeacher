using Portfolio.Domain.Models;

namespace Portfolio.Domain.Services
{
    public interface ICRUDService<T>
    {
        Task<IEnumerable<Guid>> GetAll(Guid id);
        Task<T> Get(Guid id, Guid entityId);
        Task<Guid> Add(Guid id, T entity);
        Task Update(Guid id, T entity);
        Task Delete(Guid id, Guid entityId);
    }
    public interface ITeacherAwardService : ICRUDService<Award>;
    public interface ITeacherDisciplineService : ICRUDService<Discipline>;
    public interface ITeacherDissertationService : ICRUDService<Dissertation>;
    public interface ITeacherProfessionalDevelopmentService : ICRUDService<ProfessionalDevelopment>;
    public interface ITeacherPublicActivityService : ICRUDService<PublicActivity>;
    public interface ITeacherPublicationService : ICRUDService<Publication>;
    public interface ITeacherScienceProjectService : ICRUDService<ScienceProject>;
    public interface ITeacherUniversityService : ICRUDService<University>;
    public interface ITeacherWorkService : ICRUDService<Work>;
}
