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
    [Route("api/Teacher/{id:guid}/[controller]")]
    [ApiController]
    public class DisciplineController(IMapper mapper, ITeacherDisciplineService tds) : ControllerBase
	{
        [HttpGet("ids")]
        public async Task<ActionResult<IEnumerable<Guid>>> GetAll(Guid id)
        {
            return Ok(await tds.GetAll(id));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseDiscipline>>> GetAllEntities(Guid id)
        {
            return Ok(mapper.Map<IEnumerable<ResponseDiscipline>>(await tds.GetAllEntities(id)));
        }
        [HttpGet("{disciplineId:guid}")]
        public async Task<ActionResult<ResponseDiscipline>> Get(Guid id, Guid disciplineId)
        {
            return Ok(mapper.Map<ResponseDiscipline>(await tds.Get(id, disciplineId)));
        }
        [HttpPost("{disciplineId:guid}")]
        public async Task<ActionResult> Add(Guid id, Guid disciplineId)
        {
            await tds.Add(id, disciplineId);
            return Ok();
        }
        [HttpDelete("{disciplineId:guid}")]
        public async Task<ActionResult> Delete(Guid id, Guid disciplineId)
        {
            await tds.Delete(id, disciplineId);
            return Ok();
        }
    }
}
