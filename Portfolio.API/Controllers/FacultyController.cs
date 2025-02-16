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
	public class FacultyController : ControllerBase
	{
        private readonly IMapper mapper;
        private readonly IFacultyService facultyService;
		public FacultyController(IMapper mapper, IFacultyService facultyService)
		{
			this.mapper = mapper;
			this.facultyService = facultyService;
		}
		[HttpGet("[action]")]
		public async Task<ActionResult<IEnumerable<ResponseFaculty>>> GetAll()
		{
			return Ok(mapper.Map<ResponseFaculty>(await facultyService.GetAll()));
		}
        [HttpGet("{id:guid}/[action]")]
        public async Task<ActionResult<IEnumerable<Guid>>> GetTeachers(Guid id)
        {
            return Ok(await facultyService.GetTeachers(id));
        }
		[HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<ResponseFacultyDepartments>>> GetAllWithDepartments()
        {
            return Ok(mapper.Map<IEnumerable<ResponseFacultyDepartments>>(await facultyService.GetAllWithDepartments()));
        }
        [HttpGet("[action]/{id:guid}")]
        public async Task<ActionResult<ResponseDepartment>> GetById(Guid id)
        {
            return Ok(mapper.Map<ResponseFaculty>(await facultyService.GetById(id)));
        }
        [HttpGet("[action]/{id:guid}")]
        public async Task<ActionResult<ResponseDepartment>> GetByIdWithDepartments(Guid id)
        {
            return Ok(mapper.Map<ResponseFacultyDepartments>(await facultyService.GetByIdWithDepartments(id)));
        }
        [HttpPost("[action]")]
        public async Task<ActionResult<Guid>> Add(RequestAddDepartment requestDepartment)
        {
            return Ok(await facultyService.Add(mapper.Map<Faculty>(requestDepartment)));
        }
        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateAsync(RequestUpdateDepartment requestDepartment)
        {
            await facultyService.Update(mapper.Map<Faculty>(requestDepartment));
            return Ok();
        }
        [HttpDelete("[action]/{id:guid}")]
        public async Task<ActionResult> DeleteById(Guid id)
        {
            await facultyService.DeleteById(id);
            return Ok();
        }
    }
}
