using Newtonsoft.Json.Linq;
using OrionApiSdk.Objects;
using OrionApiSdk.Objects.Portfolio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Portfolio
{
    public class RepresentativesMethods : ApiMethodContainer
    {
        public RepresentativesMethods(AuthToken token) : base("Portfolio", "Representatives", token) { }

        public List<Representative> Get(bool? isUsed = null, int? top = null, int? skip = null)
        {
            return GetAsync(isUsed, top, skip).Result;
        }
        public async Task<List<Representative>> GetAsync(bool? isUsed = null, int? top = null, int? skip = null)
        {
            JToken reps = await GetJsonAsync("Representatives", new Dictionary<string, object> {
                { "isUsed", isUsed },
                { "$top", top },
                { "$skip", skip  }
            });
            return reps.ToObject<List<Representative>>();
        }
    }
}
