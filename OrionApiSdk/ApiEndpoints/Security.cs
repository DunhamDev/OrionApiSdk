using Newtonsoft.Json.Linq;
using OrionApiSdk.Objects;
using OrionApiSdk.Objects.Authorization;
using OrionApiSdk.Objects.Security;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints
{
    public class Security : ApiEndpointBase
    {
        public Security(AuthToken token) : base("Security", token.AccessToken)
        {
        }

        private Security(string username, string password) : base("Security")
        {
            UpdateCredentials(username, password);
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
            Security tempSecurityEndpoit = new Security(username, password);
            JToken tokenJson = await tempSecurityEndpoit.GetJsonAsync("Token");
            return tokenJson.ToObject<AuthToken>();
        }
    }
}
