using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioShared.Models;
using PortfolioShared.ViewModels.Request;
using PortfolioShared.ViewModels.Response;
using System.ComponentModel.DataAnnotations;

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
		public ActionResult<ResponseTeacher> GetInfo(Guid guid)
		{
			Teacher? teacher = db.Teachers.SingleOrDefault(user => user.Id == guid);
			if (teacher is null)
				return BadRequest();
			return Ok(new ResponseTeacher(teacher.Id, teacher.Email, teacher.FirstName, teacher.MiddleName, teacher.LastName, teacher.DateBirthday, teacher.Post, teacher.AcademicDegree, teacher.AcademicTitle));
		}
        [HttpPut("{guid:guid}/[action]")]
        public ActionResult<ResponseTeacher> AddInfo(Guid guid, [Required][FromBody] RequestTeacher requestTeacher)
        {
            Teacher? teacher = db.Teachers.SingleOrDefault(user => user.Id == guid);
            if (teacher is null)
                return BadRequest();
			teacher.Email = requestTeacher.Email;
			teacher.FirstName = requestTeacher.FirstName;
			teacher.MiddleName = requestTeacher.MiddleName;
			teacher.LastName = requestTeacher.LastName;
			teacher.DateBirthday = requestTeacher.DateBirthday;
			teacher.Post = requestTeacher.Post;
			teacher.AcademicDegree = requestTeacher.AcademicDegree;
			teacher.AcademicTitle = requestTeacher.AcademicTitle;
			db.SaveChanges();
            return Ok(new ResponseTeacher(teacher.Id, teacher.Email, teacher.FirstName, teacher.MiddleName, teacher.LastName, teacher.DateBirthday, teacher.Post, teacher.AcademicDegree, teacher.AcademicTitle));
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
