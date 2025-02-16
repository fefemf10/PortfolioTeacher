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
    public class WorkController : ControllerBase
	{
        private readonly IMapper mapper;
        private readonly ITeacherWorkService tws;
        public WorkController(IMapper mapper, ITeacherWorkService tws)
        {
            this.mapper = mapper;
            this.tws = tws;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guid>>> GetAll(Guid id)
        {
            return Ok(await tws.GetAll(id));
        }
        [HttpGet("[action]/{workId:guid}")]
        public async Task<ActionResult<ResponseWork>> Get(Guid id, Guid workId)
        {
            return Ok(mapper.Map<ResponseWork>(await tws.Get(id, workId)));
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Add(Guid id, [Required][FromBody] RequestWork work)
        {
            return Ok(await tws.Add(id, mapper.Map<Work>(work)));
        }
        [HttpPut]
        public async Task<ActionResult> Update(Guid id, [Required][FromBody] RequestWork work)
        {
            await tws.Update(id, mapper.Map<Work>(work));
            return Ok();
        }
        [HttpDelete("[action]/{workId:guid}")]
        public async Task<ActionResult> Delete(Guid id, Guid workId)
        {
            await tws.Delete(id, workId);
            return Ok();
        }
    }
}
