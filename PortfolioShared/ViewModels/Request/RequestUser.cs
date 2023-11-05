using PortfolioShared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioShared.ViewModels.Request
{
	public class RequestUser
	{
		[Required]
		public Guid? Id { get; set; }
		[Required]
		[EmailAddress]
		public string? Email {get;set; }
		[Required]
		[EnumDataType(typeof(Roles))]
		public string? Role {get;set; }
	}
}
