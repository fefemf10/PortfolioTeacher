using Microsoft.AspNetCore.Mvc;
using Portfolio.Domain.Models;
using Portfolio.Application.ViewModels.Request;
using Portfolio.Application.ViewModels.Response;
using AutoMapper;
using Portfolio.Domain.Services;

namespace Portfolio.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DepartmentController(IMapper mapper, IDepartmentService departmentService) : ControllerBase
	{
		[HttpGet]
		public async Task<ActionResult<IEnumerable<ResponseDepartment>>> GetAll()
		{
			return Ok(mapper.Map<IEnumerable<ResponseDepartment>>(await departmentService.GetAllRecursive()));
		}
        [HttpGet("{id:guid}/teachers/ids")]
        public async Task<ActionResult<IEnumerable<Guid>>> GetTeacherIds(Guid id)
        {
            return Ok(await departmentService.GetTeachersIds(id));
        }
        [HttpGet("{id:guid}/teachers")]
        public async Task<ActionResult<IEnumerable<ResponseTeacher>>> GetTeacher(Guid id)
        {
            return Ok(mapper.Map<IEnumerable<ResponseTeacher>>(await departmentService.GetTeachers(id)));
        }
        [HttpGet("{id:guid}")]
		public async Task<ActionResult<ResponseDepartment>> GetById(Guid id)
		{
			return Ok(mapper.Map<ResponseDepartment>(await departmentService.GetById(id)));
		}
		[HttpPost]
		public async Task<ActionResult<Guid>> Add(RequestAddDepartment requestDepartment)
		{
			return Ok(await departmentService.Add(mapper.Map<Department>(requestDepartment)));
		}
		[HttpPut]
		public async Task<ActionResult> UpdateAsync(RequestUpdateDepartment requestDepartment)
		{
			await departmentService.Update(mapper.Map<Department>(requestDepartment));
			return Ok();
		}
		[HttpDelete("{id:guid}")]
		public async Task<ActionResult> DeleteById(Guid id)
		{
			await departmentService.DeleteById(id);
			return Ok();
		}
	}
}
