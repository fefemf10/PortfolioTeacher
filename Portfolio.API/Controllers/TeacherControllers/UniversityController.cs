using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Models;
using Portfolio.Application.ViewModels.Request;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Portfolio.Application.ViewModels.Response;
using Portfolio.Domain.Services;

namespace Portfolio.API.Controllers.TeacherControllers
{
    [Authorize]
    [Route("api/Teacher/{id:guid}/[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase
	{
        private readonly IMapper mapper;
        private readonly ITeacherUniversityService tus;
        public UniversityController(IMapper mapper, ITeacherUniversityService tus)
        {
            this.mapper = mapper;
            this.tus = tus;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guid>>> GetAll(Guid id)
        {
            return Ok(await tus.GetAll(id));
        }
        [HttpGet("[action]/{universityId:guid}")]
        public async Task<ActionResult<ResponseUniversity>> Get(Guid id, Guid universityId)
        {
            return Ok(mapper.Map<ResponseUniversity>(await tus.Get(id, universityId)));
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Add(Guid id, [Required][FromBody] RequestUniversity university)
        {
            return Ok(await tus.Add(id, mapper.Map<University>(university)));
        }
        [HttpPut]
        public async Task<ActionResult> Update(Guid id, [Required][FromBody] RequestUniversity university)
        {
            await tus.Update(id, mapper.Map<University>(university));
            return Ok();
        }
        [HttpDelete("[action]/{universityId:guid}")]
        public async Task<ActionResult> Delete(Guid id, Guid universityId)
        {
            await tus.Delete(id, universityId);
            return Ok();
        }
    }
}
