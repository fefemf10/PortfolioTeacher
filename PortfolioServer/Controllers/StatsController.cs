using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioShared.Models;
using PortfolioShared.ViewModels.Request;
using PortfolioShared.ViewModels.Response;

namespace PortfolioServer.Controllers
{
	[Authorize]
	[Route("[controller]")]
	[ApiController]
	public class StatsController : ControllerBase
	{
		private readonly ApplicationContext db;
		public StatsController(ApplicationContext db)
		{
			this.db = db;
		}

		[HttpGet("[action]/{departmentId:guid}")]
		public async Task<ActionResult<uint>> GetCountTeacherInDepartment(Guid departmentId)
		{
			Department? department = await db.Departments.AsNoTracking().Include(x => x.Teachers).SingleAsync(x => x.Id == departmentId);
			if (department is null)
				return BadRequest();
			return Ok((uint)department.Teachers.Count);
		}
        [HttpGet("[action]/{facultyId:guid}")]
        public async Task<ActionResult<uint>> GetCountTeacherInFaculty(Guid facultyId)
        {
            Faculty? faculty = await db.Faculties.AsNoTracking().Include(x => x.Departments).ThenInclude(y => y.Teachers).SingleAsync(x => x.Id == facultyId);
            if (faculty is null)
                return BadRequest();
            return Ok((uint)faculty.Departments.Sum(x => x.Teachers.Count));
        }
        [HttpGet("[action]/{departmentId:guid}")]
        public async Task<ActionResult<List<ResponseTeacher>>> GetTopTeacherDisciplinesInDepartment(Guid departmentId)
        {
			List<Teacher> teachers = await db.Teachers.AsNoTracking().Include(x => x.Publications).Include(x => x.Disciplines).Include(x => x.Department).Include(x => x.Faculty).OrderByDescending(x => x.Disciplines.Count).Take(5).ToListAsync();
			List<ResponseTeacher> responseTeachers = teachers.Where(x => x.DepartmentId == departmentId).Select(x => new ResponseTeacher(x.Id, x.Email, x.FirstName, x.MiddleName, x.LastName, x.DateBirthday, x.Post, x.AcademicDegree, x.AcademicTitle, new RequestFaculty(x.Faculty.Id, x.Faculty.Name), (x.Department is not null) ? new RequestDepartment(x.Department.Id, x.Department.Name) : null, (uint)x.Publications.Count)).ToList();
            return Ok(responseTeachers);
        }
        [HttpGet("[action]/{facultyId:guid}")]
        public async Task<ActionResult<List<ResponseTeacher>>> GetTopTeacherDisciplinesInFaculty(Guid facultyId)
        {
            List<Teacher> teachers = await db.Teachers.AsNoTracking().Include(x => x.Publications).Include(x => x.Disciplines).Include(x => x.Department).Include(x => x.Faculty).Where(x => x.FacultyId == facultyId).OrderByDescending(x => x.Disciplines.Count).Take(5).ToListAsync();
            List<ResponseTeacher> responseTeachers = teachers.Select(x => new ResponseTeacher(x.Id, x.Email, x.FirstName, x.MiddleName, x.LastName, x.DateBirthday, x.Post, x.AcademicDegree, x.AcademicTitle, new RequestFaculty(x.Faculty.Id, x.Faculty.Name), (x.Department is not null) ? new RequestDepartment(x.Department.Id, x.Department.Name) : null, (uint)x.Publications.Count)).ToList();
            return Ok(responseTeachers);
        }
        [HttpGet("[action]/{departmentId:guid}")]
        public async Task<ActionResult<List<ResponseTeacher>>> GetTopTeacherPublicationsInDepartment(Guid departmentId)
        {
            List<Teacher> teachers = await db.Teachers.AsNoTracking().Include(x => x.Publications).Include(x => x.Department).Include(x => x.Faculty).OrderByDescending(x => x.Publications.Count).Take(5).ToListAsync();
            List<ResponseTeacher> responseTeachers = teachers.Where(x => x.DepartmentId == departmentId).Select(x => new ResponseTeacher(x.Id, x.Email, x.FirstName, x.MiddleName, x.LastName, x.DateBirthday, x.Post, x.AcademicDegree, x.AcademicTitle, new RequestFaculty(x.Faculty.Id, x.Faculty.Name), (x.Department is not null) ? new RequestDepartment(x.Department.Id, x.Department.Name) : null, (uint)x.Publications.Count)).ToList();
            return Ok(responseTeachers);
        }
        [HttpGet("[action]/{facultyId:guid}")]
        public async Task<ActionResult<List<ResponseTeacher>>> GetTopTeacherPublicationsInFaculty(Guid facultyId)
        {
            List<Teacher> teachers = await db.Teachers.AsNoTracking().Include(x => x.Publications).Include(x => x.Department).Include(x => x.Faculty).Where(x => x.FacultyId == facultyId).OrderByDescending(x => x.Publications.Count).Take(5).ToListAsync();
            List<ResponseTeacher> responseTeachers = teachers.Select(x => new ResponseTeacher(x.Id, x.Email, x.FirstName, x.MiddleName, x.LastName, x.DateBirthday, x.Post, x.AcademicDegree, x.AcademicTitle, new RequestFaculty(x.Faculty.Id, x.Faculty.Name), (x.Department is not null) ? new RequestDepartment(x.Department.Id, x.Department.Name) : null, (uint)x.Publications.Count)).ToList();
            return Ok(responseTeachers);
        }
        [HttpGet("[action]/{departmentId:guid}")]
        public async Task<ActionResult<List<ResponseTeacher>>> GetAvarageAgeTeacherInDepartment(Guid departmentId)
        {
            DateOnly date = GetDate((long)db.Teachers.AsNoTracking().Where(x => x.DateBirthday.HasValue && x.DepartmentId == departmentId).Average(x => GetDifferent(x.DateBirthday.Value, DateOnly.FromDateTime(DateTime.UtcNow))));
            return Ok(date.Year);
        }
        [HttpGet("[action]/{facultyId:guid}")]
        public async Task<ActionResult<uint>> GetAvarageAgeTeacherInFaculty(Guid facultyId)
        {
            var teachers = db.Teachers.AsNoTracking().Where(x => x.DateBirthday.HasValue && x.FacultyId == facultyId).ToList();
            var ticks = teachers.Select(x => new DateTime(x.DateBirthday.Value, new TimeOnly()).Ticks).ToList();
            ticks.Sort();
            long tick = ticks[ticks.Count / 2];
            DateOnly date = GetDate(GetDifferent(tick));
            return Ok(date.Year);
        }
        private long GetDifferent(double ticks)
        {
            long minTicks = (long)ticks;
            var maxTicks = DateTime.UtcNow.Ticks;
            return maxTicks - minTicks;
            
        }
        private long GetDifferent(DateOnly date1, DateOnly date2)
        {
            var minTicks = date1.ToDateTime(new TimeOnly()).Ticks;
            var maxTicks = date2.ToDateTime(new TimeOnly()).Ticks;
            return maxTicks - minTicks;
            
        }
        private DateOnly GetDate(long ticks)
        {
            var newDate = new DateTime(ticks);
            return DateOnly.FromDateTime(newDate);
        }
    }
}
