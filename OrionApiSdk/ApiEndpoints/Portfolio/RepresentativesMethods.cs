using Newtonsoft.Json.Linq;
using OrionApiSdk.ApiEndpoints.Abstract;
using OrionApiSdk.ApiEndpoints.Portfolio.Interfaces;
using OrionApiSdk.Objects;
using OrionApiSdk.Objects.Portfolio;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Portfolio
{
    public class RepresentativesMethods : ApiMethodContainerForVeboseObject<RepresentativeVerbose>, IRepresentativesMethods
    {
        public RepresentativesMethods(AuthToken token) : base("Portfolio", "Representatives", token) { }

        #region Get representatives
        public List<Representative> Get(bool? isUsed = null, int top = 5000, int skip = 0)
        {
            return GetAsync(isUsed, top, skip).Result;
        }
        public async Task<List<Representative>> GetAsync(bool? isUsed = null, int top = 5000, int skip = 0)
        {
            JToken reps = await GetJsonAsync("", new NameValueCollection {
                { "isUsed", isUsed.ToString() },
                { "$top", top.ToString() },
                { "$skip", skip.ToString()  }
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
            JToken simpleReps = await GetJsonAsync("Simple", new NameValueCollection {
                { "isUsed", isUsed.ToString() },
            });
            return simpleReps.ToObject<List<RepresentativeSimple>>();
        }

        public List<RepresentativeSimple> SearchSimple(string search)
        {
            return SearchSimpleAsync(search).Result;
        }
        public async Task<List<RepresentativeSimple>> SearchSimpleAsync(string search)
        {
            JToken reps = await GetJsonAsync("Simple/Search", new NameValueCollection
            {
                { "search", search }
            });
            return reps.ToObject<List<RepresentativeSimple>>();
        }

        public List<RepresentativeVerbose> GetVerbose(bool? isActive = null, int top = 5000, int skip = 0)
        {
            return GetVerboseAsync(isActive, top, skip).Result;
        }
        public async Task<List<RepresentativeVerbose>> GetVerboseAsync(bool? isActive = null, int top = 5000, int skip = 0)
        {
            JToken verboseReps = await GetJsonAsync("Verbose", new NameValueCollection
            {
                { "isActive", isActive.ToString() },
                { "$top", top.ToString() },
                { "$skip", skip.ToString() }
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
        #endregion

        public List<Account> GetAccounts(int repId, int top = 5000, int skip = 0)
        {
            return GetAccountsAsync(repId, top, skip).Result;
        }
        public async Task<List<Account>> GetAccountsAsync(int repId, int top = 5000, int skip = 0)
        {
            JToken accounts = await GetJsonAsync(string.Format("{0}/Accounts", repId), new NameValueCollection
            {
                { "$top", top.ToString() },
                { "skip", skip.ToString() }
            });
            return accounts.ToObject<List<Account>>();
        }

        #region Get values
        public List<AccountSimple> GetAccountValues(int repId, int top = 5000, int skip = 0)
        {
            return GetAccountValuesAsync(repId, top, skip).Result;
        }
        public async Task<List<AccountSimple>> GetAccountValuesAsync(int repId, int top = 5000, int skip = 0)
        {
            JToken simpleAccountsJson = await GetJsonAsync(string.Format("{0}/Accounts/Value", repId), new NameValueCollection
            {
                { "$top", top.ToString() },
                { "$skip", skip.ToString() }
            });
            return simpleAccountsJson.ToObject<List<AccountSimple>>();
        }

        public List<AccountSimple> GetAccountValues(int repId, DateTime asOfDate, int top = 5000, int skip = 0)
        {
            return GetAccountValuesAsync(repId, asOfDate, top, skip).Result;
        }
        public async Task<List<AccountSimple>> GetAccountValuesAsync(int repId, DateTime asOfDate, int top = 5000, int skip = 0)
        {
            JToken simpleAccountsJson = await GetJsonAsync(string.Format("{0}/Accounts/Value/{1:MM-dd-yyyy}", repId, asOfDate), new NameValueCollection
            {
                { "$top", top.ToString() },
                { "$skip", skip.ToString() }
            });
            return simpleAccountsJson.ToObject<List<AccountSimple>>();
        }

        public List<RepresentativeSimple> GetValues(int top = 5000, int skip = 0)
        {
            return GetValuesAsync().Result;
        }
        public async Task<List<RepresentativeSimple>> GetValuesAsync(int top = 5000, int skip = 0)
        {
            JToken repValuesJson = await GetJsonAsync("Value", new NameValueCollection
            {
                { "$top", top.ToString() },
                { "$skip", skip.ToString() }
            });
            return repValuesJson.ToObject<List<RepresentativeSimple>>();
        }

        public List<RepresentativeSimple> GetValues(DateTime asOfDate, int top = 5000, int skip = 0)
        {
            return GetValuesAsync(asOfDate, top, skip).Result;
        }
        public async Task<List<RepresentativeSimple>> GetValuesAsync(DateTime asOfDate, int top = 5000, int skip = 0)
        {
            JToken repValues = await GetJsonAsync(string.Format("Value/{0:MM-dd-yyyy}", asOfDate), new NameValueCollection
            {
                { "$top", top.ToString() },
                { "$skip", skip.ToString() }
            });
            return repValues.ToObject<List<RepresentativeSimple>>();
        }
        #endregion

        public List<ClientSimple> SearchClients(int repId, string searchValue, int? top = null, int skip = 0)
        {
            return SearchClientsAsync(repId, searchValue, top, skip).Result;
        }
        public async Task<List<ClientSimple>> SearchClientsAsync(int repId, string searchValue, int? top = null, int skip = 0)
        {
            JToken clientsJson = await GetJsonAsync(string.Format("{0}/Clients/Simple/Search", repId), new NameValueCollection
            {
                { "search", searchValue },
                { "top", top.ToString() },
                { "skip", skip.ToString() }
            });
            return clientsJson.ToObject<List<ClientSimple>>();
        }

        #region Overrides
        /// <summary>
        /// HTTP POST: /Portfolio/Representatives/Verbose
        /// </summary>
        /// <param name="toCreate"></param>
        /// <returns></returns>
        public override RepresentativeVerbose Create(RepresentativeVerbose toCreate)
        {
            return base.Create(toCreate);
        }
        /// <summary>
        /// HTTP POST: /Portfolio/Representatives/Verbose
        /// </summary>
        /// <param name="toCreate"></param>
        /// <returns></returns>
        public override async Task<RepresentativeVerbose> CreateAsync(RepresentativeVerbose toCreate)
        {
            return await base.CreateAsync(toCreate);
        }

        /// <summary>
        /// HTTP PUT: /Portfolio/Representative/Verbose/{repId}
        /// </summary>
        /// <param name="toUpdate"></param>
        /// <returns></returns>
        public override RepresentativeVerbose Update(RepresentativeVerbose toUpdate)
        {
            return base.Update(toUpdate);
        }
        /// <summary>
        /// HTTP PUT: /Portfolio/Representative/Verbose/{repId}
        /// </summary>
        /// <param name="toUpdate"></param>
        /// <returns></returns>
        public override async Task<RepresentativeVerbose> UpdateAsync(RepresentativeVerbose toUpdate)
        {
            return await base.UpdateAsync(toUpdate);
        }
        #endregion
    }
}
