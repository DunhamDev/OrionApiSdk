using Newtonsoft.Json.Linq;
using OrionApiSdk.Objects;
using OrionApiSdk.Objects.Authorization;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Authorization
{
    public class AuthorizationEndpoint : ApiEndpointBase
    {
        /// <summary>
        /// Constructs an /Authorization endpoint instance
        /// </summary>
        /// <param name="token">The access token of the user making requests</param>
        public AuthorizationEndpoint(AuthToken token) : base("Authorization", token)
        {
        }

        /// <summary>
        /// Gets the user's profile information
        /// </summary>
        /// <returns>The user's profile</returns>
        public UserProfile User()
        {
            return UserAsync().Result;
        }
        /// <summary>
        /// Gets the user's profile information
        /// </summary>
        /// <returns>The user's profile</returns>
        public async Task<UserProfile> UserAsync()
        {
            JToken userJson = await GetJsonAsync("User");
            return userJson.ToObject<UserProfile>();
        }
    }
}
