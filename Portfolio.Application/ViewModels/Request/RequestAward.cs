using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.ViewModels.Request
{
    public class RequestAward
    {
        public Guid Id { get; set; }
		[Required(ErrorMessageResourceName = "NameRequired", ErrorMessageResourceType = typeof(Resources.Localization.ValidationFields))]
		public required string Name { get; set; }
		[Required(ErrorMessageResourceName = "NameOrganizationRequired", ErrorMessageResourceType = typeof(Resources.Localization.ValidationFields))]
		public required string NameOrganization { get; set; }
		public DateOnly? DateAward { get; set; }
    }
}
