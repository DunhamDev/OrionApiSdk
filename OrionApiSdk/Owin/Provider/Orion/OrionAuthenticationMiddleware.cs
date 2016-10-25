using Microsoft.Owin;
using Microsoft.Owin.Logging;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.Infrastructure;
using Owin;

namespace OrionApiSdk.Owin.Provider.Orion
{
    public class OrionAuthenticationMiddleware : AuthenticationMiddleware<OrionAuthenticationOptions>
    {
        private readonly ILogger _logger;

        public OrionAuthenticationMiddleware(OwinMiddleware next, IAppBuilder app, OrionAuthenticationOptions options) : base(next, options)
        {
            if (string.IsNullOrWhiteSpace(options.SignInAsAutenticationType))
            {
                options.SignInAsAutenticationType = app.GetDefaultSignInAsAuthenticationType();
            }
            if (options.StateDataFormat == null)
            {
                var dataProtector = app.CreateDataProtector(typeof(OrionAuthenticationMiddleware).FullName, options.AuthenticationType);
                options.StateDataFormat = new PropertiesDataFormat(dataProtector);
            }
            _logger = app.CreateLogger<OrionAuthenticationMiddleware>();
        }

        protected override AuthenticationHandler<OrionAuthenticationOptions> CreateHandler()
        {
            return new OrionAuthenticationHandler(_logger);
        }
    }
}
