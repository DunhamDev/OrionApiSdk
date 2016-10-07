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

        public List<Representative> Get(bool? isUsed = null, int top = 5000, int skip = 0)
        {
            return GetAsync(isUsed, top, skip).Result;
        }
        public async Task<List<Representative>> GetAsync(bool? isUsed = null, int top = 5000, int skip = 0)
        {
            JToken reps = await GetJsonAsync("", new Dictionary<string, object> {
                { "isUsed", isUsed },
                { "$top", top },
                { "$skip", skip  }
            });
            return reps.ToObject<List<Representative>>();
        }

        public Representative Get(int repId)
        {
            return GetAsync(repId).Result;
        }
        public async Task<Representative> GetAsync(int repId)
        {
            JToken repJson = await GetJsonAsync(repId.ToString());
            return repJson.ToObject<Representative>();
        }

        public List<RepresentativeSimple> GetSimple(bool? isUsed = null, int top = 5000, int skip = 0)
        {
            return GetSimpleAsync(isUsed, top, skip).Result;
        }
        public async Task<List<RepresentativeSimple>> GetSimpleAsync(bool? isUsed = null, int top = 5000, int skip = 0)
        {
            JToken simpleReps = await GetJsonAsync("Simple", new Dictionary<string, object> {
                { "isUsed", isUsed },
                { "$top", top },
                { "$skip", skip }
            });
            return simpleReps.ToObject<List<RepresentativeSimple>>();
        }

        public List<Account> GetAccounts(int repId, int top = 5000, int skip = 0)
        {
            return GetAccountsAsync(repId, top, skip).Result;
        }
        public async Task<List<Account>> GetAccountsAsync(int repId, int top = 5000, int skip = 0)
        {
            JToken accounts = await GetJsonAsync(string.Format("{0}/Accounts", repId), new Dictionary<string, object>
            {
                { "$top", top },
                { "skip", skip }
            });
            return accounts.ToObject<List<Account>>();
        }

        public List<AccountSimple> GetAccountValues(int repId, int top = 5000, int skip = 0)
        {
            return GetAccountValuesAsync(repId, top, skip).Result;
        }
        public async Task<List<AccountSimple>> GetAccountValuesAsync(int repId, int top = 5000, int skip = 0)
        {
            JToken simpleAccountsJson = await GetJsonAsync(string.Format("{0}/Accounts/Value", repId), new Dictionary<string, object>
            {
                { "$top", top },
                { "$skip", skip }
            });
            return simpleAccountsJson.ToObject<List<AccountSimple>>();
        }

        public List<AccountSimple> GetAccountValues(int repId, DateTime asOfDate, int top = 5000, int skip = 0)
        {
            return GetAccountValuesAsync(repId, asOfDate, top, skip).Result;
        }
        public async Task<List<AccountSimple>> GetAccountValuesAsync(int repId, DateTime asOfDate, int top = 5000, int skip = 0)
        {
            JToken simpleAccountsJson = await GetJsonAsync(string.Format("{0}/Accounts/Value/{1:MM-dd-yyyy}", repId, asOfDate), new Dictionary<string, object>
            {
                { "$top", top },
                { "$skip", skip }
            });
            return simpleAccountsJson.ToObject<List<AccountSimple>>();
        }
    }
}
