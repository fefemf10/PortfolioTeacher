using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioShared.Models;
using PortfolioShared.ViewModels.Request;
using PortfolioShared.ViewModels.Response;

namespace PortfolioServer.Controllers.FacultyControllers
{
	[Route("[controller]/[action]")]
	[ApiController]
	public class FacultyController : ControllerBase
	{
		private readonly ApplicationContext db;
		public FacultyController(ApplicationContext db)
		{
			this.db = db;
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<RequestFaculty>>> Get()
		{
			return Ok(await db.Faculties.Select(x => new RequestFaculty(x.Id, x.Name)).ToArrayAsync());
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<RequestFacultyDepartment>>> GetWithDepartment()
		{
			return Ok(await db.Faculties.Select(x => new RequestFacultyDepartment{ Id = x.Id, Name = x.Name, FullName = x.FullName, Departments = x.Departments.Select(y => new RequestDepartment(y.Id, y.Name)).ToList()}).ToArrayAsync());
		}
		[HttpGet("{id:guid}")]
		public async Task<ActionResult<RequestFaculty>> GetById(Guid id)
		{
			Faculty? faculty = await db.Faculties.FindAsync(id);
			if (faculty is null)
				return NotFound();
			return Ok(new RequestFaculty(faculty.Id, faculty.Name));
		}
		[HttpPost]
		public async Task<ActionResult> Add(RequestFaculty requestFaculty)
		{
			db.Faculties.Add(new Faculty() { Id = requestFaculty.Id, Name = requestFaculty.Name });
			await db.SaveChangesAsync();
			return Ok();
		}
		[HttpPut]
		public async Task<IActionResult> UpdateById(RequestFaculty requestFaculty)
		{
			Faculty? faculty = await db.Faculties.FindAsync(requestFaculty.Id);
			if (faculty is null)
				return NotFound();

			faculty.Name = requestFaculty.Name;
			await db.SaveChangesAsync();
			return Ok();
		}
		[HttpDelete("{id:guid}")]
		public async Task<ActionResult> DeleteById(Guid id)
		{
			Faculty? faculty = await db.Faculties.FindAsync(id);
			if (faculty is null)
				return NotFound();

			db.Faculties.Remove(faculty);
			await db.SaveChangesAsync();
			return Ok();
		}
	}
}
