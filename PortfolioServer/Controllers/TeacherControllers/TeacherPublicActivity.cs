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
		public ActionResult<RequestPublicActivity[]> GetPublicActivity(Guid guid)
		{
			Teacher? teacher = db.Teachers.Include(x => x.PublicActivities).SingleOrDefault(user => user.Id == guid);
			if (teacher is null)
				return BadRequest();
			RequestPublicActivity[] responsePublicActivities = Array.ConvertAll(teacher.PublicActivities.ToArray(),
				publicActivity => new RequestPublicActivity { Id = publicActivity.Id, Name = publicActivity.Name });
			return Ok(responsePublicActivities);
		}
		[HttpGet("{guid:guid}/[action]/{publicActivityId:guid}")]
		public ActionResult<RequestPublicActivity[]> GetPublicActivity(Guid guid, Guid publicActivityId)
		{
			Teacher? teacher = db.Teachers.Include(x => x.PublicActivities).SingleOrDefault(user => user.Id == guid);
			if (teacher is null)
				return BadRequest();
			PublicActivity? publicActivity = teacher.PublicActivities.SingleOrDefault(publicActivity => publicActivity.Id == publicActivityId);
			if (publicActivity is null)
				return BadRequest();
			return Ok(new RequestPublicActivity { Id = publicActivity.Id, Name = publicActivity.Name });
		}
		[HttpPost("{guid:guid}/[action]")]
		public ActionResult AddPublicActivity(Guid guid, [Required][FromBody] RequestPublicActivity requestPublicActivity)
		{
			Teacher? teacher = db.Teachers.Include(x => x.PublicActivities).SingleOrDefault(user => user.Id == guid);
			if (teacher is null)
				return BadRequest();
			teacher.PublicActivities.Add(new PublicActivity { Id = requestPublicActivity.Id, Name = requestPublicActivity.Name });
			db.SaveChanges();
			return Ok();
		}
		[HttpPut("{guid:guid}/[action]")]
		public ActionResult UpdatePublicActivity(Guid guid, [Required][FromBody] RequestPublicActivity requestPublicActivity)
		{
			Teacher? teacher = db.Teachers.Include(x => x.PublicActivities).SingleOrDefault(user => user.Id == guid);
			if (teacher is null)
				return BadRequest();
			PublicActivity? publicActivity = teacher.PublicActivities.SingleOrDefault(publicActivity => publicActivity.Id == requestPublicActivity.Id);
			if (publicActivity is null)
				return BadRequest();
			publicActivity.Name = requestPublicActivity.Name;
			db.SaveChanges();
			return Ok();
		}
		[HttpDelete("{guid:guid}/[action]/{publicActivityId:guid}")]
		public ActionResult DeletePublicActivity(Guid guid, Guid publicActivityId)
		{
			Teacher? teacher = db.Teachers.Include(x => x.PublicActivities).SingleOrDefault(user => user.Id == guid);
			if (teacher is null)
				return BadRequest();
			PublicActivity? publicActivity = teacher.PublicActivities.SingleOrDefault(publicActivity => publicActivity.Id == publicActivityId);
			if (publicActivity is null)
				return BadRequest();
			teacher.PublicActivities.Remove(publicActivity);
			db.SaveChanges();
			return Ok();
		}
	}
}
