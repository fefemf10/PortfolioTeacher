using Duende.IdentityModel;
using Duende.IdentityServer;
using Duende.IdentityServer.Events;
using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using Duende.IdentityServer.Stores;
using IdentityServer.Pages.Account.Login;
using IdentityServerHost.Pages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.VisualBasic;
using Portfolio.Domain.Models;
using Portfolio.Identity.Exceptions;
using Portfolio.Identity.Models;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Identity.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController(
    IIdentityServerInteractionService interaction,
    IClientStore clientStore,
    IAuthenticationSchemeProvider schemeProvider,
    IIdentityProviderStore identityProviderStore,
    IEventService events,
    RoleManager<IdentityRole<Guid>> roleManager,
    UserManager<IdentityUser<Guid>> userManager,
    SignInManager<IdentityUser<Guid>> signInManager) : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody][Required] LoginData loginData)
        {
            var context = await interaction.GetAuthorizationContextAsync(loginData.ReturnUrl);
            if (loginData.Button == "cancel")
            {
                if (context != null)
                {
                    await interaction.DenyAuthorizationAsync(context, AuthorizationError.AccessDenied);
                    return Redirect(loginData.ReturnUrl);
                }
                return Redirect("~/");
            }

            var result = await signInManager.PasswordSignInAsync(loginData.Email, loginData.Password, loginData.RememberLogin, true);
            if (result.Succeeded)
            {
                var user = await userManager.FindByEmailAsync(loginData.Email);
                await events.RaiseAsync(new UserLoginSuccessEvent(user.Email, user.Id.ToString(), user.UserName, clientId: context?.Client.ClientId));
                if (context != null)
                {
                    return Redirect(loginData.ReturnUrl);
                }
                if (Url.IsLocalUrl(loginData.ReturnUrl))
                {
                    return Redirect(loginData.ReturnUrl);
                }
                if (string.IsNullOrEmpty(loginData.ReturnUrl))
                {
                    return Redirect("~/");
                }
                throw new Exception("invalid return URL");
            }
            await events.RaiseAsync(new UserLoginFailureEvent(loginData.Email, "invalid credentials", clientId: context?.Client.ClientId));
            throw new SignInException();
        }
        [HttpPost("Register")]
        public async Task<ActionResult> Register([FromBody][Required] LoginData loginData)
        {
            var existingUser = await userManager.FindByEmailAsync(loginData.Email);
            if (existingUser != null)
            {
                throw new AlreadyExistException();
            }
            IdentityUser<Guid> user = new()
            {
                UserName = loginData.Email,
                Email = loginData.Email,
                EmailConfirmed = true,
            };
            IdentityResult result = await userManager.CreateAsync(user, loginData.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, Roles.Teacher.ToString());
                var loginresult = await signInManager.PasswordSignInAsync(loginData.Email, loginData.Password, false, lockoutOnFailure: true);
                if (loginresult.Succeeded)
                {
                    if (Url.IsLocalUrl(loginData.ReturnUrl))
                    {
                        return Redirect(loginData.ReturnUrl);
                    }
                    else if (string.IsNullOrEmpty(loginData.ReturnUrl))
                    {
                        return Redirect("~/");
                    }
                    else
                    {
                        throw new Exception("invalid return URL");
                    }
                }
                throw new SignInException();
            }
            
            throw new CreateUserException(result.Errors.First().Description);
        }
        [HttpPost("Logout")]
        public async Task<ActionResult> Logout(string logoutId)
        {
            var logout = await interaction.GetLogoutContextAsync(logoutId);
            if (User?.Identity.IsAuthenticated == true)
            {
                await signInManager.SignOutAsync();
                await events.RaiseAsync(new UserLogoutSuccessEvent(User.GetSubjectId(), User.GetDisplayName()));
                var idp = User.FindFirst(JwtClaimTypes.IdentityProvider)?.Value;
                if (idp != null && idp != IdentityServerConstants.LocalIdentityProvider)
                {
                    if (await HttpContext.GetSchemeSupportsSignOutAsync(idp))
                    {
                        var url = Url.Page("/Account/Logout/Loggedout", new { logoutId = logoutId });
                        return SignOut(new AuthenticationProperties { RedirectUri = url }, idp);
                    }
                }
            }
            return Redirect(logout.PostLogoutRedirectUri);
        }
    }
}
