using Portfolio.Domain.Models;

namespace Portfolio.Domain.Services
{
    public interface ITeacherPublicationService
    {
        Task<IEnumerable<Guid>> GetAll(Guid id);
        Task<IEnumerable<Publication>> GetAllEntities(Guid id);
        Task<IEnumerable<Monography>> GetAllMonographies(Guid id);
        Task<IEnumerable<Thesis>> GetAllTheses(Guid id);
        Task<IEnumerable<Article>> GetAllArticles(Guid id);
        Task<Publication> Get(Guid id, Guid entityId);
        Task<Monography> GetMonography(Guid id, Guid entityId);
        Task<Thesis> GetThesis(Guid id, Guid entityId);
        Task<Article> GetArticle(Guid id, Guid entityId);
        Task<Guid> AddMonography(Guid id, Monography entity);
        Task<Guid> AddThesis(Guid id, Thesis entity);
        Task<Guid> AddArticle(Guid id, Article entity);
        Task UpdateMonography(Guid id, Guid publicationId, Monography entity);
        Task UpdateThesis(Guid id, Guid publicationId, Thesis entity);
        Task UpdateArticle(Guid id, Guid publicationId, Article entity);
        Task Delete(Guid id, Guid entityId);
    }
}
