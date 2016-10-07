using OrionApiSdk.ApiEndpoints;
using OrionApiSdk.Objects;
using OrionApiSdk.Objects.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk
{
    public class OrionApi
    {
        public AuthToken AuthToken { get; private set; }

        private Authorization _authorizationEndpoint;
        public Authorization AuthorizationEndpoint
        {
            get
            {
                return _authorizationEndpoint ?? (_authorizationEndpoint = new Authorization(AuthToken));
            }
        }

        private Portfolio _portfolioEndpoint;
        public Portfolio PortolioEndpoint
        {
            get
            {
                return _portfolioEndpoint ?? (_portfolioEndpoint = new Portfolio(AuthToken));
            }
        }

        private Security _securityEndpoint;
        public Security SecurityEndpoint
        {
            get
            {
                return _securityEndpoint ?? (_securityEndpoint = new Security(AuthToken));
            }
        }

        public OrionApi(AuthToken token)
        {
            AuthToken = token;
        }

        public static AuthToken GetUserAuthToken(string username, string password)
        {
            return GetUserAuthTokenAsync(username,password).Result;
        }
        public static async Task<AuthToken> GetUserAuthTokenAsync(string username, string password)
        {
            return await Security.TokenAsync(username, password);
        }

        public bool IsAuthTokenValid()
        {
            return IsAuthTokenValidAsync().Result;
        }
        public async Task<bool> IsAuthTokenValidAsync()
        {
            UserProfile user = await AuthorizationEndpoint.UserAsync();
            return user != null;
        }
    }
}
