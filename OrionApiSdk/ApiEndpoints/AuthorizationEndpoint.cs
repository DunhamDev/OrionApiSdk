using Newtonsoft.Json.Linq;
using OrionApiSdk.Objects;
using OrionApiSdk.Objects.Authorization;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints
{
    public class AuthorizationEndpoint : ApiEndpointBase
    {
        public AuthorizationEndpoint(AuthToken token) : base("Authorization", token)
        {
        }

        public UserProfile User()
        {
            return UserAsync().Result;
        }
        public async Task<UserProfile> UserAsync()
        {
            JToken userJson = await GetJsonAsync("User");
            return userJson.ToObject<UserProfile>();
        }
    }
}
