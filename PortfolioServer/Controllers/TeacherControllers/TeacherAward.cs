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
		public ActionResult<RequestAward[]> GetAward(Guid guid)
		{
			Teacher? teacher = db.Teachers.Include(x => x.Awards).SingleOrDefault(user => user.Id == guid);
			if (teacher is null)
				return BadRequest();
			RequestAward[] responseAwards = Array.ConvertAll(teacher.Awards.ToArray(),
				award => new RequestAward { Id = award.Id, Name = award.Name, NameOrganization = award.NameOrganization, DateAward = award.DateAward });
			return Ok(responseAwards);
		}
		[HttpGet("{guid:guid}/[action]/{awardId:guid}")]
		public ActionResult<RequestAward[]> GetAward(Guid guid, Guid awardId)
		{
			Teacher? teacher = db.Teachers.Include(x => x.Awards).SingleOrDefault(user => user.Id == guid);
			if (teacher is null)
				return BadRequest();
			Award? award = teacher.Awards.SingleOrDefault(award => award.Id == awardId);
			if (award is null)
				return BadRequest();
			return Ok(new RequestAward { Id = award.Id, Name = award.Name, NameOrganization = award.NameOrganization, DateAward = award.DateAward });
		}
		[HttpPost("{guid:guid}/[action]")]
		public ActionResult AddAward(Guid guid, [Required][FromBody] RequestAward requestAward)
		{
			Teacher? teacher = db.Teachers.Include(x => x.Awards).SingleOrDefault(user => user.Id == guid);
			if (teacher is null)
				return BadRequest();
			teacher.Awards.Add(new Award { Id = requestAward.Id, Name = requestAward.Name, NameOrganization = requestAward.NameOrganization, DateAward = requestAward.DateAward });
			db.SaveChanges();
			return Ok();
		}
		[HttpPut("{guid:guid}/[action]")]
		public ActionResult UpdateAward(Guid guid, [Required][FromBody] RequestAward requestAward)
		{
			Teacher? teacher = db.Teachers.Include(x => x.Awards).SingleOrDefault(user => user.Id == guid);
			if (teacher is null)
				return BadRequest();
			Award? award = teacher.Awards.SingleOrDefault(award => award.Id == requestAward.Id);
			if (award is null)
				return BadRequest();
			award.Name = requestAward.Name;
			award.NameOrganization = requestAward.NameOrganization;
			award.DateAward = requestAward.DateAward;
			db.SaveChanges();
			return Ok();
		}
		[HttpDelete("{guid:guid}/[action]/{awardId:guid}")]
		public ActionResult DeleteAward(Guid guid, Guid awardId)
		{
			Teacher? teacher = db.Teachers.Include(x => x.Awards).SingleOrDefault(user => user.Id == guid);
			if (teacher is null)
				return BadRequest();
			Award? award = teacher.Awards.SingleOrDefault(award => award.Id == awardId);
			if (award is null)
				return BadRequest();
			teacher.Awards.Remove(award);
			db.SaveChanges();
			return Ok();
		}
	}
}
