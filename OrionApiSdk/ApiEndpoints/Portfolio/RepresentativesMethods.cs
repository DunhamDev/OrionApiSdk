using Newtonsoft.Json.Linq;
using OrionApiSdk.ApiEndpoints.Abstract;
using OrionApiSdk.Objects;
using OrionApiSdk.Objects.Portfolio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Portfolio
{
    public class RepresentativesMethods : ApiMethodContainer<Representative>
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

        public List<RepresentativeSimple> GetSimple(bool? isUsed = null)
        {
            return GetSimpleAsync(isUsed).Result;
        }
        public async Task<List<RepresentativeSimple>> GetSimpleAsync(bool? isUsed = null)
        {
            JToken simpleReps = await GetJsonAsync("Simple", new Dictionary<string, object> {
                { "isUsed", isUsed },
            });
            return simpleReps.ToObject<List<RepresentativeSimple>>();
        }

        public List<RepresentativeSimple> SearchSimple(string search)
        {
            return SearchSimpleAsync(search).Result;
        }
        public async Task<List<RepresentativeSimple>> SearchSimpleAsync(string search)
        {
            JToken reps = await GetJsonAsync("Simple/Search", new Dictionary<string, object>
            {
                { "search", search }
            });
            return reps.ToObject<List<RepresentativeSimple>>();
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

        public List<RepresentativeSimple> GetValues(int top = 5000, int skip = 0)
        {
            return GetValuesAsync().Result;
        }
        public async Task<List<RepresentativeSimple>> GetValuesAsync(int top = 5000, int skip = 0)
        {
            JToken repValuesJson = await GetJsonAsync("Value", new Dictionary<string, object>
            {
                { "$top", top },
                { "$skip", skip }
            });
            return repValuesJson.ToObject<List<RepresentativeSimple>>();
        }

        public List<RepresentativeSimple> GetValues(DateTime asOfDate, int top = 5000, int skip = 0)
        {
            return GetValuesAsync(asOfDate, top, skip).Result;
        }
        public async Task<List<RepresentativeSimple>> GetValuesAsync(DateTime asOfDate, int top = 5000, int skip = 0)
        {
            JToken repValues = await GetJsonAsync(string.Format("Value/{0:MM-dd-yyyy}", asOfDate), new Dictionary<string, object>
            {
                { "$top", top },
                { "$skip", skip }
            });
            return repValues.ToObject<List<RepresentativeSimple>>();
        }

        public List<ClientSimple> SearchClients(int repId, string searchValue, int? top = null, int skip = 0)
        {
            return SearchClientsAsync(repId, searchValue, top, skip).Result;
        }
        public async Task<List<ClientSimple>> SearchClientsAsync(int repId, string searchValue, int? top = null, int skip = 0)
        {
            JToken clientsJson = await GetJsonAsync(string.Format("{0}/Clients/Simple/Search", repId), new Dictionary<string, object>
            {
                { "search", searchValue },
                { "top", top },
                { "skip", skip }
            });
            return clientsJson.ToObject<List<ClientSimple>>();
        }

        public List<RepresentativeVerbose> GetVerbose(bool? isActive = null, int top = 5000, int skip = 0)
        {
            return GetVerboseAsync(isActive, top, skip).Result;
        }
        public async Task<List<RepresentativeVerbose>> GetVerboseAsync(bool? isActive = null, int top = 5000, int skip = 0)
        {
            JToken verboseReps = await GetJsonAsync("Verbose", new Dictionary<string, object>
            {
                { "isActive", isActive },
                { "$top", top },
                { "$skip", skip }
            });
            return verboseReps.ToObject<List<RepresentativeVerbose>>();
        }

        public RepresentativeVerbose GetVerbose(int repId)
        {
            return GetVerboseAsync(repId).Result;
        }
        public async Task<RepresentativeVerbose> GetVerboseAsync(int repId)
        {
            JToken rep = await GetJsonAsync("Verbose/" + repId.ToString());
            return rep.ToObject<RepresentativeVerbose>();
        }
    }
}
