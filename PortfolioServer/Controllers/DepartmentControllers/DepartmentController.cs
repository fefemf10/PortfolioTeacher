using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioShared.Models;
using PortfolioShared.ViewModels.Request;
using PortfolioShared.ViewModels.Response;

namespace PortfolioServer.Controllers.DepartmentControllers
{
	[Route("[controller]")]
	[ApiController]
	public partial class DepartmentController : ControllerBase
	{
		private readonly ApplicationContext db;
		public DepartmentController(ApplicationContext db)
		{
			this.db = db;
		}
		[HttpGet("[action]")]
		public async Task<ActionResult<IEnumerable<RequestDepartment>>> Get()
		{
			return Ok(await db.Departments.Select(x => new RequestDepartment(x.Id, x.Name)).ToArrayAsync());
		}
		[HttpGet("[action]/{id:guid}")]
		public async Task<ActionResult<RequestDepartment>> GetById(Guid id)
		{
			Department? department = await db.Departments.FindAsync(id);
			if (department is null)
				return NotFound();
			return Ok(new RequestDepartment(department.Id, department.Name));
		}
		[HttpPost("[action]")]
		public async Task<ActionResult> Add(RequestDepartment requestDepartment)
		{
			db.Departments.Add(new Department() { Id = requestDepartment.Id, Name = requestDepartment.Name });
			await db.SaveChangesAsync();
			return Ok();
		}
		[HttpPut("[action]")]
		public async Task<IActionResult> Update(RequestDepartment requestDepartment)
		{
			Department? department = await db.Departments.FindAsync(requestDepartment.Id);
			if (department is null)
				return NotFound();

			department.Name = requestDepartment.Name;
			await db.SaveChangesAsync();
			return Ok();
		}
		[HttpDelete("[action]/{id:guid}")]
		public async Task<ActionResult> DeleteById(Guid id)
		{
			Department? department = await db.Departments.FindAsync(id);
			if (department is null)
				return NotFound();

			db.Departments.Remove(department);
			await db.SaveChangesAsync();
			return Ok();
		}
	}
}
