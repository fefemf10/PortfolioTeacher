using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioShared.Models;
using PortfolioShared.ViewModels.Response;
using System.Xml.Linq;

namespace IdentityServer.Controllers
{
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
		public ActionResult<ResponseDiscipline[]> Get(Guid? id)
		{
			if (id is null)
				return Ok(db.Disciplines.Select(x => new ResponseDiscipline(x.Id, x.Name)).ToArray());
			Discipline? discipline = db.Disciplines.FirstOrDefault(x => x.Id == id);
			if (discipline is null)
				return BadRequest();
			return Ok(new ResponseDiscipline(discipline.Id, discipline.Name));
		}
		[HttpPost]
		public ActionResult<ResponseDiscipline> Add(string name)
		{
			Discipline? discipline = db.Disciplines.FirstOrDefault(x => x.Name == name);
			if (discipline is not null)
				return BadRequest();
			discipline = new Discipline { Name = name };
			db.Disciplines.Add(discipline);
			db.SaveChanges();
			return Ok(new ResponseDiscipline(discipline.Id, discipline.Name));
		}
		[HttpDelete]
		public async Task<ActionResult> DeleteByIdAsync(Guid id)
		{
			Discipline? discipline = await db.Disciplines.FindAsync(id);
			if (discipline is null)
				return NotFound();

			db.Disciplines.Remove(discipline);
			await db.SaveChangesAsync();
			return Ok();
		}
	}
}
