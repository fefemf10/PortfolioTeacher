using Duende.IdentityServer.Services;
using Duende.IdentityServer.Stores;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortfolioShared.Models;
using PortfolioShared.ViewModels.Request;
using PortfolioShared.ViewModels.Response;
using System.Security.Claims;

namespace IdentityServer.Pages.Account.Register;

public class Index : PageModel
{
	private readonly IClientStore clientStore;
	private readonly IEventService events;
	private readonly IIdentityProviderStore identityProviderStore;
	private readonly IIdentityServerInteractionService interaction;
	private readonly IAuthenticationSchemeProvider schemeProvider;
	private readonly SignInManager<IdentityUser<Guid>> signInManager;
	private readonly RoleManager<IdentityRole<Guid>> roleManager;
	private readonly UserManager<IdentityUser<Guid>> userManager;
	private readonly IHttpClientFactory httpClientFactory;

    public Index(IIdentityServerInteractionService interaction, IClientStore clientStore, IAuthenticationSchemeProvider schemeProvider, IIdentityProviderStore identityProviderStore, IEventService events, IHttpClientFactory httpClientFactory, RoleManager<IdentityRole<Guid>> roleManager, UserManager<IdentityUser<Guid>> userManager, SignInManager<IdentityUser<Guid>> signInManager)
	{
		this.roleManager = roleManager;
		this.userManager = userManager;
		this.signInManager = signInManager;
		this.interaction = interaction;
		this.clientStore = clientStore;
		this.schemeProvider = schemeProvider;
		this.httpClientFactory = httpClientFactory;
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
				await userManager.AddToRoleAsync(user, Input.RoleName);
				HttpClient httpClient = httpClientFactory.CreateClient("PortfolioServer");
                List<RequestFacultyDepartment> requestFacultyDepartments = await httpClient.GetFromJsonAsync<List<RequestFacultyDepartment>>($"Faculty/GetWithDepartment");
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
                JsonContent js = JsonContent.Create(new RequestAddTeacher() { Id = user.Id, Email = user.Email, Role = Input.RoleName, FacultyId = facultyId, DepartmentId = Input.DepartmentId });
				HttpResponseMessage httpResponse = await httpClient.PostAsync("Teacher/AddTeacher", js);
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
					else
					{

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
        List<RequestFacultyDepartment> requestFacultyDepartments = await httpClient.GetFromJsonAsync<List<RequestFacultyDepartment>>($"Faculty/GetWithDepartment");
		List<SelectListGroup> facultyList = requestFacultyDepartments.Select(x => new SelectListGroup { Name = x.Name }).ToList();
		View = new ViewModel
		{
			RolesList = new List<string>() { Roles.Teacher.ToString(), Roles.Student.ToString() },
			FacultyDepartments = new List<SelectListItem>()
			//FacultyDepartments = requestFacultyDepartments.Select(x => x.Departments.Select(y => new SelectListItem { Value = y.Id.ToString(), Text = y.Name, Group = facultyList.First() })).ToList()
		};
		foreach (var faculty in requestFacultyDepartments)
		{
			View.FacultyDepartments.AddRange(faculty.Departments.Select(y => new SelectListItem { Value = y.Id.ToString(), Text = y.Name, Group = facultyList.Find(z => z.Name == faculty.Name) }));
		}
	}
}
