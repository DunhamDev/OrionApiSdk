using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OrionApiSdk.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints
{
    public class Security : ApiEndpointBase
    {
        public Security() : base("Security")
        {

        }

        internal AuthToken Token(string username, string password)
        {
            return TokenAsync(username, password).Result;
        }
        internal async Task<AuthToken> TokenAsync(string username, string password)
        {
            UpdateCredentials(username, password);
            JObject tokenJson = await GetJsonAsync("Token");
            return tokenJson.ToObject<AuthToken>();
        }
    }
}
