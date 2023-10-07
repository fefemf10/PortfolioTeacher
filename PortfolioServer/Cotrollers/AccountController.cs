using Microsoft.AspNetCore.Mvc;

namespace PortfolioServer.Cotrollers
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
