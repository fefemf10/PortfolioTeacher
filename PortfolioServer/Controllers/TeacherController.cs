using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioShared.Models;
using PortfolioShared.ViewModels.Response;

namespace PortfolioServer.Controllers
{
	[Authorize]
	[Route("[controller]")]
	[ApiController]
	public class TeacherController : ControllerBase
	{
		private readonly ApplicationContext db;
		public TeacherController(ApplicationContext db)
		{
			this.db = db;
		}
		[HttpGet("{guid:guid}/[action]")]
		public ActionResult<ResponseDiscipline[]> GetDisciplines(Guid guid)
		{
			Teacher? teacher = db.Teachers.Include(x => x.Disciplines).SingleOrDefault(user => user.Id == guid);
			if (teacher is null)
				return BadRequest();
			return Ok(Array.ConvertAll(teacher.Disciplines.ToArray(), discipline => new ResponseDiscipline(discipline.Id, discipline.Name)));
		}
		[HttpPost("{guid:guid}/[action]/{id:int}")]
		public ActionResult AddDiscipline(Guid guid, int id)
		{
			Teacher? teacher = db.Teachers.Include(x => x.Disciplines).SingleOrDefault(user => user.Id == guid);
			if (teacher is null)
				return BadRequest();
			Discipline? discipline = db.Disciplines.SingleOrDefault(discipline => discipline.Id == id);
			if (discipline is null)
				return BadRequest();
			teacher.Disciplines.Add(discipline);
			db.SaveChanges();
			return Ok();
		}
		[HttpDelete("{guid:guid}/[action]/{id:int}")]
		public ActionResult DeleteDiscipline(Guid guid, int id)
		{
			Teacher? teacher = db.Teachers.Include(x => x.Disciplines).SingleOrDefault(user => user.Id == guid);
			if (teacher is null)
				return BadRequest();
			Discipline? discipline = db.Disciplines.SingleOrDefault(discipline => discipline.Id == id);
			if (discipline is null)
				return BadRequest();
			if (!teacher.Disciplines.Contains(discipline))
				return BadRequest();
			teacher.Disciplines.Remove(discipline);
			db.SaveChanges();
			return Ok();
		}
	}
}
