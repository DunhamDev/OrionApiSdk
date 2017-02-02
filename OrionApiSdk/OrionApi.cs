using OrionApiSdk.ApiEndpoints.Authorization;
using OrionApiSdk.ApiEndpoints.Authorization.Interfaces;
using OrionApiSdk.ApiEndpoints.Billing;
using OrionApiSdk.ApiEndpoints.Billing.Interfaces;
using OrionApiSdk.ApiEndpoints.Portfolio;
using OrionApiSdk.ApiEndpoints.Portfolio.Interfaces;
using OrionApiSdk.ApiEndpoints.Security;
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
    public class OrionApi : IOrionApi
    {
        /// <summary>
        /// The access token for the user making the API requests
        /// </summary>
        public AuthToken AuthToken { get; private set; }

        /// <summary>
        /// Endpoint object behind <see cref="Authorization"/>
        /// </summary>
        private IAuthorizationEndpoint _authorizationEndpoint;
        /// <summary>
        /// /Authorization endpoint methods
        /// </summary>
        public IAuthorizationEndpoint Authorization
        {
            get
            {
                return _authorizationEndpoint ?? (_authorizationEndpoint = new AuthorizationEndpoint(AuthToken));
            }
        }

        /// <summary>
        /// Endpoint object behind <see cref="Billing"/>
        /// </summary>
        private IBillingEndpoint _billingEndpoint;
        /// <summary>
        /// /Billing endpoint methods
        /// </summary>
        public IBillingEndpoint Billing
        {
            get
            {
                return _billingEndpoint ??
                    (_billingEndpoint = new BillingEndpoint(AuthToken));
            }
        }

        /// <summary>
        /// Endpoint object behind <see cref="Portfolio"/>
        /// </summary>
        private IPortfolioEndpoint _portfolioEndpoint;
        /// <summary>
        /// /Portfolio endpoint methods
        /// </summary>
        public IPortfolioEndpoint Portfolio
        {
            get
            {
                return _portfolioEndpoint ?? (_portfolioEndpoint = new PortfolioEndpoint(AuthToken));
            }
        }

        /// <summary>
        /// Endpoint object behind <see cref="Security"/>
        /// </summary>
        private SecurityEndpoint _securityEndpoint;
        /// <summary>
        /// /Security endpoint methods
        /// </summary>
        public SecurityEndpoint Security
        {
            get
            {
                return _securityEndpoint ?? (_securityEndpoint = new SecurityEndpoint(AuthToken));
            }
        }

        /// <summary>
        /// Endpoint object behind <see cref="Trading"/>
        /// </summary>
        private TradingEndpoint _tradingEndpoint;
        /// <summary>
        /// /Trading endpoint methods
        /// </summary>
        public TradingEndpoint Trading
        {
            get
            {
                return _tradingEndpoint ?? (_tradingEndpoint = new TradingEndpoint(AuthToken));
            }
        }

        /// <summary>
        /// Constructs an OrionApi instance
        /// </summary>
        /// <param name="token">The authorization token for the user making API requests</param>
        public OrionApi(AuthToken token)
        {
            AuthToken = token;
        }

        /// <summary>
        /// Authorizies the given user credentials with Orion to retrieve an access token
        /// </summary>
        /// <param name="username">The user's Orion username</param>
        /// <param name="password">The user's Orion password</param>
        /// <returns>The user's access token</returns>
        public static AuthToken GetUserAuthToken(string username, string password)
        {
            return GetUserAuthTokenAsync(username,password).ConfigureAwait(false).GetAwaiter().GetResult();
        }
        /// <summary>
        /// Authorizies the given user credentials with Orion to retrieve an access token
        /// </summary>
        /// <param name="username">The user's Orion username</param>
        /// <param name="password">The user's Orion password</param>
        /// <returns>The user's access token</returns>
        public static async Task<AuthToken> GetUserAuthTokenAsync(string username, string password)
        {
            return await SecurityEndpoint.TokenAsync(username, password);
        }

        public void UseTestApi()
        {
            Authorization.UseTestApi();
            Billing.UseTestApi();
            Portfolio.UseTestApi();
            Security.UseTestApi();
            Trading.UseTestApi();
        }
        public void UseProductionApi()
        {
            Authorization.UseProductionApi();
            Billing.UseProductionApi();
            Portfolio.UseProductionApi();
            Security.UseProductionApi();
            Trading.UseProductionApi();
        }

        /// <summary>
        /// Attempts to see if the OrionApi instance's access token is still valid
        /// </summary>
        /// <returns>True iff the access token is valid, otherwise false</returns>
        public bool IsAuthTokenValid()
        {
            return IsAuthTokenValidAsync().Result;
        }
        /// <summary>
        /// Attempts to see if the OrionApi instance's access token is still valid
        /// </summary>
        /// <returns>True iff the access token is valid, otherwise false</returns>
        public async Task<bool> IsAuthTokenValidAsync()
        {
            UserProfile user = await Authorization.UserAsync();
            return user != null;
        }
    }
}
