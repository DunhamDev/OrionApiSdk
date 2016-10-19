using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using System.Security.Claims;
using Microsoft.Owin.Infrastructure;
using Microsoft.Owin;
using Microsoft.Owin.Logging;
using System.Net.Http;

namespace OrionApiSdk.Owin.Providers.Orion
{
    public class OrionAuthenticationHandler : AuthenticationHandler<OrionAuthenticationOptions>
    {
        private const int HTTP_UNAUTHORIZED = 401;
        private const string AUTHORIZE_ENDPOINT = "https://api.orion.com/api/oauth";
        private const string TEST_AUTHORIZE_ENDPOINT = "https://testapi.orion.com/api/oauth";

        private readonly ILogger _logger;

        public OrionAuthenticationHandler(ILogger logger)
        {
            _logger = logger;
        }

        protected override async Task<AuthenticationTicket> AuthenticateCoreAsync()
        {
            AuthenticationProperties properties = null;
            ClaimsIdentity identity = new ClaimsIdentity(Options.SignInAsAutenticationType);

            try
            {
                string state = GetChallengeResponseState();
                string temporaryToken = GetChallengeTemporaryToken();

                properties = Options.StateDataFormat.Unprotect(state);
                if (properties == null)
                {
                    return null;
                }

                if (!ValidateCorrelationId(properties, _logger))
                {
                    return new AuthenticationTicket(null, properties);
                }

                string requestPrefix = Request.Scheme + "://" + Request.Host;
                string redirectUri = requestPrefix + Request.PathBase + Options.CallbackPath;


            }
            catch (Exception ex)
            {
                _logger.WriteError("Authentication failed", ex);
                return new AuthenticationTicket(null, properties);
            }

            throw new NotImplementedException();
        }
        private string GetChallengeTemporaryToken()
        {
            string temporaryToken = null;
            IReadableStringCollection query = Request.Query;
            IList<string> values = query.GetValues("code");
            if (values != null && values.Count == 1)
            {
                temporaryToken = values[0];
            }
            return temporaryToken;
        }
        private string GetChallengeResponseState()
        {
            string state = null;
            IReadableStringCollection query = Request.Query;
            IList<string> values = query.GetValues("state");
            if (values != null && values.Count == 1)
            {
                state = values[0];
            }
            return state;
        }

        #region ApplyResponseChallengeAsync
        protected override Task ApplyResponseChallengeAsync()
        {
            if (Response.StatusCode == HTTP_UNAUTHORIZED)
            {
                AuthenticationResponseChallenge challenge = Helper.LookupChallenge(Options.AuthenticationType, Options.AuthenticationMode);
                if (challenge != null)
                {
                    PerformChallengeRedirect(challenge);
                }
            }

            return Task.FromResult<object>(null);
        }
        private void PerformChallengeRedirect(AuthenticationResponseChallenge challenge)
        {
            string baseUri =
                Request.Scheme +
                Uri.SchemeDelimiter +
                Request.Host +
                Request.PathBase;
            string currentUri =
                baseUri +
                Request.Path +
                Request.QueryString;
            string redirectUri =
                baseUri +
                Options.CallbackPath;

            AuthenticationProperties properties = GetChallengeProperties(challenge, currentUri);

            GenerateCorrelationId(properties);

            Dictionary<string, string> queryStringParams = BuildChallengeRedirectQueryStringParams(redirectUri, properties);

            string authorizationEndpoint = WebUtilities.AddQueryString(
                (Options.UseTestApiEndpoint ? TEST_AUTHORIZE_ENDPOINT : AUTHORIZE_ENDPOINT),
                queryStringParams
            );
            Response.Redirect(authorizationEndpoint);
        }
        private static AuthenticationProperties GetChallengeProperties(AuthenticationResponseChallenge challenge, string currentUri)
        {
            AuthenticationProperties properties = challenge.Properties;
            if (string.IsNullOrWhiteSpace(properties.RedirectUri))
            {
                properties.RedirectUri = currentUri;
            }

            return properties;
        }
        private Dictionary<string, string> BuildChallengeRedirectQueryStringParams(string redirectUri, AuthenticationProperties properties)
        {
            Dictionary<string, string> queryStringParams = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            queryStringParams.Add("response_type", "code");
            queryStringParams.Add("redirect_uri", redirectUri);
            queryStringParams.Add("client_id", Options.ClientId);
            queryStringParams.Add("state", Options.StateDataFormat.Protect(properties));
            return queryStringParams;
        }
        #endregion

        public override async Task<bool> InvokeAsync()
        {
            return await base.InvokeAsync();
        }

        private async Task<bool> InvokeReplyPathAsync()
        {
            if (Options.CallbackPath.HasValue && Options.CallbackPath == Request.Path)
            {
                AuthenticationTicket ticket = await AuthenticateAsync();
            }
            return false;
        }
    }
}
