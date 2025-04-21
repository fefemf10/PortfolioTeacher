using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Models;
using Portfolio.Application.ViewModels.Request;
using Portfolio.Application.ViewModels.Response;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Portfolio.Application.Exceptions;
using Portfolio.Domain.Services;

namespace Portfolio.API.Controllers.TeacherControllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TeacherController(IMapper mapper, ITeacherService teacherService) : ControllerBase
	{
        [HttpGet("{id:guid}/short")]
        public async Task<ActionResult<TeacherShortInfo>> GetByIdShortInfo(Guid id)
        {
            return Ok(await teacherService.GetByIdShortInfo(id));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseTeacher>>> GetInfoAll()
        {
            return Ok(mapper.Map<IEnumerable<ResponseTeacher>>(await teacherService.GetAllFromCache()));
        }
        [HttpGet("{id:guid}")]
		public async Task<ActionResult<ResponseTeacher>> GetInfo(Guid id)
		{
            Teacher? teacher = await teacherService.GetByIdFromCache(id) ?? throw new NotFoundByIdException();
            return Ok(mapper.Map<ResponseTeacher>(teacher));
		}
        [Authorize]
        [HttpPut]
		public async Task<ActionResult> AddInfo([Required][FromBody] RequestTeacher requestTeacher)
		{
            await teacherService.AddInfo(mapper.Map<Teacher>(requestTeacher));
            return Ok();
		}
        [Authorize]
        [HttpPost]
		public async Task<ActionResult<Guid>> AddTeacher([Required][FromBody] RequestAddTeacher requestAddTeacher)
		{
            return Ok(await teacherService.Add(mapper.Map<Teacher>(requestAddTeacher)));
		}
	}
}
