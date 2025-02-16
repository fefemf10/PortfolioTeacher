using System.Net;
namespace Portfolio.Application.Exceptions
{
    public record ExceptionResponse(HttpStatusCode StatusCode, string Description);
}
