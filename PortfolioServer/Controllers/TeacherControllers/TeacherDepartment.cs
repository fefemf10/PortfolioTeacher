using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioShared.Models;
using PortfolioShared.ViewModels.Request;

namespace PortfolioServer.Controllers.TeacherControllers
{
    public partial class TeacherController
    {
        [HttpPost("{teacherId:guid}/[action]/{departmentId:guid}")]
        public async Task<ActionResult> UpdateDepartmentAsync(Guid teacherId, Guid departmentId)
        {
            Teacher? teacher = await db.Teachers.FindAsync(teacherId);
            if (teacher is null)
                return NotFound();
            Department? department = await db.Departments.FindAsync(departmentId);
            if (department is null)
                return NotFound();
            teacher.Department = department;
            return Ok();
        }
    }
}
