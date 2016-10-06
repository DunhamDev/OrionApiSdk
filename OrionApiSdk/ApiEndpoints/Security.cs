using Newtonsoft.Json.Linq;
using OrionApiSdk.Objects;
using OrionApiSdk.Objects.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints
{
    public class Security : ApiEndpointBase
    {
        public Security(AuthToken token) : base("Security")
        {
            UpdateAuthToken(token);
        }

        private Security(string username, string password) : base("Security")
        {
            UpdateCredentials(username, password);
        }

        public List<User> Users()
        {
            return UsersAsync().Result;
        }
        public async Task<List<User>> UsersAsync()
        {
            JToken usersList = await GetJsonAsync("Users");
            return usersList.ToObject<List<User>>();
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
