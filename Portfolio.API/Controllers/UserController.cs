using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.ViewModels.Response;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;

namespace Portfolio.API.Cotrollers
{
	[AllowAnonymous]
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IMapper mapper;
		private readonly IUserService userService;
		public UserController(IMapper mapper, IUserService userService)
		{
			this.mapper = mapper;
			this.userService = userService;
		}
		[HttpGet("{id:guid}")]
		public async Task<ActionResult<ResponseUser>> GetInfo(Guid id)
		{
			User user = await userService.GetById(id);
			return Ok(mapper.Map<ResponseUser>(user));
		}
	}
}
