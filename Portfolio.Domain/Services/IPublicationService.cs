using Portfolio.Domain.Models;

namespace Portfolio.Domain.Services
{
    public interface IPublicationService
    {
        Task<UserFile?> GetFile(Guid publicationId, Guid fileId);
        Task UploadFile(Guid publicationId, UserFile userFile);
        Task<List<UserFile>> GetFiles(Guid publicationId);
        Task RemoveFile(UserFile userFile);
    }
}
