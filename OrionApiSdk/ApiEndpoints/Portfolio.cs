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
        public Portfolio(AuthToken token) : base("Portfolio", token.AccessToken)
        {
        }

        public List<Representative> GetRepresentatives(bool? isUsed = null, int? top = null, int? skip = null)
        {
            return GetRepresentativesAsync(isUsed, top, skip).Result;
        }
        public async Task<List<Representative>> GetRepresentativesAsync(bool? isUsed = null, int? top = null, int? skip = null)
        {
            JToken reps = await GetJsonAsync("Representatives", new Dictionary<string, object> {
                { "isUsed", isUsed },
                { "$top", top },
                { "$skip", skip  }
            });
            return reps.ToObject<List<Representative>>();
        }

        public Representative GetRepresentatives(int repId)
        {
            return GetRepresentativesAsync(repId).Result;
        }
        public async Task<Representative> GetRepresentativesAsync(int repId)
        {
            JToken repJson = await GetJsonAsync("Representatives/" + repId.ToString());
            return repJson.ToObject<Representative>();
        }

        public List<RepresentativeSimple> GetRepresentativesSimple(bool? isUsed = null, int? top = null, int? skip = null)
        {
            return GetRepresentativesSimpleAsync(isUsed, top, skip).Result;
        }
        public async Task<List<RepresentativeSimple>> GetRepresentativesSimpleAsync(bool? isUsed = null, int? top = null, int? skip = null)
        {
            JToken simpleReps = await GetJsonAsync("Representatives/Simple", new Dictionary<string, object> {
                { "isUsed", isUsed },
                { "$top", top },
                { "$skip", skip }
            });
            return simpleReps.ToObject<List<RepresentativeSimple>>();
        }
    }
}
