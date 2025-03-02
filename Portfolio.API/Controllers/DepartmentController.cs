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
			return Ok(mapper.Map<IEnumerable<ResponseDepartment>>(await departmentService.GetAll()));
		}
        [HttpGet("{id:guid}/[action]")]
        public async Task<ActionResult<IEnumerable<Guid>>> GetTeachers(Guid id)
        {
            return Ok(await departmentService.GetTeachers(id));
        }
        [HttpGet("{id:guid}")]
		public async Task<ActionResult<ResponseDepartment>> GetById(Guid id)
		{
			return Ok(mapper.Map<ResponseDepartment>(await departmentService.GetById(id)));
		}
		[HttpPost("[action]")]
		public async Task<ActionResult<Guid>> Add(RequestAddDepartment requestDepartment)
		{
			return Ok(await departmentService.Add(mapper.Map<Department>(requestDepartment)));
		}
		[HttpPut("[action]")]
		public async Task<ActionResult> UpdateAsync(RequestUpdateDepartment requestDepartment)
		{
			await departmentService.Update(mapper.Map<Department>(requestDepartment));
			return Ok();
		}
		[HttpDelete("[action]/{id:guid}")]
		public async Task<ActionResult> DeleteById(Guid id)
		{
			await departmentService.DeleteById(id);
			return Ok();
		}
	}
}
