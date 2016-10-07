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
    public class AccountsMethods : ApiMethodContainer
    {
        public AccountsMethods(AuthToken token) : base ("Portfolio", "Accounts", token) { }

        public List<Account> Get(bool? isActive = null, bool? isManager = null, DateTime? createdDateStart = null, string newAccountFilter = null,
            int? clientId = null, int? registrationId = null, DateTime? asOfDate = null, bool? hasValue = null, int top = 5000, int skip = 0)
        {
            return GetAsync(isActive, isManager, createdDateStart, newAccountFilter, clientId, registrationId, asOfDate, hasValue).Result;
        }
        public async Task<List<Account>> GetAsync(bool? isActive = null, bool? isManager = null, DateTime? createdDateStart = null, string newAccountFilter = null,
            int? clientId = null, int? registrationId = null, DateTime? asOfDate = null, bool? hasValue = null, int top = 5000, int skip = 0)
        {
            JToken accounts = await GetJsonAsync("", new Dictionary<string, object>
            {
                { "isActive", isActive },
                { "isManager", isManager },
                { "createdDateStart", NullableDateToString(createdDateStart) },
                { "newAccountFilter", newAccountFilter },
                { "clientId", clientId },
                { "registrationId", registrationId },
                { "asOfDate", NullableDateToString(asOfDate) },
                { "hasValue", hasValue },
                { "$skip", skip },
                { "$top", top }
            });
            return accounts.ToObject<List<Account>>();
        }

        public Account Get(int accountId)
        {
            return GetAsync(accountId).Result;
        }
        public async Task<Account> GetAsync(int accountId)
        {
            JToken account = await GetJsonAsync(accountId.ToString());
            return account.ToObject<Account>();
        }

        private string NullableDateToString(DateTime? dateToConvert)
        {
            if (dateToConvert.HasValue)
            {
                return dateToConvert.Value.ToString("MM-dd-yyyy");
            }
            return null;
        }
    }
}
