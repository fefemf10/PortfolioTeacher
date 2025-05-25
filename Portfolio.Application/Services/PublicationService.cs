using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Exceptions;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;
using Portfolio.Infrastructure;

namespace Portfolio.Application.Services
{
    public class PublicationService(ApplicationContext db) : IPublicationService
    {
        public async Task<UserFile?> GetFile(Guid publicationId, Guid fileId)
        {
            var publication = await db.Publications.AsNoTracking().Include(x => x.Files).SingleOrDefaultAsync(x => x.Id == publicationId) ?? throw new NotFoundByIdException();
            return publication.Files.SingleOrDefault(x => x.Id == fileId) ?? throw new NotFoundByIdException();
        }

        public async Task UploadFile(Guid publicationId, UserFile userFile)
        {
            var publication = await db.Publications.Include(x => x.Files).Include(x => x.CoAuthors).SingleOrDefaultAsync(x => x.Id == publicationId) ?? throw new NotFoundByIdException();
            db.UserFiles.Add(userFile);
            publication.Files.Add(userFile);
            await db.SaveChangesAsync();
        }

        public async Task<List<UserFile>> GetFiles(Guid publicationId)
        {
            var publication = await db.Publications.AsNoTracking().Include(x => x.Files).SingleOrDefaultAsync(x => x.Id == publicationId) ?? throw new NotFoundByIdException();
            return publication.Files;
        }

        public async Task RemoveFile(UserFile userFile)
        {
            db.UserFiles.Remove(userFile);
            await db.SaveChangesAsync();
        }
    }
}
