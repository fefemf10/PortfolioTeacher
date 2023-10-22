using Microsoft.AspNetCore.Mvc;

namespace PortfolioShared.Cotrollers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : Controller
	{
		private readonly ApplicationContext db;
		public AccountController(ApplicationContext db)
		{
			this.db = db;
		}
	}
}
