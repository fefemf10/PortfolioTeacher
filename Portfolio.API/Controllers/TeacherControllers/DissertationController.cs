using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.ViewModels.Request;
using Portfolio.Application.ViewModels.Response;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.API.Controllers.TeacherControllers
{
    [Route("api/Teacher/{id:guid}/[controller]")]
    [ApiController]
    public class DissertationController(IMapper mapper, ITeacherDissertationService tds) : ControllerBase
    {
        [HttpGet("short")]
        public async Task<ActionResult<IEnumerable<ShortItem>>> GetShortAll(Guid id)
        {
            return Ok(await tds.GetShortAll(id));
        }
        [HttpGet("ids")]
        public async Task<ActionResult<IEnumerable<Guid>>> GetAll(Guid id)
        {
            return Ok(await tds.GetAll(id));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseDissertation>>> GetAllEntities(Guid id)
        {
            return Ok(mapper.Map<IEnumerable<ResponseDissertation>>(await tds.GetAllEntities(id)));
        }
        [HttpGet("{dissertationId:guid}")]
        public async Task<ActionResult<ResponseDissertation>> Get(Guid id, Guid dissertationId)
        {
            return Ok(mapper.Map<ResponseDissertation>(await tds.Get(id, dissertationId)));
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Add(Guid id, [Required][FromBody] RequestDissertation requestDissertation)
        {
            return Ok(await tds.Add(id, mapper.Map<Dissertation>(requestDissertation)));
        }
        [HttpPut("{entityId:guid}")]
        public async Task<ActionResult> Update(Guid id, Guid entityId, [Required][FromBody] RequestDissertation requestDissertation)
        {
            Dissertation dissertation = mapper.Map<Dissertation>(requestDissertation);
            dissertation.Id = entityId;
            await tds.Update(id, dissertation);
            return Ok();
        }
        [HttpDelete("{dissertationId:guid}")]
        public async Task<ActionResult> Delete(Guid id, Guid dissertationId)
        {
            await tds.Delete(id, dissertationId);
            return Ok();
        }
    }
}