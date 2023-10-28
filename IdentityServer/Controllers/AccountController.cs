using Duende.IdentityServer.Services;
using Duende.IdentityServer.Stores;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Controllers
{
	[AllowAnonymous]
	public class AccountController : Controller
	{
		private readonly IIdentityServerInteractionService interaction;
		private readonly IClientStore clientStore;
		private readonly IAuthenticationSchemeProvider schemeProvider;
		private readonly IEventService events;
		private readonly SignInManager<IdentityUser> signInManager;
		public AccountController(IIdentityServerInteractionService interaction, IClientStore clientStore, IAuthenticationSchemeProvider schemeProvider, IEventService events, SignInManager<IdentityUser> signInManager)
		{
			this.interaction = interaction;
			this.clientStore = clientStore;
			this.schemeProvider = schemeProvider;
			this.events = events;
			this.signInManager = signInManager;
		}
		[HttpGet]
		public async Task<IActionResult> Login(string returnUrl)
		{
			// build a model so we know what to show on the login page
			var vm = await BuildLoginViewModelAsync(returnUrl);

			if (vm.IsExternalLoginOnly)
			{
				// we only have one option for logging in and it's an external provider
				return RedirectToAction("Challenge", "External", new { scheme = vm.ExternalLoginScheme, returnUrl });
			}

			return View(vm);
		}
		public IActionResult Index()
		{
			return View();
		}
	}
}
