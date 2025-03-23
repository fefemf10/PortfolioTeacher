using Microsoft.AspNetCore.Mvc;
using Portfolio.Domain.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Portfolio.Domain.Services;
using Portfolio.Application.ViewModels.Request;
using Portfolio.Application.ViewModels.Response;

namespace Portfolio.API.Controllers.TeacherControllers
{
    [Authorize]
    [Route("api/Teacher/{id:guid}/[controller]")]
    [ApiController]
    public class ProfessionalDevelopmentController(IMapper mapper, ITeacherProfessionalDevelopmentService tpds) : ControllerBase
    {
        [HttpGet("/ids")]
        public async Task<ActionResult<IEnumerable<Guid>>> GetAll(Guid id)
        {
            return Ok(await tpds.GetAll(id));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseProfessionalDevelopment>>> GetAllEntities(Guid id)
        {
            return Ok(mapper.Map<IEnumerable<ResponseProfessionalDevelopment>>(await tpds.GetAllEntities(id)));
        }
        [HttpGet("{professionalDevelopementId:guid}")]
        public async Task<ActionResult<ResponseProfessionalDevelopment>> Get(Guid id, Guid professionalDevelopementId)
        {
            return Ok(mapper.Map<ResponseProfessionalDevelopment>(await tpds.Get(id, professionalDevelopementId)));
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Add(Guid id, [Required][FromBody] RequestProfessionalDevelopment professionalDevelopment)
        {
            return Ok(await tpds.Add(id, mapper.Map<ProfessionalDevelopment>(professionalDevelopment)));
        }
        [HttpPut]
        public async Task<ActionResult> Update(Guid id, [Required][FromBody] RequestProfessionalDevelopment professionalDevelopment)
        {
            await tpds.Update(id, mapper.Map<ProfessionalDevelopment>(professionalDevelopment));
            return Ok();
        }
        [HttpDelete("{professionalDevelopementId:guid}")]
        public async Task<ActionResult> Delete(Guid id, Guid professionalDevelopementId)
        {
            await tpds.Delete(id, professionalDevelopementId);
            return Ok();
        }
    }
}
