using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.ViewModels.Request;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;

namespace Portfolio.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IAdminService adminService;
        public AdminController(IMapper mapper, IAdminService adminService)
        {
            this.mapper = mapper;
            this.adminService = adminService;
        }
        [HttpPost("test-users")]
        public async Task<ActionResult> AddTestUsers(List<RequestAddTeacher> requestAddTeachers)
        {
            await adminService.AddTestUsers(mapper.Map<List<Teacher>>(requestAddTeachers));
            return Ok();
        }
    }
}
