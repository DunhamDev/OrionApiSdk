using Newtonsoft.Json.Linq;
using OrionApiSdk.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints
{
    public class Authorization : ApiEndpointBase
    {
        public Authorization(AuthToken token) : base("Authorization")
        {
            UpdateAuthToken(token);
        }

        public User User()
        {
            return UserAsync().Result;
        }
        public async Task<User> UserAsync()
        {
            JObject userJson = await GetJsonAsync("User");
            return userJson.ToObject<User>();
        }
    }
}
