using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Exceptions;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;
using Portfolio.Infrastructure;

namespace Portfolio.Application.Services.TeacherService
{
    public class TeacherPublicationService : ITeacherPublicationService
    {
        private readonly ApplicationContext db;
        private readonly IMapper mapper;
        public TeacherPublicationService(ApplicationContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<Guid>> GetAll(Guid id)
        {
            Teacher? teacher = await GetTeacherWithPublications(id);
            return teacher.Publications.Select(x => x.Id).ToList();
        }

        public async Task<IEnumerable<Publication>> GetAllEntities(Guid id)
        {
            Teacher? teacher = await GetTeacherWithPublications(id);
            return teacher.Publications;
        }

        public async Task<IEnumerable<Monography>> GetAllMonographies(Guid id)
        {
            Teacher? teacher = await GetTeacherWithPublications(id);
            return teacher.Publications.OfType<Monography>();
        }

        public async Task<IEnumerable<Thesis>> GetAllTheses(Guid id)
        {
            Teacher? teacher = await GetTeacherWithPublications(id);
            return teacher.Publications.OfType<Thesis>();
        }

        public async Task<IEnumerable<Article>> GetAllArticles(Guid id)
        {
            Teacher? teacher = await GetTeacherWithPublications(id);
            return teacher.Publications.OfType<Article>();
        }

        public async Task<Publication> Get(Guid id, Guid entityId)
        {
            Teacher? teacher = await GetTeacherWithPublications(id);
            return teacher.Publications.SingleOrDefault(x => x.Id == entityId) ?? throw new NotFoundByIdException();
        }

        public async Task<Monography> GetMonography(Guid id, Guid entityId)
        {
            Teacher? teacher = await GetTeacherWithPublications(id);
            return teacher.Publications.OfType<Monography>().SingleOrDefault(x => x.Id == entityId) ?? throw new NotFoundByIdException();
        }

        public async Task<Thesis> GetThesis(Guid id, Guid entityId)
        {
            Teacher? teacher = await GetTeacherWithPublications(id);
            return teacher.Publications.OfType<Thesis>().SingleOrDefault(x => x.Id == entityId) ?? throw new NotFoundByIdException();
        }

        public async Task<Article> GetArticle(Guid id, Guid entityId)
        {
            Teacher? teacher = await GetTeacherWithPublications(id);
            return teacher.Publications.OfType<Article>().SingleOrDefault(x => x.Id == entityId) ?? throw new NotFoundByIdException();
        }

        public async Task<Guid> AddMonography(Guid id, Monography entity)
        {
            return await AddPublication(id, entity, entity.CoAuthors.Select(c => c.Id).ToList(), entity.Files.Select(f => f.Id).ToList());
        }

        public async Task<Guid> AddThesis(Guid id, Thesis entity)
        {
            return await AddPublication(id, entity, entity.CoAuthors.Select(c => c.Id).ToList(), entity.Files.Select(f => f.Id).ToList());
        }

        public async Task<Guid> AddArticle(Guid id, Article entity)
        {
            return await AddPublication(id, entity, entity.CoAuthors.Select(c => c.Id).ToList(), entity.Files.Select(f => f.Id).ToList());
        }

        public async Task UpdateMonography(Guid id, Guid publicationId, Monography entity)
        {
            Teacher? teacher = await GetTeacherWithPublications(id);
            Monography monography = teacher.Publications.OfType<Monography>().SingleOrDefault(x => x.Id == publicationId) ?? throw new NotFoundByIdException();
            monography.Name = entity.Name;
            monography.YearPublication = entity.YearPublication;
            monography.CoAuthors.Clear();
            monography.CoAuthors.Add(teacher);
            var coAuthorToRemove = entity.CoAuthors.FirstOrDefault(c => c.Id == id);
            entity.CoAuthors.Remove(coAuthorToRemove);
            foreach (var coAuthor in entity.CoAuthors.DistinctBy(c => c.Id))
            {
                db.Teachers.Attach(coAuthor);
                monography.CoAuthors.Add(coAuthor);
            }
            monography.Files.Clear();
            foreach (var file in entity.Files.DistinctBy(f => f.Id))
            {
                db.UserFiles.Attach(file);
                monography.Files.Add(file);
            }
            monography.Publisher = entity.Publisher;
            monography.Circulation = entity.Circulation;
            monography.CountPages = entity.CountPages;
            await db.SaveChangesAsync();
        }

        public async Task UpdateThesis(Guid id, Guid publicationId, Thesis entity)
        {
            Teacher? teacher = await GetTeacherWithPublications(id);
            Thesis thesis = teacher.Publications.OfType<Thesis>().SingleOrDefault(x => x.Id == publicationId) ?? throw new NotFoundByIdException();
            thesis.Name = entity.Name;
            thesis.YearPublication = entity.YearPublication;
            thesis.CoAuthors = entity.CoAuthors;
            thesis.Files = entity.Files;
            thesis.BeginPage = entity.BeginPage;
            thesis.EndPage = entity.EndPage;
            thesis.CountPages = entity.CountPages;
            thesis.Collection = entity.Collection;
            thesis.DateEvent = entity.DateEvent;
            thesis.Place = entity.Place;
            thesis.Type = entity.Type;
            await db.SaveChangesAsync();
        }

        public async Task UpdateArticle(Guid id, Guid publicationId, Article entity)
        {
            Teacher? teacher = await GetTeacherWithPublications(id);
            Article article = teacher.Publications.OfType<Article>().SingleOrDefault(x => x.Id == publicationId) ?? throw new NotFoundByIdException();
            article.Name = entity.Name;
            article.YearPublication = entity.YearPublication;
            article.CoAuthors = entity.CoAuthors;
            article.Files = entity.Files;
            article.IssueNumber = entity.IssueNumber;
            article.BeginPage = entity.BeginPage;
            article.EndPage = entity.EndPage;
            article.Journal = entity.Journal;
            article.PrintedSheets = entity.PrintedSheets;
            article.URL = entity.URL;
            await db.SaveChangesAsync();
        }

        public async Task Delete(Guid id, Guid entityId)
        {
            Teacher? teacher = await GetTeacherWithPublications(id);
            var publication = teacher.Publications.SingleOrDefault(x => x.Id == entityId) ?? throw new NotFoundByIdException();
            teacher.Publications.Remove(publication);
            await db.SaveChangesAsync();
        }

        private async Task<Teacher> GetTeacherWithPublications(Guid id)
        {
            return await db.Teachers.Include(x => x.Publications).SingleOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundByIdException();
        }

        public async Task<Guid> AddPublication<T>(Guid teacherId, T publication, List<Guid> coAuthorIds, List<Guid> fileIds) where T : Publication
        {
            var teacher = await GetTeacherWithPublications(teacherId);

            if (teacher.Publications.Any(p => p.Name == publication.Name &&
                                           p.YearPublication == publication.YearPublication))
            {
                throw new AlreadyExistException();
            }
            publication.CoAuthors = await db.Teachers.Where(t => coAuthorIds.Contains(t.Id)).ToListAsync();
            publication.Files = await db.UserFiles.Where(f => fileIds.Contains(f.Id)).ToListAsync();
            teacher.Publications.Add(publication);
            await db.SaveChangesAsync();
            return publication.Id;
        }

        private async Task UpdatePublication<T>(Guid teacherId, Guid publicationId, T entity) where T : Publication
        {
            Teacher? teacher = await GetTeacherWithPublications(teacherId);
            var publication = teacher.Publications.OfType<T>().SingleOrDefault(x => x.Id == publicationId) ?? throw new NotFoundByIdException();
            mapper.Map(entity, publication);
            await db.SaveChangesAsync();
        }
    }
}
