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
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class TeacherController(IMapper mapper, ITeacherService teacherService) : ControllerBase
	{
        [HttpGet("{id:guid}")]
		public async Task<ActionResult<ResponseTeacher>> GetInfo(Guid id)
		{
            Teacher? teacher = await teacherService.GetByIdWithDependencies(id) ?? throw new NotFoundByIdException();
            return mapper.Map<ResponseTeacher>(teacher);
		}
		[HttpPut]
		public async Task<ActionResult> AddInfo([Required][FromBody] RequestTeacher requestTeacher)
		{
            await teacherService.AddInfo(mapper.Map<Teacher>(requestTeacher));
            return Ok();
		}
		[HttpPost]
		public async Task<ActionResult<Guid>> AddTeacher([Required][FromBody] RequestAddTeacher requestAddTeacher)
		{
            return Ok(await teacherService.Add(mapper.Map<Teacher>(requestAddTeacher)));
		}
	}
}
