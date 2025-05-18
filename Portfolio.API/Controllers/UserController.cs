using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Minio;
using Minio.DataModel.Args;
using Portfolio.Application.ViewModels.Response;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;

namespace Portfolio.API.Cotrollers
{
	[AllowAnonymous]
	[Route("api/[controller]")]
	[ApiController]
	public class UserController(IMapper mapper, IUserService userService, IMinioClient minioClient, IOptions<MinioConfig> config) : ControllerBase
	{
		[HttpGet("{id:guid}")]
		public async Task<ActionResult<ResponseUser>> GetInfo(Guid id)
		{
			User user = await userService.GetById(id);
			return Ok(mapper.Map<ResponseUser>(user));
		}
        [HttpGet("{id:guid}/avatar")]
        public async Task<ActionResult> GetAvatarFile(Guid id)
        {
            UserFile? avatar = await userService.GetAvatar(id);
            if (avatar is null)
                return BadRequest();
            var memoryStream = new MemoryStream();
            GetObjectArgs getObjectArgs = new GetObjectArgs()
                .WithBucket(config.Value.BucketName)
                .WithObject($"users/{id}/{avatar?.Id}")
                .WithCallbackStream(stream =>
                {
                    stream.CopyTo(memoryStream);
                    memoryStream.Position = 0;
                });
            try
            {
                var stat = await minioClient.GetObjectAsync(getObjectArgs);
                return File(memoryStream, stat.ContentType, avatar?.Name);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("{id:guid}/avatar")]
        public async Task<ActionResult<UserFile>> UploadAvatarFile(Guid id, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest();
            UserFile userFile = new()
            {
                FileType = UserFile.GetFileTypeFromMime(file.ContentType),
                Name = file.Name,
                Size = file.Length
            };
            PutObjectArgs putObjectArgs = new PutObjectArgs()
                .WithBucket(config.Value.BucketName)
                .WithObject($"users/{id}/{userFile.Id}")
                .WithStreamData(file.OpenReadStream())
                .WithFileName(file.Name)
                .WithObjectSize(file.Length)
                .WithContentType(file.ContentType);
            try
            {
                await minioClient.PutObjectAsync(putObjectArgs);
                await userService.UploadAvatar(id, userFile);
                return Ok(userFile);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
