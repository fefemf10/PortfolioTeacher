// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.

using PortfolioShared.Models;
using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Pages.Account.Register;

public class InputModel
{
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
    public string RoleName { get; set; }
	public string Button { get; set; }
}
