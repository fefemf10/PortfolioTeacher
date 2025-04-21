using Portfolio.Domain.Models;

namespace Portfolio.Domain.Services
{
    public interface ICRUDService<T>
    {
        Task<IEnumerable<Guid>> GetAll(Guid id);
        Task<IEnumerable<T>> GetAllEntities(Guid id);
        Task<T> Get(Guid id, Guid entityId);
        Task<Guid> Add(Guid id, T entity);
        Task Update(Guid id, T entity);
        Task Delete(Guid id, Guid entityId);
    }
    public interface IShortItemService
    {
        Task<IEnumerable<ShortItem>> GetShortAll(Guid id);
    }
    public interface ITeacherAwardService : ICRUDService<Award>, IShortItemService;
    public interface ITeacherDissertationService : ICRUDService<Dissertation>, IShortItemService;
    public interface ITeacherProfessionalDevelopmentService : ICRUDService<ProfessionalDevelopment>, IShortItemService;
    public interface ITeacherPublicActivityService : ICRUDService<PublicActivity>;
    public interface ITeacherPublicationService : ICRUDService<Publication>;
    public interface ITeacherScienceProjectService : ICRUDService<ScienceProject>, IShortItemService;
    public interface ITeacherUniversityService : ICRUDService<University>, IShortItemService;
    public interface ITeacherWorkService : ICRUDService<Work>, IShortItemService;
}
