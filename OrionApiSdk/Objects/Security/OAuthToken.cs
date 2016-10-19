using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects.Security
{
    internal class OAuthToken : AuthToken
    {
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    }
}
