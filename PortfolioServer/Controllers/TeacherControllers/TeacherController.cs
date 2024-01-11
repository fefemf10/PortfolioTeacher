using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioShared.Models;
using PortfolioShared.ViewModels.Request;
using PortfolioShared.ViewModels.Response;
using System.ComponentModel.DataAnnotations;

namespace PortfolioServer.Controllers.TeacherControllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public partial class TeacherController : ControllerBase
    {
        private readonly ApplicationContext db;
        public TeacherController(ApplicationContext db)
        {
            this.db = db;
        }
        [HttpGet("{guid:guid}/[action]")]
        public ActionResult<ResponseTeacher> GetInfo(Guid guid)
        {
            Teacher? teacher = db.Teachers.Include(x => x.Faculty).Include(x => x.Department).Single(x => x.Id == guid);
            if (teacher is null)
                return BadRequest();
            return Ok(new ResponseTeacher(teacher.Id, teacher.Email, teacher.FirstName, teacher.MiddleName, teacher.LastName, teacher.DateBirthday, teacher.Post, teacher.AcademicDegree, teacher.AcademicTitle, new RequestFaculty(teacher.Faculty.Id, teacher.Faculty.Name), (teacher.Department is not null) ? new RequestDepartment(teacher.Department.Id, teacher.Department.Name) : null, (uint)teacher.Publications.Count));
        }
        [HttpPut("{guid:guid}/[action]")]
        public ActionResult AddInfo(Guid guid, [Required][FromBody] RequestTeacher requestTeacher)
        {
            Teacher? teacher = db.Teachers.Find(guid);
            if (teacher is null)
                return BadRequest();
            Department? department;
            if (requestTeacher.DepartmentId is not null)
            {
                department = db.Departments.Find(requestTeacher.DepartmentId);
                if (department is null)
                    return BadRequest();
                else if (department is not null && department.FacultyId != requestTeacher.FacultyId)
                    return BadRequest();
            }
			teacher.Email = requestTeacher.Email;
            teacher.FirstName = requestTeacher.FirstName;
            teacher.MiddleName = requestTeacher.MiddleName;
            teacher.LastName = requestTeacher.LastName;
            teacher.DateBirthday = requestTeacher.DateBirthday;
            teacher.Post = requestTeacher.Post;
            teacher.AcademicDegree = requestTeacher.AcademicDegree;
            teacher.AcademicTitle = requestTeacher.AcademicTitle;
            teacher.FacultyId = requestTeacher.FacultyId;
            teacher.DepartmentId = requestTeacher.DepartmentId;
            db.SaveChanges();
            return Ok();
        }
        [HttpPost("[action]")]
        public ActionResult AddTeacher([Required][FromBody] RequestAddTeacher requestAddTeacher)
        {
			Faculty? faculty = db.Faculties.Find(requestAddTeacher.FacultyId);
			if (faculty is null)
				return BadRequest();
            Department? department = db.Departments.Find(requestAddTeacher.DepartmentId);
            if (department is not null)
                if (department.FacultyId != faculty.Id)
                    return BadRequest();
			Teacher teacher = new() { Id = requestAddTeacher.Id, Email = requestAddTeacher.Email, Faculty = faculty, Department = department };
			db.Teachers.Add(teacher);
            db.SaveChanges();
            return Ok();
        }
    }
}
