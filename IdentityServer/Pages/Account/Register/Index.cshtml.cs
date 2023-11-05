using Duende.IdentityServer.Services;
using Duende.IdentityServer.Stores;
using IdentityModel;
using IdentityServerHost.Pages.Register;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using PortfolioShared.Models;
using System.Security.Claims;

namespace IdentityServer.Pages.Account.Register
{
    public class Index : PageModel
    {
		private readonly IClientStore clientStore;
		private readonly IEventService events;
		private readonly IIdentityProviderStore identityProviderStore;
		private readonly IIdentityServerInteractionService interaction;
		private readonly IAuthenticationSchemeProvider schemeProvider;
        private readonly IHubContext<RegistrationHub> hubContext;
		private readonly SignInManager<IdentityUser<Guid>> signInManager;
		private readonly UserManager<IdentityUser<Guid>> userManager;

		public Index(IIdentityServerInteractionService interaction, IClientStore clientStore, IAuthenticationSchemeProvider schemeProvider, IIdentityProviderStore identityProviderStore, IEventService events, IHubContext<RegistrationHub> hubContext, UserManager<IdentityUser<Guid>> userManager, SignInManager<IdentityUser<Guid>> signInManager)
        {
			this.userManager = userManager;
			this.signInManager = signInManager;
			this.interaction = interaction;
			this.clientStore = clientStore;
			this.schemeProvider = schemeProvider;
            this.hubContext = hubContext;
			this.identityProviderStore = identityProviderStore;
			this.events = events;
		}

		public ViewModel View { get; set; }

		[BindProperty]
        public InputModel Input { get; set; }

        public async Task<IActionResult> OnGet(string returnUrl)
        {
			await BuildModelAsync(returnUrl);

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
			var context = await interaction.GetAuthorizationContextAsync(Input.ReturnUrl);

			if (ModelState.IsValid)
            {
                var user = new IdentityUser<Guid>()
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    EmailConfirmed = true,

                };

                var result = await userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    await userManager.AddClaimsAsync(user, new Claim[] {
                        new Claim(JwtClaimTypes.Name, Input.Email),
                        new Claim(JwtClaimTypes.Email, Input.Email),
                        new Claim(JwtClaimTypes.Role, Input.RoleName)
                    });

                    var loginresult = await signInManager.PasswordSignInAsync(Input.Email, Input.Password, false, lockoutOnFailure: true);

                    if (loginresult.Succeeded)
                    {
                        await hubContext.Clients.All.SendAsync("Receive", user.Id, user.Email, Enum.Parse<Roles>(Input.RoleName));
                        if (Url.IsLocalUrl(Input.ReturnUrl))
                        {
                            return Redirect(Input.ReturnUrl);
                        }
                        else if (string.IsNullOrEmpty(Input.ReturnUrl))
                        {
                            return Redirect("~/");
                        }
                        else
                        {
                            throw new Exception("invalid return URL");
                        }
					}
				}
			}
			await BuildModelAsync(Input.ReturnUrl);
			return Page();
        }

        private async Task BuildModelAsync(string returnUrl)
        {
            Input = new InputModel { ReturnUrl = returnUrl };
            View = new ViewModel
            {
                RolesList = new List<string>() { Roles.Teacher.ToString(), Roles.Student.ToString() }
            };
        }
	}
}
