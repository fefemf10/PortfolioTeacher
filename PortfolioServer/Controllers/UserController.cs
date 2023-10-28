using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioShared.Models;
using PortfolioShared.ViewModels.Response;

namespace PortfolioShared.Cotrollers
{
    [Authorize]
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class UserController : ControllerBase
	{
		private readonly ApplicationContext db;
		public UserController(ApplicationContext db)
		{
			this.db = db;
		}
		[HttpGet]
		public ResponseUser GetInfo(Guid Guid)
		{
			User user = db.Users.First(user => user.Id == Guid);
			ResponseUser responseUser = new(user.FirstName, user.MiddleName, user.LastName, user.DateBirthday, user.Email);
			return responseUser;
		}
	}
}
