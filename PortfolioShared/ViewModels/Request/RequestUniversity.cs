using System.ComponentModel.DataAnnotations;

namespace PortfolioShared.ViewModels.Request
{
    public class RequestUniversity
    {
        public Guid Id { get; set; }
		[Required(ErrorMessageResourceName = "NameRequired", ErrorMessageResourceType = typeof(Resources.Localization.ValidationFields))]
		public string Name { get; set; }
		[Required(ErrorMessageResourceName = "SpecializationRequired", ErrorMessageResourceType = typeof(Resources.Localization.ValidationFields))]
		public string Specialization { get; set; }
		[Required(ErrorMessageResourceName = "QualificationRequired", ErrorMessageResourceType = typeof(Resources.Localization.ValidationFields))]
		public string Qualification { get; set; }
		[Required(ErrorMessageResourceName = "YearGraduationRequired", ErrorMessageResourceType = typeof(Resources.Localization.ValidationFields))]
		public int YearGraduation { get; set; }
    }
}
