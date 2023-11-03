// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.

using PortfolioShared.Models;
using System.ComponentModel.DataAnnotations;

namespace IdentityServerHost.Pages.Register;

public class InputModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }

    public string ReturnUrl { get; set; }
    [Required]
    [EnumDataType(typeof(Roles))]
    public string RoleName { get; set; }
	public string Button { get; set; }
}
