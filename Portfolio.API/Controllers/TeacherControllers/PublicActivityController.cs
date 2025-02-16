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
    public class PublicActivityController : ControllerBase
	{
        private readonly IMapper mapper;
        private readonly ITeacherPublicActivityService tpas;
        public PublicActivityController(IMapper mapper, ITeacherPublicActivityService tpas)
        {
            this.mapper = mapper;
            this.tpas = tpas;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guid>>> GetAll(Guid id)
        {
            return Ok(await tpas.GetAll(id));
        }
        [HttpGet("[action]/{publicActivityId:guid}")]
        public async Task<ActionResult<ResponsePublicActivity>> Get(Guid id, Guid publicActivityId)
        {
            return Ok(mapper.Map<ResponsePublicActivity>(await tpas.Get(id, publicActivityId)));
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Add(Guid id, [Required][FromBody] RequestPublicActivity publicActivity)
        {
            return Ok(await tpas.Add(id, mapper.Map<PublicActivity>(publicActivity)));
        }
        [HttpPut]
        public async Task<ActionResult> Update(Guid id, [Required][FromBody] RequestPublicActivity publicActivity)
        {
            await tpas.Update(id, mapper.Map<PublicActivity>(publicActivity));
            return Ok();
        }
        [HttpDelete("[action]/{publicActivityId:guid}")]
        public async Task<ActionResult> Delete(Guid id, Guid publicActivityId)
        {
            await tpas.Delete(id, publicActivityId);
            return Ok();
        }
    }
}
