using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioShared.Helpers;
using PortfolioShared.Models;
using PortfolioShared.ViewModels.Request;
using PortfolioShared.ViewModels.Response;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Reflection;

namespace PortfolioShared.Cotrollers
{
	[Authorize]
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly ApplicationContext db;
		public UserController(ApplicationContext db)
		{
			this.db = db;
		}
		[HttpGet]
		public ActionResult<ResponseUser> GetInfo(Guid Guid)
		{
			User? user = db.Users.FirstOrDefault(user => user.Id == Guid);
			if (user is null)
				return BadRequest();
            ResponseUser responseUser = new(user.Id, user.Email, user.FirstName, user.MiddleName, user.LastName, user.DateBirthday);
			return Ok(responseUser);
		}
	}
}
