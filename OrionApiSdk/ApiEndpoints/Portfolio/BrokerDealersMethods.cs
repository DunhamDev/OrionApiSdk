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

        public List<BrokerDealer> Get(int top = 500, int skip = 0)
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

        public BrokerDealer Get(int bdId)
        {
            return GetAsync(bdId).Result;
        }
        public async Task<BrokerDealer> GetAsync(int bdId)
        {
            JToken brokerDealer = await GetJsonAsync(bdId.ToString());
            return brokerDealer.ToObject<BrokerDealer>();
        }

        public List<BrokerDealerSimple> GetSimple(bool? hasValue = null)
        {
            return GetSimpleAsync().Result;
        }
        public async Task<List<BrokerDealerSimple>> GetSimpleAsync(bool? hasValue = null)
        {
            JToken brokerDealers = await GetJsonAsync("", new Dictionary<string, object>
            {
                { "hasValue", hasValue }
            });
            return brokerDealers.ToObject<List<BrokerDealerSimple>>();
        }

        public List<BrokerDealerSimple> GetSimpleSearch(string startsWith)
        {
            return GetSimpleSearchAsync(startsWith).Result;
        }
        public async Task<List<BrokerDealerSimple>> GetSimpleSearchAsync(string startsWith)
        {
            JToken dealers = await GetJsonAsync("Simple/Search", new Dictionary<string, object>
            {
                { "search", startsWith }
            });
            return dealers.ToObject<List<BrokerDealerSimple>>();
        }
    }
}
