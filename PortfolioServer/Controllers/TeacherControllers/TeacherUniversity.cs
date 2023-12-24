using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioShared.Models;
using PortfolioShared.ViewModels.Request;
using System.ComponentModel.DataAnnotations;

namespace PortfolioServer.Controllers.TeacherControllers
{
	public partial class TeacherController
	{
		[HttpGet("{guid:guid}/[action]")]
		public ActionResult<RequestUniversity[]> GetUniversity(Guid guid)
		{
			Teacher? teacher = db.Teachers.Include(x => x.Universities).SingleOrDefault(user => user.Id == guid);
			if (teacher is null)
				return BadRequest();
			RequestUniversity[] responseuniversities = Array.ConvertAll(teacher.Universities.ToArray(),
				university => new RequestUniversity { Id = university.Id, Name = university.Name, Specialization = university.Specialization, Qualification = university.Qualification, YearGraduation = university.YearGraduation });
			return Ok(responseuniversities);
		}
		[HttpGet("{guid:guid}/[action]/{universityId:guid}")]
		public ActionResult<RequestUniversity[]> GetUniversity(Guid guid, Guid universityId)
		{
			Teacher? teacher = db.Teachers.Include(x => x.Universities).SingleOrDefault(user => user.Id == guid);
			if (teacher is null)
				return BadRequest();
			University? university = teacher.Universities.SingleOrDefault(university => university.Id == universityId);
			if (university is null)
				return BadRequest();
			return Ok(new RequestUniversity { Id = university.Id, Name = university.Name, Specialization = university.Specialization, Qualification = university.Qualification, YearGraduation = university.YearGraduation });
		}
		[HttpPost("{guid:guid}/[action]")]
		public ActionResult AddUniversity(Guid guid, [Required][FromBody] RequestUniversity requestUniversity)
		{
			Teacher? teacher = db.Teachers.Include(x => x.Universities).SingleOrDefault(user => user.Id == guid);
			if (teacher is null)
				return BadRequest();
			teacher.Universities.Add(new University { Id = requestUniversity.Id, Name = requestUniversity.Name, Specialization = requestUniversity.Specialization, Qualification = requestUniversity.Qualification, YearGraduation = requestUniversity.YearGraduation });
			db.SaveChanges();
			return Ok();
		}
		[HttpPut("{guid:guid}/[action]")]
		public ActionResult UpdateUniversity(Guid guid, [Required][FromBody] RequestUniversity requestUniversity)
		{
			Teacher? teacher = db.Teachers.Include(x => x.Universities).SingleOrDefault(user => user.Id == guid);
			if (teacher is null)
				return BadRequest();
			University? university = teacher.Universities.SingleOrDefault(university => university.Id == requestUniversity.Id);
			if (university is null)
				return BadRequest();
			university.Name = requestUniversity.Name;
			university.Specialization = requestUniversity.Specialization;
			university.Qualification = requestUniversity.Qualification;
			university.YearGraduation = requestUniversity.YearGraduation;
			db.SaveChanges();
			return Ok();
		}
		[HttpDelete("{guid:guid}/[action]/{universityId:guid}")]
		public ActionResult DeleteUniversity(Guid guid, Guid universityId)
		{
			Teacher? teacher = db.Teachers.Include(x => x.Universities).SingleOrDefault(user => user.Id == guid);
			if (teacher is null)
				return BadRequest();
			University? university = teacher.Universities.SingleOrDefault(university => university.Id == universityId);
			if (university is null)
				return BadRequest();
			teacher.Universities.Remove(university);
			db.SaveChanges();
			return Ok();
		}
	}
}
