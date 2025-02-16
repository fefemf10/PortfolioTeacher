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
    public class PublicationController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ITeacherPublicationService tps;
        public PublicationController(IMapper mapper, ITeacherPublicationService tps)
        {
            this.mapper = mapper;
            this.tps = tps;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guid>>> GetAll(Guid id)
        {
            return Ok(await tps.GetAll(id));
        }
        [HttpGet("[action]/{publicationId:guid}")]
        public async Task<ActionResult<ResponsePublication>> Get(Guid id, Guid publicationId)
        {
            return Ok(mapper.Map<ResponsePublication>(await tps.Get(id, publicationId)));
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Add(Guid id, [Required][FromBody] RequestPublication publication)
        {
            return Ok(await tps.Add(id, mapper.Map<Publication>(publication)));
        }
        [HttpPut]
        public async Task<ActionResult> Update(Guid id, [Required][FromBody] RequestPublication publication)
        {
            await tps.Update(id, mapper.Map<Publication>(publication));
            return Ok();
        }
        [HttpDelete("[action]/{publicationId:guid}")]
        public async Task<ActionResult> Delete(Guid id, Guid publicationId)
        {
            await tps.Delete(id, publicationId);
            return Ok();
        }
    }
}
