using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using PortfolioShared.Models;
using PortfolioShared.ViewModels.Request;
using PortfolioShared.ViewModels.Response;

namespace PortfolioServer.Controllers.DepartmentControllers
{
    public partial class DepartmentController
    {
        [HttpGet("{departmentId:guid}/[action]")]
        public async Task<ActionResult<IEnumerable<ResponseTeacher>>> GetTeacher(Guid departmentId)
        {
            Department? department = await db.Departments.Include(x => x.Teachers).SingleOrDefaultAsync(x => x.Id == departmentId);
            if (department is null)
                return NotFound();

            return Ok(department.Teachers.Select(x => new ResponseTeacher(x.Id, x.Email, x.FirstName, x.MiddleName, x.LastName, x.DateBirthday, x.Post, x.AcademicDegree, x.AcademicTitle, new RequestFaculty(x.Department.Faculty.Id, x.Department.Faculty.Name), new RequestDepartment(x.Department.Id, x.Department.Name), (uint)x.Publications.Count())));
        }
        [HttpGet("{departmentId:guid}/[action]/{TeacherId:guid}")]
        public async Task<ActionResult<ResponseTeacher>> GetTeacherById(Guid departmentId, Guid teacherId)
        {
            Department? department = await db.Departments.Include(x => x.Teachers).SingleOrDefaultAsync(x => x.Id == departmentId);
            if (department is null)
                return NotFound();
            Teacher? teacher = department.Teachers.Find(x => x.Id == teacherId);
            if (teacher is null)
                return NotFound();

            return Ok(new ResponseTeacher(teacher.Id, teacher.Email, teacher.FirstName, teacher.MiddleName, teacher.LastName, teacher.DateBirthday, teacher.Post, teacher.AcademicDegree, teacher.AcademicTitle, new RequestFaculty(teacher.Department.Faculty.Id, teacher.Department.Faculty.Name), new RequestDepartment(teacher.Department.Id, teacher.Department.Name), (uint)teacher.Publications.Count()));
        }
    }
}
