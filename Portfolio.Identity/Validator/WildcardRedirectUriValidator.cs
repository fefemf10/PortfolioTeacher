using Duende.IdentityServer.Models;
using Duende.IdentityServer.Validation;

namespace Portfolio.Identity.Validator
{
    public class WildcardRedirectUriValidator : IRedirectUriValidator
    {
        public Task<bool> IsRedirectUriValidAsync(RedirectUriValidationContext context)
        {
            var uri = new Uri(context.RequestedUri);
            return Task.FromResult(uri.AbsolutePath == "/authentication/login-callback");
        }

        public Task<bool> IsPostLogoutRedirectUriValidAsync(string requestedUri, Client client)
        {
            var uri = new Uri(requestedUri);
            return Task.FromResult(uri.AbsolutePath == "/authentication/logout-callback");
        }

        public Task<bool> IsRedirectUriValidAsync(string requestedUri, Client client)
        {
            var uri = new Uri(requestedUri);
            return Task.FromResult(uri.AbsolutePath == "/authentication/login-callback");
        }
    }
}
