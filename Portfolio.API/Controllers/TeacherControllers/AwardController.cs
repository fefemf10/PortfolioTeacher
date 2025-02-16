using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.ViewModels.Request;
using Portfolio.Application.ViewModels.Response;
using Portfolio.Application.Services.TeacherService;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;
using System;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.API.Controllers.TeacherControllers
{
    [Authorize]
    [Route("api/Teacher/{id:guid}/[controller]")]
    [ApiController]
    public class AwardController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ITeacherAwardService tas;
        public AwardController(IMapper mapper, ITeacherAwardService tas)
        {
            this.mapper = mapper;
            this.tas = tas;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guid>>> GetAll(Guid id)
        {
            return Ok(await tas.GetAll(id));
        }
        [HttpGet("[action]/{awardId:guid}")]
        public async Task<ActionResult<ResponseAward>> Get(Guid id, Guid awardId)
        {
            return Ok(mapper.Map<ResponseAward>(await tas.Get(id, awardId)));
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Add(Guid id, [Required][FromBody] RequestAward requestAward)
        {
            return Ok(await tas.Add(id, mapper.Map<Award>(requestAward)));
        }
        [HttpPut]
        public async Task<ActionResult> Update(Guid id, [Required][FromBody] RequestAward requestAward)
        {
            await tas.Update(id, mapper.Map<Award>(requestAward));
            return Ok();
        }
        [HttpDelete("[action]/{awardId:guid}")]
        public async Task<ActionResult> Delete(Guid id, Guid awardId)
        {
            await tas.Delete(id, awardId);
            return Ok();
        }
    }
}
