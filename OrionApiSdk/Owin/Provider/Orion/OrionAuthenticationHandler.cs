using Microsoft.Owin;
using Microsoft.Owin.Infrastructure;
using Microsoft.Owin.Logging;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.Provider;
using OrionApiSdk.ApiEndpoints.Security;
using OrionApiSdk.Common.Extensions;
using OrionApiSdk.Objects;
using OrionApiSdk.Objects.Authorization;
using OrionApiSdk.Objects.Enums;
using OrionApiSdk.Objects.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OrionApiSdk.Owin.Provider.Orion
{
    public class OrionAuthenticationHandler : AuthenticationHandler<OrionAuthenticationOptions>
    {
        private const int HTTP_UNAUTHORIZED = 401;
        private const string AUTHORIZE_ENDPOINT = "https://api.orionadvisor.com/api/oauth";
        private const string TEST_AUTHORIZE_ENDPOINT = "https://testapi.orionadvisor.com/api/oauth";

        private readonly ILogger _logger;

        public OrionAuthenticationHandler(ILogger logger)
        {
            _logger = logger;
        }

        #region AuthenticateCoreAsync
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

                OAuthToken accessToken = await GetOAuthTokenFromTemporaryToken(temporaryToken);
                OrionApi api = new OrionApi(accessToken as AuthToken);
                UserProfile userProfile = await api.Authorization.UserAsync();
                UserInfoDetails userDetails = await api.Security.GetUsersAsync(userProfile.UserId);
                identity.AddClaims(userDetails.GetUserClaims());
                IncludeOrionSpecificClaims(identity, accessToken, userProfile);

                return new AuthenticationTicket(identity, properties);
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
        private async Task<OAuthToken> GetOAuthTokenFromTemporaryToken(string temporaryToken)
        {
            string requestPrefix = Request.Scheme + "://" + Request.Host;
            string redirectUri = requestPrefix + Request.PathBase + Options.CallbackPath;
            return await SecurityEndpoint.PostOAuthTemporaryTokenAsync(
                temporaryToken,
                redirectUri,
                Options.ClientId,
                Options.ClientSecret,
                Options.UseTestApiEndpoint
            );
        }
        private void IncludeOrionSpecificClaims(ClaimsIdentity identity, OAuthToken accessToken, UserInfoDetails userProfile)
        {
            string claimTypePrefix = string.Format("urn:{0}:", Options.AuthenticationType.ToLower());
            identity.AddClaim(new Claim(claimTypePrefix + "access_token", accessToken.AccessToken, ClaimValueTypes.String));
            identity.AddClaim(new Claim(claimTypePrefix + "refresh_token", accessToken.RefreshToken, ClaimValueTypes.String));

            var profileLoginEntities = userProfile.Profiles.Select(p => p.LoginEntity).Distinct();
            if (profileLoginEntities.Count() != 1)
            {
                throw new IndexOutOfRangeException("More than 1 LoginEntity found across user profiles");
            }

            LoginEntity userLoginEntity = profileLoginEntities.FirstOrDefault();
            identity.AddClaim(new Claim(claimTypePrefix + "loginEntityId", ((int)userLoginEntity).ToString(), ClaimValueTypes.Integer));
            identity.AddClaim(new Claim(claimTypePrefix + "loginEntityName", userLoginEntity.ToString(), ClaimValueTypes.String));
        }
        #endregion

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

        #region InvokeAsync
        public override async Task<bool> InvokeAsync()
        {
            return await InvokeReplyPathAsync();
        }

        private async Task<bool> InvokeReplyPathAsync()
        {
            if (Options.CallbackPath.HasValue && Options.CallbackPath == Request.Path)
            {
                AuthenticationTicket authTicket = await AuthenticateAsync();
                if (authTicket == null)
                {
                    _logger.WriteWarning("Invalid return state, unable to redirect");
                    Response.StatusCode = 500;
                    return true;
                }

                OrionReturnEndpointContext endpointContext = GetReturnEndpointContext(authTicket);
                SignInIdentity(endpointContext);
                RedirectUser(endpointContext);

                return endpointContext.IsRequestCompleted;
            }
            return false;
        }

        private OrionReturnEndpointContext GetReturnEndpointContext(AuthenticationTicket authTicket)
        {
            OrionReturnEndpointContext endpointContext = new OrionReturnEndpointContext(Context, authTicket);
            endpointContext.SignInAsAuthenticationType = Options.SignInAsAutenticationType;
            endpointContext.RedirectUri = authTicket.Properties.RedirectUri;

            return endpointContext;
        }

        private void SignInIdentity(OrionReturnEndpointContext endpointContext)
        {
            if (endpointContext.SignInAsAuthenticationType != null &&
                    endpointContext.Identity != null)
            {
                ClaimsIdentity grantIdentity = endpointContext.Identity;
                if (!string.Equals(grantIdentity.AuthenticationType, endpointContext.SignInAsAuthenticationType, StringComparison.Ordinal))
                {
                    grantIdentity = new ClaimsIdentity(grantIdentity.Claims, endpointContext.SignInAsAuthenticationType, grantIdentity.NameClaimType, grantIdentity.RoleClaimType);
                }
                Context.Authentication.SignIn(endpointContext.Properties, grantIdentity);
            }
        }

        private void RedirectUser(OrionReturnEndpointContext endpointContext)
        {
            if (!endpointContext.IsRequestCompleted && endpointContext.RedirectUri != null)
            {
                string redirectUri = endpointContext.RedirectUri;
                if (endpointContext.Identity == null)
                {
                    redirectUri = WebUtilities.AddQueryString(redirectUri, "error", "access_denied");
                }
                Response.Redirect(redirectUri);
                endpointContext.RequestCompleted();
            }
        }
        #endregion
    }
}
