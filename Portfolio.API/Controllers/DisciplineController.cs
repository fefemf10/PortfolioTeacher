using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.ViewModels.Request;
using Portfolio.Application.ViewModels.Response;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;
using System.Xml.Linq;

namespace Portfolio.API.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class DisciplineController : ControllerBase
	{
        private readonly IMapper mapper;
        private readonly IDisciplineService disciplineService;
		public DisciplineController(IMapper mapper, IDisciplineService disciplineService)
		{
			this.mapper = mapper;
			this.disciplineService = disciplineService;
		}
        [HttpGet]
        public async Task<ActionResult<List<ResponseDiscipline>>> GetAll()
        {
            return Ok(mapper.Map<IEnumerable<ResponseDiscipline>>(await disciplineService.GetAll()));
        }
		[HttpGet("[action]/{id:guid}")]
		public async Task<ActionResult<List<ResponseDiscipline>>> Get(Guid id)
		{
			return Ok(mapper.Map<ResponseDiscipline>(await disciplineService.GetById(id)));
		}
		[HttpPost]
		public async Task<ActionResult<Guid>> Add(RequestAddDiscipline requestAddDiscipline)
		{
			return Ok(await disciplineService.Add(mapper.Map<Discipline>(requestAddDiscipline)));
		}
        [HttpPost]
        public async Task<ActionResult<Guid>> Update(RequestUpdateDiscipline requestUpdateDiscipline)
        {
			await disciplineService.Update(mapper.Map<Discipline>(requestUpdateDiscipline));
            return Ok();
        }
        [HttpDelete]
		public async Task<ActionResult> DeleteById(Guid id)
		{
			await disciplineService.DeleteById(id);
			return Ok();
		}
	}
}
