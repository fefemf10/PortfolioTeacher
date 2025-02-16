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
    public class ScienceProjectController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ITeacherScienceProjectService tsps;
        public ScienceProjectController(IMapper mapper, ITeacherScienceProjectService tsps)
        {
            this.mapper = mapper;
            this.tsps = tsps;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guid>>> GetAll(Guid id)
        {
            return Ok(await tsps.GetAll(id));
        }
        [HttpGet("[action]/{scienceProjectId:guid}")]
        public async Task<ActionResult<ResponseScienceProject>> Get(Guid id, Guid scienceProjectId)
        {
            return Ok(mapper.Map<ResponseScienceProject>(await tsps.Get(id, scienceProjectId)));
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Add(Guid id, [Required][FromBody] RequestScienceProject requestScienceProject)
        {
            return Ok(await tsps.Add(id, mapper.Map<ScienceProject>(requestScienceProject)));
        }
        [HttpPut]
        public async Task<ActionResult> Update(Guid id, [Required][FromBody] RequestScienceProject requestScienceProject)
        {
            await tsps.Update(id, mapper.Map<ScienceProject>(requestScienceProject));
            return Ok();
        }
        [HttpDelete("[action]/{scienceProjectId:guid}")]
        public async Task<ActionResult> Delete(Guid id, Guid scienceProjectId)
        {
            await tsps.Delete(id, scienceProjectId);
            return Ok();
        }
    }
}
