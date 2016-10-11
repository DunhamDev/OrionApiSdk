using Newtonsoft.Json.Linq;
using OrionApiSdk.Objects;
using OrionApiSdk.Objects.Portfolio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Portfolio
{
    public class BrokerDealersMethods : ApiMethodContainer
    {
        public BrokerDealersMethods(AuthToken token) : base("Portfolio", "BrokerDealers", token) { }

        public List<BrokerDealer> Get(int top = 500, int skip = 1)
        {
            return GetAsync(top, skip).Result;
        }
        public async Task<List<BrokerDealer>> GetAsync(int top = 500, int skip = 0)
        {
            JToken dealers = await GetJsonAsync("", new Dictionary<string, object>
            {
                { "$top", top },
                { "$skip", skip }
            });
            return dealers.ToObject<List<BrokerDealer>>();
        }


    }
}
