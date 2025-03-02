// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.

using Portfolio.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Identity.Pages.Account.Register;

public class InputModel
{
    [Required(ErrorMessageResourceName = "LastNameRequired", ErrorMessageResourceType = typeof(Resources.Pages.Account.Register.InputModel))]
    public string LastName { get; set; }
    [Required(ErrorMessageResourceName = "FirstNameRequired", ErrorMessageResourceType = typeof(Resources.Pages.Account.Register.InputModel))]
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    [Required(ErrorMessageResourceName = "EmailRequired", ErrorMessageResourceType = typeof(Resources.Pages.Account.Register.InputModel))]
    [EmailAddress(ErrorMessageResourceName = "EmailError", ErrorMessageResourceType = typeof(Resources.Pages.Account.Register.InputModel))]
    public string Email { get; set; }
    [Required(ErrorMessageResourceName = "PasswordRequired", ErrorMessageResourceType = typeof(Resources.Pages.Account.Register.InputModel))]
    [MinLength(5, ErrorMessageResourceName = "PasswordLength", ErrorMessageResourceType = typeof(Resources.Pages.Account.Register.InputModel))]
	[DataType(DataType.Password)]
	public string Password { get; set; }
	[Required(ErrorMessageResourceName = "ConfirmPasswordRequired", ErrorMessageResourceType = typeof(Resources.Pages.Account.Register.InputModel))]
	[MinLength(5, ErrorMessageResourceName = "PasswordLength", ErrorMessageResourceType = typeof(Resources.Pages.Account.Register.InputModel))]
	[DataType(DataType.Password)]
    [Compare("Password", ErrorMessageResourceName = "PasswordCompare", ErrorMessageResourceType = typeof(Resources.Pages.Account.Register.InputModel))]
	public string ConfirmPassword { get; set; }

    public string ReturnUrl { get; set; }
	[Required(ErrorMessageResourceName = "RoleRequired", ErrorMessageResourceType = typeof(Resources.Pages.Account.Register.InputModel))]
	[EnumDataType(typeof(Roles))]
    public Roles RoleName { get; set; }
    public Guid DepartmentId { get; set; }
	public string Button { get; set; }
}
