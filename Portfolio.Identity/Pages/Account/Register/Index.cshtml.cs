using Duende.IdentityServer.Services;
using Duende.IdentityServer.Stores;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Portfolio.Application.ViewModels.Request;
using Portfolio.Application.ViewModels.Response;
using Portfolio.Domain.Models;
using Portfolio.Identity.Pages.Account.Register;

namespace IdentityServer.Pages.Account.Register;

public class Index(
	IIdentityServerInteractionService interaction,
	IClientStore clientStore,
	IAuthenticationSchemeProvider schemeProvider,
	IIdentityProviderStore identityProviderStore,
	IEventService events,
	IHttpClientFactory httpClientFactory,
	RoleManager<IdentityRole<Guid>> roleManager,
	UserManager<IdentityUser<Guid>> userManager,
	SignInManager<IdentityUser<Guid>> signInManager,
	IStringLocalizer<Roles> localizer) : PageModel
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
			var user = new IdentityUser<Guid>()
			{
				UserName = Input.Email,
				Email = Input.Email,
				EmailConfirmed = true,
			};

			var result = await userManager.CreateAsync(user, Input.Password);

			if (result.Succeeded)
			{
				await userManager.AddToRoleAsync(user, Input.RoleName.ToString());
				HttpClient httpClient = httpClientFactory.CreateClient("PortfolioServer");
				List<ResponseFacultyDepartments> requestFacultyDepartments;
				requestFacultyDepartments = await httpClient.GetFromJsonAsync<List<ResponseFacultyDepartments>>("api/Faculty/GetAllWithDepartments");
				Guid facultyId = requestFacultyDepartments.First().Id;
				foreach (var faculty in requestFacultyDepartments)
				{
					var department = faculty.Departments.FirstOrDefault(y => y.Id == Input.DepartmentId);
                    if (department is not null)
					{
						facultyId = faculty.Id;
						break;
					}
				}
                JsonContent js = JsonContent.Create(new RequestAddTeacher() { Id = user.Id, Email = user.Email, FirstName = Input.FirstName, LastName = Input.LastName, MiddleName = Input.MiddleName, Role = Input.RoleName, FacultyId = facultyId, DepartmentId = Input.DepartmentId });
				HttpResponseMessage httpResponse = await httpClient.PostAsync("api/Teacher", js);
				if (httpResponse.IsSuccessStatusCode)
				{
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
				else
				{
					await userManager.DeleteAsync(user);
				}
			}
		}
		await BuildModelAsync(Input.ReturnUrl);
		return Page();
	}

	private async Task BuildModelAsync(string returnUrl)
	{
		HttpClient httpClient = httpClientFactory.CreateClient("PortfolioServer");
		Input = new InputModel { ReturnUrl = returnUrl };
        List<ResponseFacultyDepartments> requestFacultyDepartments = await httpClient.GetFromJsonAsync<List<ResponseFacultyDepartments>>("api/Faculty/departments");
		List<SelectListGroup> facultyList = requestFacultyDepartments.Select(x => new SelectListGroup { Name = x.Name }).ToList();
		View = new ViewModel
		{
            RolesList = new List<SelectListItem>(),
			FacultyDepartments = new List<SelectListItem>()
		};
		foreach (var faculty in requestFacultyDepartments)
		{
			View.FacultyDepartments.AddRange(faculty.Departments.Select(y => new SelectListItem { Value = y.Id.ToString(), Text = y.Name, Group = facultyList.Find(z => z.Name == faculty.Name) }));
		}
		View.RolesList.Add(new SelectListItem(localizer[Roles.Teacher.ToString()], Roles.Teacher.ToString()));
		View.RolesList.Add(new SelectListItem(localizer[Roles.Student.ToString()], Roles.Student.ToString()));
	}
}
