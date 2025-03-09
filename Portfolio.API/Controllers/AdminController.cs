using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.ViewModels.Request;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController(IMapper mapper, IAdminService adminService) : ControllerBase
    {
        [HttpPost("test-users")]
        public async Task<ActionResult> AddTestUsers([Required][FromBody] List<RequestAddTeacher> requestAddTeachers)
        {
            await adminService.AddTestUsers(mapper.Map<List<Teacher>>(requestAddTeachers));
            return Ok();
        }
    }
}
