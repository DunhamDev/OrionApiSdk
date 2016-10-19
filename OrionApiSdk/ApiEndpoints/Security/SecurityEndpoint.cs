using Newtonsoft.Json.Linq;
using OrionApiSdk.Objects;
using OrionApiSdk.Objects.Authorization;
using OrionApiSdk.Objects.Security;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Security
{
    public class SecurityEndpoint : ApiEndpointBase
    {
        public SecurityEndpoint(AuthToken token) : base("Security", token)
        {
        }

        private SecurityEndpoint(string username, string password) : base("Security")
        {
            UpdateCredentials(username, password);
        }
        private SecurityEndpoint(bool useTestApi) : base("Security", useTestApi)
        {

        }

        public List<UserInfoDetails> GetUsers()
        {
            return GetUsersAsync().Result;
        }
        public async Task<List<UserInfoDetails>> GetUsersAsync()
        {
            JToken usersList = await GetJsonAsync("Users");
            return usersList.ToObject<List<UserInfoDetails>>();
        }

        public UserInfoDetails GetUsers(int userId)
        {
            return GetUsersAsync(userId).Result;
        }
        public async Task<UserInfoDetails> GetUsersAsync(int userId)
        {
            JToken userJson = await GetJsonAsync("Users/" + userId.ToString());
            return userJson.ToObject<UserInfoDetails>();
        }

        public List<UserInfoDetails> PostUsers(params UserInfoDetails[] users)
        {
            return PostUsersAsync(users).Result;
        }
        public async Task<List<UserInfoDetails>> PostUsersAsync(params UserInfoDetails[] users)
        {
            JToken resultList = await PostJsonAsync("Users/Action/Import", users);
            return resultList.ToObject<List<UserInfoDetails>>();
        }

        internal static AuthToken Token(string username, string password)
        {
            return TokenAsync(username, password).Result;
        }
        internal static async Task<AuthToken> TokenAsync(string username, string password)
        {
            SecurityEndpoint tempSecurityEndpoit = new SecurityEndpoint(username, password);
            JToken tokenJson = await tempSecurityEndpoit.GetJsonAsync("Token");
            return tokenJson.ToObject<AuthToken>();
        }

        internal static OAuthToken PostOAuthTemporaryToken(string temporaryToken, string redirectUri, string clientId, string clientSecret, bool useTestApi)
        {
            return PostOAuthTemporaryTokenAsync(temporaryToken, redirectUri, clientId, clientSecret, useTestApi).Result;
        }
        internal static async Task<OAuthToken> PostOAuthTemporaryTokenAsync(string temporaryToken, string redirectUri, string clientId, string clientSecret, bool useTestApi)
        {
            SecurityEndpoint tempSecurityEndpoint = new SecurityEndpoint(useTestApi);
            var postData = new Dictionary<string, string>
            {
                { "grant_type", "authorization_code" },
                { "code", temporaryToken },
                { "redirect_uri", redirectUri },
                { "client_id", clientId },
                { "client_secret", clientSecret },
            };
            var oauthTokenJson = await tempSecurityEndpoint.PostJsonAsync("Token", new FormUrlEncodedContent(postData));

            return oauthTokenJson.ToObject<OAuthToken>();
        }
    }
}
