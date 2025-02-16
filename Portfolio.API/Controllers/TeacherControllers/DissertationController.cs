using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.ViewModels.Request;
using Portfolio.Application.ViewModels.Response;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.API.Controllers.TeacherControllers
{
    [Authorize]
    [Route("api/Teacher/{id:guid}/[controller]")]
    [ApiController]
    public class DissertationController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ITeacherDissertationService tds;
        public DissertationController(IMapper mapper, ITeacherDissertationService tds)
        {
            this.mapper = mapper;
            this.tds = tds;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guid>>> GetAll(Guid id)
        {
            return Ok(await tds.GetAll(id));
        }
        [HttpGet("[action]/{dissertationId:guid}")]
        public async Task<ActionResult<ResponseDissertation>> Get(Guid id, Guid dissertationId)
        {
            return Ok(mapper.Map<ResponseDissertation>(await tds.Get(id, dissertationId)));
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Add(Guid id, [Required][FromBody] RequestDissertation requestDissertation)
        {
            return Ok(await tds.Add(id, mapper.Map<Dissertation>(requestDissertation)));
        }
        [HttpPut]
        public async Task<ActionResult> Update(Guid id, [Required][FromBody] RequestDissertation requestDissertation)
        {
            await tds.Update(id, mapper.Map<Dissertation>(requestDissertation));
            return Ok();
        }
        [HttpDelete("[action]/{dissertationId:guid}")]
        public async Task<ActionResult> Delete(Guid id, Guid dissertationId)
        {
            await tds.Delete(id, dissertationId);
            return Ok();
        }
    }
}
