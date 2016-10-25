using Newtonsoft.Json.Linq;
using OrionApiSdk.ApiEndpoints.Abstract;
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
        /// HTTP GET: /Authorization/User
        /// Gets the user's profile information
        /// </summary>
        /// <returns>The user's profile</returns>
        public UserDetails User()
        {
            return UserAsync().Result;
        }
        /// <summary>
        /// HTTP GET: /Authorization/User
        /// Gets the user's profile information
        /// </summary>
        /// <returns>The user's profile</returns>
        public async Task<UserDetails> UserAsync()
        {
            JToken userJson = await GetJsonAsync("User");
            return userJson.ToObject<UserDetails>();
        }
    }
}
