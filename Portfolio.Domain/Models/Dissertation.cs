using System.Text.Json.Serialization;

namespace Portfolio.Domain.Models
{
    public class Dissertation : Publication
    {
        public Dissertation() { PublicationType = PublicationType.Dissertation; }
    }
}
