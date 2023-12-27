using System.ComponentModel.DataAnnotations;

namespace PortfolioShared.ViewModels.Request
{
    public class RequestWork
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessageResourceName = "NameRequired", ErrorMessageResourceType = typeof(Resources.Localization.ValidationFields))]
        public required string Name { get; set; }
        [Required(ErrorMessageResourceName = "PostRequired", ErrorMessageResourceType = typeof(Resources.Localization.ValidationFields))]
        public required string Post { get; set; }
        public required DateOnly BeginTimeWork { get; set; } = DateOnly.FromDateTime(DateTimeOffset.Now.DateTime);
        public DateOnly? EndTimeWork { get; set; }
    }
}
