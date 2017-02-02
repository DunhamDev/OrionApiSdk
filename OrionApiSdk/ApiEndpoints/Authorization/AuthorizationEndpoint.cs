using Newtonsoft.Json.Linq;
using OrionApiSdk.ApiEndpoints.Abstract;
using OrionApiSdk.ApiEndpoints.Authorization.Interfaces;
using OrionApiSdk.Objects;
using OrionApiSdk.Objects.Authorization;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Authorization
{
    public class AuthorizationEndpoint : ApiEndpointBase, IAuthorizationEndpoint
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
        public UserProfile User()
        {
            return UserAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        }
        /// <summary>
        /// HTTP GET: /Authorization/User
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
