using Newtonsoft.Json.Linq;
using OrionApiSdk.Objects;
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

        internal static AuthToken Token(string username, string password)
        {
            return TokenAsync(username, password).Result;
        }
        internal static async Task<AuthToken> TokenAsync(string username, string password)
        {
            Security tempSecurityEndpoit = new Security(username, password);
            JObject tokenJson = await tempSecurityEndpoit.GetJsonAsync("Token");
            return tokenJson.ToObject<AuthToken>();
        }
    }
}
