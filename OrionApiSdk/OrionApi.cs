using OrionApiSdk.ApiEndpoints;
using OrionApiSdk.ApiEndpoints.Portfolio;
using OrionApiSdk.ApiEndpoints.Trading;
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

        private AuthorizationEndpoint _authorizationEndpoint;
        public AuthorizationEndpoint Authorization
        {
            get
            {
                return _authorizationEndpoint ?? (_authorizationEndpoint = new AuthorizationEndpoint(AuthToken));
            }
        }

        private PortfolioEndpoint _portfolioEndpoint;
        public PortfolioEndpoint Portfolio
        {
            get
            {
                return _portfolioEndpoint ?? (_portfolioEndpoint = new PortfolioEndpoint(AuthToken));
            }
        }

        private SecurityEndpoint _securityEndpoint;
        public SecurityEndpoint Security
        {
            get
            {
                return _securityEndpoint ?? (_securityEndpoint = new SecurityEndpoint(AuthToken));
            }
        }

        private TradingEndpoint _tradingEndpoint;
        public TradingEndpoint Trading
        {
            get
            {
                return _tradingEndpoint ?? (_tradingEndpoint = new TradingEndpoint(AuthToken));
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
            return await SecurityEndpoint.TokenAsync(username, password);
        }

        public bool IsAuthTokenValid()
        {
            return IsAuthTokenValidAsync().Result;
        }
        public async Task<bool> IsAuthTokenValidAsync()
        {
            UserProfile user = await Authorization.UserAsync();
            return user != null;
        }
    }
}
