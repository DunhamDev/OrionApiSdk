using OrionApiSdk.ApiEndpoints;
using OrionApiSdk.Objects;
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
        public Authorization Authorization
        {
            get
            {
                return _authorizationEndpoint ?? (_authorizationEndpoint = new Authorization(AuthToken));
            }
        }

        private Security _securityEndpoint;
        public Security Security
        {
            get
            {
                return _securityEndpoint ?? (_securityEndpoint = new Security());
            }
        }

        public OrionApi()
        {
            AuthToken = null;
        }
        public OrionApi(AuthToken token)
        {
            AuthToken = token;
        }

        public AuthToken AuthenticateUser(string username, string password)
        {
            return AuthenticateUserAsync(username,password).Result;
        }
        public async Task<AuthToken> AuthenticateUserAsync(string username, string password)
        {
            AuthToken = await Security.TokenAsync(username, password);
            return AuthToken;
        }

        public bool IsAuthTokenValid()
        {
            return IsAuthTokenValidAsync().Result;
        }
        public async Task<bool> IsAuthTokenValidAsync()
        {
            User user = await Authorization.UserAsync();
            return user != null;
        }
    }
}
