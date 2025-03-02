using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Portfolio.Domain.Services;

namespace Portfolio.API.Controllers.TeacherControllers
{
    [Authorize]
    [Route("api/Teacher/{id:guid}/[controller]")]
    [ApiController]
    public class DepartmentController(ITeacherDepartmentService tds) : ControllerBase
    {
        [HttpPut("[action]/{departmentId:guid}")]
        public async Task<ActionResult> Update(Guid id, Guid departmentId)
        {
            await tds.Update(id, departmentId);
            return Ok();
        }
    }
}
