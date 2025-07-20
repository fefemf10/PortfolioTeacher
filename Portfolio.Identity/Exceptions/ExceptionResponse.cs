using System.Net;
namespace Portfolio.Identity.Exceptions
{
    public record ExceptionResponse(HttpStatusCode StatusCode, string Description);
}
