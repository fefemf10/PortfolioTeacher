using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Models;
using Portfolio.Application.ViewModels.Response;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Portfolio.Application.ViewModels.Request;
using Portfolio.Domain.Services;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.API.Controllers.TeacherControllers
{
    [Authorize]
    [Route("api/Teacher/{id:guid}/[controller]")]
    [ApiController]
    public class DisciplineController : ControllerBase
	{
        private readonly IMapper mapper;
        private readonly ITeacherDisciplineService tds;
        private readonly IDisciplineService ds;
        public DisciplineController(IMapper mapper, ITeacherDisciplineService tds, IDisciplineService ds)
        {
            this.mapper = mapper;
            this.tds = tds;
            this.ds = ds;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guid>>> GetAll(Guid id)
        {
            return Ok(await tds.GetAll(id));
        }
        [HttpGet("[action]/{disciplineId:guid}")]
        public async Task<ActionResult<ResponseDiscipline>> Get(Guid id, Guid disciplineId)
        {
            return Ok(mapper.Map<ResponseDiscipline>(await tds.Get(id, disciplineId)));
        }
        [HttpPost("[action]/{disciplineId:guid}")]
        public async Task<ActionResult<Guid>> Add(Guid id, Guid disciplineId)
        {
            return Ok(await tds.Add(id, await ds.GetById(disciplineId)));
        }
        [HttpDelete("[action]/{disciplineId:guid}")]
        public async Task<ActionResult> Delete(Guid id, Guid disciplineId)
        {
            await tds.Delete(id, disciplineId);
            return Ok();
        }
    }
}
