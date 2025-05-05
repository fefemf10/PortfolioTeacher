using Microsoft.AspNetCore.Mvc;
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
    public class PublicationController(IMapper mapper, ITeacherPublicationService tps) : ControllerBase
    {
        #region Common Publication Endpoints
        [HttpGet("ids")]
        public async Task<ActionResult<IEnumerable<Guid>>> GetAll(Guid id)
        {
            return Ok(await tps.GetAll(id));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponsePublication>>> GetAllEntities(Guid id)
        {
            return Ok(mapper.Map<IEnumerable<ResponsePublication>>(await tps.GetAllEntities(id)));
        }
        [HttpGet("{publicationId:guid}")]
        public async Task<ActionResult<ResponsePublication>> Get(Guid id, Guid publicationId)
        {
            return Ok(mapper.Map<ResponsePublication>(await tps.Get(id, publicationId)));
        }
        [HttpDelete("{publicationId:guid}")]
        public async Task<ActionResult> Delete(Guid id, Guid publicationId)
        {
            await tps.Delete(id, publicationId);
            return Ok();
        }
        #endregion

        #region Dissertation Endpoints
        [HttpGet("Dissertations")]
        public async Task<ActionResult<IEnumerable<ResponseDissertation>>> GetAllDissertations(Guid id)
        {
            return Ok(mapper.Map<IEnumerable<ResponseDissertation>>(await tps.GetAllDissertations(id)));
        }
        [HttpGet("Dissertation/{publicationId:guid}")]
        public async Task<ActionResult<ResponseDissertation>> GetDissertation(Guid id, Guid publicationId)
        {
            return Ok(mapper.Map<ResponseDissertation>(await tps.GetDissertation(id, publicationId)));
        }
        [HttpPost("Dissertation")]
        public async Task<ActionResult<Guid>> AddDissertation(Guid id, [Required][FromBody] RequestDissertation publication)
        {
            return Ok(await tps.AddDissertation(id, mapper.Map<Dissertation>(publication)));
        }
        [HttpPut("Dissertation")]
        public async Task<ActionResult> UpdateDissertation(Guid id, [Required][FromBody] RequestDissertation publication)
        {
            await tps.UpdateDissertation(id, mapper.Map<Dissertation>(publication));
            return Ok();
        }
        #endregion

        #region Monography Endpoints
        [HttpGet("Monographies")]
        public async Task<ActionResult<IEnumerable<ResponseMonography>>> GetAllMonographies(Guid id)
        {
            return Ok(mapper.Map<IEnumerable<ResponseMonography>>(await tps.GetAllMonographies(id)));
        }
        [HttpGet("Monography/{publicationId:guid}")]
        public async Task<ActionResult<ResponseMonography>> GetMonography(Guid id, Guid publicationId)
        {
            return Ok(mapper.Map<ResponseMonography>(await tps.GetMonography(id, publicationId)));
        }
        [HttpPost("Monography")]
        public async Task<ActionResult<Guid>> AddMonography(Guid id, [Required][FromBody] RequestMonography publication)
        {
            return Ok(await tps.AddMonography(id, mapper.Map<Monography>(publication)));
        }
        [HttpPut("Monography")]
        public async Task<ActionResult> UpdateMonography(Guid id, [Required][FromBody] RequestMonography publication)
        {
            await tps.UpdateMonography(id, mapper.Map<Monography>(publication));
            return Ok();
        }
        #endregion

        #region Thesis Endpoints
        [HttpGet("Theses")]
        public async Task<ActionResult<IEnumerable<ResponseThesis>>> GetAllTheses(Guid id)
        {
            return Ok(mapper.Map<IEnumerable<ResponseThesis>>(await tps.GetAllTheses(id)));
        }
        [HttpGet("Thesis/{publicationId:guid}")]
        public async Task<ActionResult<ResponseThesis>> GetThesis(Guid id, Guid publicationId)
        {
            return Ok(mapper.Map<ResponseThesis>(await tps.GetThesis(id, publicationId)));
        }
        [HttpPost("Thesis")]
        public async Task<ActionResult<Guid>> AddThesis(Guid id, [Required][FromBody] RequestThesis publication)
        {
            return Ok(await tps.AddThesis(id, mapper.Map<Thesis>(publication)));
        }
        [HttpPut("Thesis")]
        public async Task<ActionResult> UpdateThesis(Guid id, [Required][FromBody] RequestThesis publication)
        {
            await tps.UpdateThesis(id, mapper.Map<Thesis>(publication));
            return Ok();
        }
        #endregion

        #region Article Endpoints
        [HttpGet("Articles")]
        public async Task<ActionResult<IEnumerable<ResponseArticle>>> GetAllArticles(Guid id)
        {
            return Ok(mapper.Map<IEnumerable<ResponseArticle>>(await tps.GetAllArticles(id)));
        }
        [HttpGet("Article/{publicationId:guid}")]
        public async Task<ActionResult<ResponseArticle>> GetArticle(Guid id, Guid publicationId)
        {
            return Ok(mapper.Map<ResponseArticle>(await tps.GetArticle(id, publicationId)));
        }
        [HttpPost("Article")]
        public async Task<ActionResult<Guid>> AddArticle(Guid id, [Required][FromBody] RequestArticle publication)
        {
            return Ok(await tps.AddArticle(id, mapper.Map<Article>(publication)));
        }
        [HttpPut("Article")]
        public async Task<ActionResult> UpdateArticle(Guid id, [Required][FromBody] RequestArticle publication)
        {
            await tps.UpdateArticle(id, mapper.Map<Article>(publication));
            return Ok();
        }
        #endregion
    }
}