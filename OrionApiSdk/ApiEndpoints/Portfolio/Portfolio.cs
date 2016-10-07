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
    public class PortfolioEndpoint : ApiEndpointBase
    {
        public PortfolioEndpoint(AuthToken token) : base("Portfolio", token)
        {
        }

        private RepresentativesMethods _repMethods;
        public RepresentativesMethods Representatives
        {
            get
            {
                return _repMethods ?? (_repMethods = new RepresentativesMethods(AuthToken));
            }
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

        public List<Account> GetRepresentativeAccounts(int repId, int? top = null, int? skip = null)
        {
            return GetRepresentativeAccountsAsync(repId, top, skip).Result;
        }
        public async Task<List<Account>> GetRepresentativeAccountsAsync(int repId, int? top = null, int? skip = null)
        {
            JToken accounts = await GetJsonAsync(string.Format("Representatives/{0}/Accounts", repId), new Dictionary<string, object>
            {
                { "$top", top },
                { "skip", skip }
            });
            return accounts.ToObject<List<Account>>();
        }

        public List<AccountSimple> GetRepresentativeAccountValues(int repId, int? top = null, int? skip = null)
        {
            return GetRepresentativeAccountValuesAsync(repId, top, skip).Result;
        }
        public async Task<List<AccountSimple>> GetRepresentativeAccountValuesAsync(int repId, int? top = null, int? skip = null)
        {
            JToken simpleAccountsJson = await GetJsonAsync(string.Format("Representatives/{0}/Accounts/Value", repId), new Dictionary<string, object>
            {
                { "$top", top },
                { "$skip", skip }
            });
            return simpleAccountsJson.ToObject<List<AccountSimple>>();
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
