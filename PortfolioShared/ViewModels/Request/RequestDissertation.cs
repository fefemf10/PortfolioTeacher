using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioShared.ViewModels.Request
{
	public class RequestDissertation
	{
		[Required]
		public Guid Id { get; set; }
		[Required(ErrorMessageResourceName = "NameRequired", ErrorMessageResourceType = typeof(Resources.Localization.ValidationFields))]
		public required string Name { get; set; }
		[Required(ErrorMessageResourceName = "YearProtectionRequired", ErrorMessageResourceType = typeof(Resources.Localization.ValidationFields))]
		public required DateOnly YearProtection { get; set; } = DateOnly.FromDateTime(DateTimeOffset.Now.DateTime);
	}
}
