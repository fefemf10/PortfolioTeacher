using Duende.IdentityServer.Services;
using Duende.IdentityServer.Stores;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Portfolio.Domain.Models;
using Portfolio.Identity.Pages.Account.Register;

namespace IdentityServer.Pages.Account.Register;

public class Index(
	IIdentityServerInteractionService interaction,
	IClientStore clientStore,
	IAuthenticationSchemeProvider schemeProvider,
	IIdentityProviderStore identityProviderStore,
	IEventService events,
	RoleManager<IdentityRole<Guid>> roleManager,
	UserManager<IdentityUser<Guid>> userManager,
	SignInManager<IdentityUser<Guid>> signInManager,
	IStringLocalizer<Roles> localizer,
    IStringLocalizer<InputModel> inputLocalizer) : PageModel
{
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
		if (ModelState.IsValid)
		{
            var existingUser = await userManager.FindByEmailAsync(Input.Email);
			if (existingUser != null)
			{
				ModelState.AddModelError(string.Empty, inputLocalizer["UserAlreadyExist"]);
                await BuildModelAsync(Input.ReturnUrl);
                return Page();
            }
			IdentityUser<Guid> user = new()
			{
				UserName = Input.Email,
				Email = Input.Email,
				EmailConfirmed = true,
			};
			IdentityResult result = await userManager.CreateAsync(user, Input.Password);
			if (result.Succeeded)
			{
				await userManager.AddToRoleAsync(user, Input.RoleName.ToString());
				var loginresult = await signInManager.PasswordSignInAsync(Input.Email, Input.Password, false, lockoutOnFailure: true);
				if (loginresult.Succeeded)
				{
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
			RolesList = new List<SelectListItem>()
		};
		View.RolesList.Add(new SelectListItem(localizer[Roles.Teacher.ToString()], Roles.Teacher.ToString()));
		View.RolesList.Add(new SelectListItem(localizer[Roles.Student.ToString()], Roles.Student.ToString()));
	}
}
