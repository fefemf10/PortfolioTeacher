using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Application.ViewModels.Request
{
    public class RequestProfessionalDevelopment
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string NameOrganization { get; set; }
        public required string NameDocument { get; set; }
        public string? SeriaDocument { get; set; }
        public string? NumberDocument { get; set; }
        public DateOnly? DateСompletion { get; set; }
        public int? ListeningTime { get; set; }
    }
}
