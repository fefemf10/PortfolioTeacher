using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
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
        public async Task<ActionResult<IEnumerable<ResponseTeacher>>> GetTeacher()
        {
			List<ResponseTeacher> responseTeachers = [];
			foreach(var faculty in db.Faculties.Include(x => x.Departments))
			{
				foreach(var department in faculty.Departments)
                {
                    responseTeachers.AddRange(department.Teachers.Select(x => new ResponseTeacher(x.Id, x.Email, x.FirstName, x.MiddleName, x.LastName, x.DateBirthday, x.Post, x.AcademicDegree, x.AcademicTitle, new RequestFaculty(x.Faculty.Id, x.Faculty.Name), (x.Department is not null) ? new RequestDepartment(x.Department.Id, x.Department.Name) : null, (uint)x.Publications.Count)));
                }
            }
            return Ok(responseTeachers);
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
