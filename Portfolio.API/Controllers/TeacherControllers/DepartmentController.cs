using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Portfolio.Domain.Services;

namespace Portfolio.API.Controllers.TeacherControllers
{
    [Authorize]
    [Route("api/Teacher/{id:guid}/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ITeacherDepartmentService tds;
        public DepartmentController(IMapper mapper, ITeacherDepartmentService tds)
        {
            this.mapper = mapper;
            this.tds = tds;
        }
        [HttpPut("[action]/{departmentId:guid}")]
        public async Task<ActionResult> Update(Guid id, Guid departmentId)
        {
            await tds.Update(id, departmentId);
            return Ok();
        }
    }
}
