using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Minio;
using Minio.DataModel.Args;
using Minio.Exceptions;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;
using static System.Net.WebRequestMethods;

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]/{publicationId:guid}")]
    [ApiController]
    public class PublicationController(IPublicationService ps, IMinioClient minioClient, IOptions<MinioConfig> config) : ControllerBase
    {
        [HttpGet("files/{fileId:guid}")]
        public async Task<ActionResult> GetFile(Guid publicationId, Guid fileId)
        {
            UserFile? userFile = await ps.GetFile(publicationId, fileId);
            if (userFile is null)
                return BadRequest();
            var memoryStream = new MemoryStream();
            GetObjectArgs getObjectArgs = new GetObjectArgs()
                .WithBucket(config.Value.BucketName)
                .WithObject($"publications/{publicationId}/files/{fileId}")
                .WithCallbackStream(stream =>
                {
                    stream.CopyTo(memoryStream);
                    memoryStream.Position = 0;
                });
            try
            {
                var stat = await minioClient.GetObjectAsync(getObjectArgs);
                return File(memoryStream, stat.ContentType, userFile?.Name);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("files")]
        public async Task<ActionResult<List<UserFile>>> GetFiles(Guid publicationId)
        {
            List<UserFile> userFiles = await ps.GetFiles(publicationId);
            return Ok(userFiles);
        }
        [HttpPost("files")]
        public async Task<ActionResult<UserFile>> UploadFile(Guid publicationId, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest();
            UserFile userFile = new()
            {
                FileType = UserFile.GetFileTypeFromMime(file.ContentType),
                Name = file.FileName,
                Size = file.Length
            };
            PutObjectArgs putObjectArgs = new PutObjectArgs()
                .WithBucket(config.Value.BucketName)
                .WithObject($"publications/{publicationId}/files/{userFile.Id}")
                .WithStreamData(file.OpenReadStream())
                .WithObjectSize(file.Length)
                .WithContentType(file.ContentType);
            try
            {
                await minioClient.PutObjectAsync(putObjectArgs);
                await ps.UploadFile(publicationId, userFile);
                return Ok(userFile);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("files/{fileId:guid}")]
        public async Task<ActionResult> DeleteFile(Guid publicationId, Guid fileId)
        {
            UserFile? userFile = await ps.GetFile(publicationId, fileId);
            if (userFile is null)
                return BadRequest();
            var memoryStream = new MemoryStream();
            List<string> objects = new List<string>() { $"publications/{publicationId}/files/{fileId}" };
            RemoveObjectsArgs removeObjectsArgs = new RemoveObjectsArgs()
                .WithBucket(config.Value.BucketName)
                .WithObjects(objects);
            try
            {
                await minioClient.RemoveObjectsAsync(removeObjectsArgs);
                await ps.RemoveFile(userFile);
                return Ok();
            }
            catch (MinioException ex)
            {
                return StatusCode(StatusCodes.Status502BadGateway, "Storage service unavailable");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
