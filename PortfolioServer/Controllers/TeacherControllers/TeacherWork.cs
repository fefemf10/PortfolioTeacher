using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioShared.Models;
using PortfolioShared.ViewModels.Request.Work;
using System.ComponentModel.DataAnnotations;

namespace PortfolioServer.Controllers.TeacherControllers
{
	public partial class TeacherController
	{
		[HttpGet("{guid:guid}/[action]")]
		public ActionResult<RequestWork[]> GetWork(Guid guid)
		{
			Teacher? teacher = db.Teachers.Include(x => x.Works).SingleOrDefault(user => user.Id == guid);
			if (teacher is null)
				return BadRequest();
			RequestWork[] responseWorks = Array.ConvertAll(teacher.Works.ToArray(),
				work => new RequestWork { Id = work.Id, Name = work.Name, Post = work.Post, BeginTimeWork = work.BeginTimeWork, EndTimeWork = work.EndTimeWork });
			return Ok(responseWorks);
		}
		[HttpGet("{guid:guid}/[action]/{workId:guid}")]
		public ActionResult<RequestWork[]> GetWork(Guid guid, Guid workId)
		{
			Teacher? teacher = db.Teachers.Include(x => x.Works).SingleOrDefault(user => user.Id == guid);
			if (teacher is null)
				return BadRequest();
			Work? work = teacher.Works.SingleOrDefault(work => work.Id == workId);
			if (work is null)
				return BadRequest();
			return Ok(new RequestWork { Id = work.Id, Name = work.Name, Post = work.Post, BeginTimeWork = work.BeginTimeWork, EndTimeWork = work.EndTimeWork });
		}
		[HttpPost("{guid:guid}/[action]")]
		public ActionResult AddWork(Guid guid, [Required][FromBody] RequestWork requestWork)
		{
			Teacher? teacher = db.Teachers.Include(x => x.Works).SingleOrDefault(user => user.Id == guid);
			if (teacher is null)
				return BadRequest();
			teacher.Works.Add(new Work { Id = requestWork.Id, Name = requestWork.Name, Post = requestWork.Post, BeginTimeWork = requestWork.BeginTimeWork, EndTimeWork = requestWork.EndTimeWork });
			db.SaveChanges();
			return Ok();
		}
		[HttpPut("{guid:guid}/[action]")]
		public ActionResult UpdateWork(Guid guid, [Required][FromBody] RequestWork requestWork)
		{
			Teacher? teacher = db.Teachers.Include(x => x.Works).SingleOrDefault(user => user.Id == guid);
			if (teacher is null)
				return BadRequest();
			Work? work = teacher.Works.SingleOrDefault(work => work.Id == requestWork.Id);
			if (work is null)
				return BadRequest();
			work.Name = requestWork.Name;
			work.Post = requestWork.Post;
			work.BeginTimeWork = requestWork.BeginTimeWork;
			work.EndTimeWork = requestWork.EndTimeWork;
			db.SaveChanges();
			return Ok();
		}
		[HttpDelete("{guid:guid}/[action]/{workId:guid}")]
		public ActionResult DeleteWork(Guid guid, Guid workId)
		{
			Teacher? teacher = db.Teachers.Include(x => x.Works).SingleOrDefault(user => user.Id == guid);
			if (teacher is null)
				return BadRequest();
			Work? work = teacher.Works.SingleOrDefault(work => work.Id == workId);
			if (work is null)
				return BadRequest();
			teacher.Works.Remove(work);
			db.SaveChanges();
			return Ok();
		}
	}
}
