using Newtonsoft.Json.Linq;
using OrionApiSdk.Common.ExtensionMethods;
using OrionApiSdk.Objects;
using OrionApiSdk.Objects.Portfolio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Portfolio
{
    /// <summary>
    /// Acts as a container for all /Portfolio/Accounts methods
    /// </summary>
    public class AccountsMethods : ApiMethodContainer
    {
        /// <summary>
        /// Constructs a /Portfolio/Accounts endpoint instance
        /// </summary>
        /// <param name="token">The access token of the user making requests</param>
        public AccountsMethods(AuthToken token) : base ("Portfolio", "Accounts", token) { }

        #region Get account
        public List<Account> Get(bool? isActive = null, bool? isManager = null, DateTime? createdDateStart = null, string newAccountFilter = null,
            int? clientId = null, int? registrationId = null, DateTime? asOfDate = null, bool? hasValue = null, int top = 5000, int skip = 0)
        {
            return GetAsync(isActive, isManager, createdDateStart, newAccountFilter, clientId, registrationId, asOfDate, hasValue, top, skip).Result;
        }
        public async Task<List<Account>> GetAsync(bool? isActive = null, bool? isManager = null, DateTime? createdDateStart = null, string newAccountFilter = null,
            int? clientId = null, int? registrationId = null, DateTime? asOfDate = null, bool? hasValue = null, int top = 5000, int skip = 0)
        {
            JToken accounts = await GetJsonAsync("", new Dictionary<string, object>
            {
                { "isActive", isActive },
                { "isManager", isManager },
                { "createdDateStart", createdDateStart.NullableDateToString() },
                { "newAccountFilter", newAccountFilter },
                { "clientId", clientId },
                { "registrationId", registrationId },
                { "asOfDate", asOfDate.NullableDateToString() },
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

        public Account Get(string accountNumber)
        {
            return GetAsync(accountNumber).Result;
        }
        public async Task<Account> GetAsync(string accountNumber)
        {
            JToken account = await GetJsonAsync(accountNumber);
            return account.ToObject<Account>();
        }

        public List<AccountSimple> GetSimple(bool? hasValue = null, bool? isActive = null, int top = 5000, int skip = 0)
        {
            return GetSimpleAsync(hasValue, isActive, top, skip).Result;
        }
        public async Task<List<AccountSimple>> GetSimpleAsync(bool? hasValue = null, bool? isActive = null, int top = 5000, int skip = 0)
        {
            JToken simpleAccounts = await GetJsonAsync("Simple", new Dictionary<string, object>
            {
                { "hasValue", hasValue },
                { "isActive", isActive },
                { "$top", top },
                { "$skip", skip }
            });
            return simpleAccounts.ToObject<List<AccountSimple>>();
        }
        #endregion

        #region Search accounts
        public List<AccountSimple> GetSimpleSearch(string searchedAccountNum, bool? hasValue = null, bool? isActive = null, int top = 5000, int skip = 0)
        {
            return GetSimpleSearchAsync(searchedAccountNum, hasValue, isActive, top, skip).Result;
        }
        public async Task<List<AccountSimple>> GetSimpleSearchAsync(string searchedAccountNum, bool? hasValue = null, bool? isActive = null, int top = 5000, int skip = 0)
        {
            JToken simpleAccounts = await GetJsonAsync("Simple", new Dictionary<string, object>
            {
                { "search", searchedAccountNum },
                { "hasValue", hasValue },
                { "isActive", isActive },
                { "$top", top },
                { "$skip", skip }
            });
            return simpleAccounts.ToObject<List<AccountSimple>>();
        }

        public List<Account> GetAdvancedSearch(int? assetId = null, int? registrationTypeId = null, string lastName = null, string firstName = null,
            string accountNumber = null, string secondaryAccountNumber = null, string outsideId = null, int? registrationId = null, int? clientId = null, int? accountId = null)
        {
            return GetAdvancedSearchAsync(assetId, registrationTypeId, lastName, firstName, accountNumber, secondaryAccountNumber, outsideId, registrationId, clientId, accountId).Result;
        }
        public async Task<List<Account>> GetAdvancedSearchAsync(int? assetId = null, int? registrationTypeId = null, string lastName = null, string firstName = null,
            string accountNumber = null, string secondaryAccountNumber = null, string outsideId = null, int? registrationId = null, int? clientId = null, int? accountId = null)
        {
            JToken accounts = await GetJsonAsync("Search/Advanced", new Dictionary<string, object>
            {
                { "assetId", assetId },
                { "registrationTypeId", registrationTypeId },
                { "lastName", lastName },
                { "firstName", firstName },
                { "accountNumber", accountNumber },
                { "secondaryAccountNumber", secondaryAccountNumber },
                { "outsideId", outsideId },
                { "registrationId", registrationId },
                { "clientId", clientId },
                { "accountId", accountId }
            });
            return accounts.ToObject<List<Account>>();
        }
        #endregion

        #region Account value
        public List<AccountSimple> GetValue(bool? hasValue = null)
        {
            return GetValueAsync(hasValue).Result;
        }
        public async Task<List<AccountSimple>> GetValueAsync(bool? hasValue = null)
        {
            JToken accounts = await GetJsonAsync("Value", new Dictionary<string, object>
            {
                { "hasValue", hasValue }
            });
            return accounts.ToObject<List<AccountSimple>>();
        }

        public List<AccountSimple> GetValue(DateTime asOfDate, bool? hasValue = null)
        {
            return GetValueAsync(asOfDate, hasValue).Result;
        }
        public async Task<List<AccountSimple>> GetValueAsync(DateTime asOfDate, bool? hasValue = null)
        {
            JToken accounts = await GetJsonAsync(string.Format("Value/{0:MM-dd-yyyy}", asOfDate), new Dictionary<string, object>
            {
                { "hasValue", hasValue }
            });
            return accounts.ToObject<List<AccountSimple>>();
        }

        public AccountSimple GetValue(int accountId, bool? includeCash = null)
        {
            return GetValueAsync(accountId, includeCash).Result;
        }
        public async Task<AccountSimple> GetValueAsync(int accountId, bool? includeCash = null)
        {
            JToken account = await GetJsonAsync(string.Format("{0}/Value", accountId), new Dictionary<string, object>
            {
                { "includeCash", includeCash }
            });
            return account.ToObject<AccountSimple>();
        }

        public AccountSimple GetValue(int accountId, DateTime asOfDate, bool? includeCash = null)
        {
            return GetValueAsync(accountId, asOfDate, includeCash).Result;
        }
        public async Task<AccountSimple> GetValueAsync(int accountId, DateTime asOfDate, bool? includeCash = null)
        {
            JToken account = await GetJsonAsync(string.Format("{0}/Value/{1:MM-dd-yyyy}", accountId, asOfDate), new Dictionary<string, object>
            {
                { "includeCash", includeCash }
            });
            return account.ToObject<AccountSimple>();
        }
        #endregion

        public List<Asset> GetAssets(int accountId, bool? includeCostBasis = null)
        {
            return GetAssetsAsync(accountId, includeCostBasis).Result;
        }
        public async Task<List<Asset>> GetAssetsAsync(int accountId, bool? includeCostBasis = null)
        {
            JToken assets = await GetJsonAsync(string.Format("{0}/Assets", accountId), new Dictionary<string, object>
            {
                { "includeCostBasis", includeCostBasis }
            });
            return assets.ToObject<List<Asset>>();
        }
    }
}
