using Microsoft.AspNetCore.Mvc;
using Portfolio.Domain.Models;
using Portfolio.Application.ViewModels.Request;
using Portfolio.Application.ViewModels.Response;
using AutoMapper;
using Portfolio.Domain.Services;
using Microsoft.AspNetCore.Authorization;

namespace Portfolio.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FacultyController(IMapper mapper, IFacultyService facultyService) : ControllerBase
	{
        [HttpGet]
		public async Task<ActionResult<IEnumerable<ResponseFaculty>>> GetAll()
		{
			return Ok(mapper.Map<IEnumerable<ResponseFaculty>>(await facultyService.GetAll()));
		}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ResponseDepartment>> GetById(Guid id)
        {
            return Ok(mapper.Map<ResponseFaculty>(await facultyService.GetById(id)));
        }
        [HttpGet("{id:guid}/teachers/ids")]
        public async Task<ActionResult<IEnumerable<Guid>>> GetTeachersIds(Guid id)
        {
            return Ok(await facultyService.GetTeachersIds(id));
        }
        [HttpGet("{id:guid}/teachers")]
        public async Task<ActionResult<IEnumerable<ResponseTeacher>>> GetTeachers(Guid id)
        {
            return Ok(mapper.Map<IEnumerable<ResponseTeacher>>(await facultyService.GetTeachers(id)));
        }
        [AllowAnonymous]
        [HttpGet("departments")]
        public async Task<ActionResult<IEnumerable<ResponseFacultyDepartments>>> GetAllWithDepartments()
        {
            return Ok(mapper.Map<IEnumerable<ResponseFacultyDepartments>>(await facultyService.GetAllWithDepartments()));
        }
        [HttpGet("{id:guid}/departments")]
        public async Task<ActionResult<ResponseDepartment>> GetByIdWithDepartments(Guid id)
        {
            return Ok(mapper.Map<ResponseFacultyDepartments>(await facultyService.GetByIdWithDepartments(id)));
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Add(RequestAddDepartment requestDepartment)
        {
            return Ok(await facultyService.Add(mapper.Map<Faculty>(requestDepartment)));
        }
        [HttpPut]
        public async Task<ActionResult> UpdateAsync(RequestUpdateDepartment requestDepartment)
        {
            await facultyService.Update(mapper.Map<Faculty>(requestDepartment));
            return Ok();
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteById(Guid id)
        {
            await facultyService.DeleteById(id);
            return Ok();
        }
    }
}
