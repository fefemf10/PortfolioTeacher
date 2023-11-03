using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioShared.Models;
using PortfolioShared.ViewModels.Response;

namespace IdentityServer.Controllers
{
	[Authorize]
	[Route("[controller]/[action]")]
	[ApiController]
	public class DisciplineController : ControllerBase
	{
		private readonly ApplicationContext db;
		public DisciplineController(ApplicationContext db)
		{
			this.db = db;
		}
		[HttpGet]
		public ActionResult<ResponseDiscipline[]> GetDisciplines()
		{
			return Ok(db.Disciplines.Select(x => new ResponseDiscipline(x.Id, x.Name)).ToArray());
		}
		[HttpGet]
		public ActionResult<ResponseDiscipline[]> GetDiscipline(int id)
		{
			Discipline? discipline = db.Disciplines.First(x => x.Id == id);
			if (discipline is null)
				return BadRequest();
			return Ok(new ResponseDiscipline(discipline.Id, discipline.Name));
		}
	}
}
