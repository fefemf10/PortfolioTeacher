using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioShared.Models;
using PortfolioShared.ViewModels.Response;

namespace PortfolioServer.Controllers.TeacherControllers
{
	public partial class TeacherController
	{
		[HttpGet("{guid:guid}/[action]")]
		public ActionResult<ResponseDiscipline[]> GetDiscipline(Guid guid)
		{
			Teacher? teacher = db.Teachers.Include(x => x.Disciplines).SingleOrDefault(user => user.Id == guid);
			if (teacher is null)
				return BadRequest();
			return Ok(Array.ConvertAll(teacher.Disciplines.ToArray(), discipline => new ResponseDiscipline(discipline.Id, discipline.Name)));
		}
		[HttpGet("{guid:guid}/[action]/{disciplineId:guid}")]
		public ActionResult<ResponseDiscipline> GetDiscipline(Guid guid, Guid disciplineId)
		{
			Teacher? teacher = db.Teachers.AsNoTracking().Include(x => x.Disciplines).SingleOrDefault(user => user.Id == guid);
			if (teacher is null)
				return BadRequest();
			Discipline? discipline = teacher.Disciplines.SingleOrDefault(discipline => discipline.Id == disciplineId);
			if (discipline is null)
				return BadRequest();
			return Ok(new ResponseDiscipline(discipline.Id, discipline.Name));
		}
		[HttpPost("{guid:guid}/[action]/{disciplineId:guid}")]
		public ActionResult AddDiscipline(Guid guid, Guid disciplineId)
		{
			Teacher? teacher = db.Teachers.Include(x => x.Disciplines).SingleOrDefault(user => user.Id == guid);
			if (teacher is null)
				return BadRequest();
			Discipline? discipline = db.Disciplines.SingleOrDefault(discipline => discipline.Id == disciplineId);
			if (discipline is null)
				return BadRequest();
			teacher.Disciplines.Add(discipline);
			db.SaveChanges();
			return Ok();
		}
		[HttpDelete("{guid:guid}/[action]/{disciplineId:guid}")]
		public ActionResult DeleteDiscipline(Guid guid, Guid disciplineId)
		{
			Teacher? teacher = db.Teachers.Include(x => x.Disciplines).SingleOrDefault(user => user.Id == guid);
			if (teacher is null)
				return BadRequest();
			Discipline? discipline = db.Disciplines.SingleOrDefault(discipline => discipline.Id == disciplineId);
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
