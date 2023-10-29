using Duende.IdentityServer.Services;
using Duende.IdentityServer.Stores;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Controllers
{
	[AllowAnonymous]
	[ApiController]
	[Route("[controller]/[action]")]
	public class AccountController : ControllerBase
	{
		private readonly IIdentityServerInteractionService interaction;
		private readonly IClientStore clientStore;
		private readonly IAuthenticationSchemeProvider schemeProvider;
		private readonly IEventService events;
		private readonly SignInManager<IdentityUser<Guid>> signInManager;
		private readonly UserManager<IdentityUser<Guid>> userManager;
		public AccountController(IIdentityServerInteractionService interaction, IClientStore clientStore, IAuthenticationSchemeProvider schemeProvider, IEventService events, SignInManager<IdentityUser<Guid>> signInManager, UserManager<IdentityUser<Guid>> userManager)
		{
			this.interaction = interaction;
			this.clientStore = clientStore;
			this.schemeProvider = schemeProvider;
			this.events = events;
			this.signInManager = signInManager;
			this.userManager = userManager;
		}
	}
}
