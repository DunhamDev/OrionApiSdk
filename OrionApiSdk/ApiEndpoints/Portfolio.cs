using Newtonsoft.Json.Linq;
using OrionApiSdk.Objects;
using OrionApiSdk.Objects.Portfolio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints
{
    public class Portfolio : ApiEndpointBase
    {
        public Portfolio(AuthToken  token) : base("Portfolio", token.AccessToken)
        {
        }

        public List<Representative> GetRepresentatives()
        {
            return GetRepresentativesAsync().Result;
        }
        public async Task<List<Representative>> GetRepresentativesAsync()
        {
            JToken reps = await GetJsonAsync("Representatives");
            return reps.ToObject<List<Representative>>();
        }

        public List<RepresentativeSimple> GetRepresentativesSimple(bool isUsed = false)
        {
            return GetRepresentativesSimpleAsync(isUsed).Result;
        }
        public async Task<List<RepresentativeSimple>> GetRepresentativesSimpleAsync(bool isUsed = false)
        {
            JToken simpleReps = await GetJsonAsync("Representatives/Simple", new Dictionary<string, object> { { "isUsed", isUsed } });
            return simpleReps.ToObject<List<RepresentativeSimple>>();
        }
    }
}
