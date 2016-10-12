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
        /// <summary>
        /// Gets a list of accounts available to the user
        /// </summary>
        /// <param name="isActive"></param>
        /// <param name="isManager"></param>
        /// <param name="createdDateStart"></param>
        /// <param name="newAccountFilter"></param>
        /// <param name="clientId"></param>
        /// <param name="registrationId"></param>
        /// <param name="asOfDate"></param>
        /// <param name="hasValue">Filters accounts based on value</param>
        /// <param name="top">Number of records to return</param>
        /// <param name="skip">Number of records to skip</param>
        /// <returns>A list of accounts meeting all filter criteria</returns>
        public List<Account> Get(bool? isActive = null, bool? isManager = null, DateTime? createdDateStart = null, string newAccountFilter = null,
            int? clientId = null, int? registrationId = null, DateTime? asOfDate = null, bool? hasValue = null, int top = 5000, int skip = 0)
        {
            return GetAsync(isActive, isManager, createdDateStart, newAccountFilter, clientId, registrationId, asOfDate, hasValue, top, skip).Result;
        }
        /// <summary>
        /// Gets a list of accounts available to the user
        /// </summary>
        /// <param name="isActive"></param>
        /// <param name="isManager"></param>
        /// <param name="createdDateStart"></param>
        /// <param name="newAccountFilter"></param>
        /// <param name="clientId"></param>
        /// <param name="registrationId"></param>
        /// <param name="asOfDate"></param>
        /// <param name="hasValue">Filters accounts based on value</param>
        /// <param name="top">Number of records to return</param>
        /// <param name="skip">Number of records to skip</param>
        /// <returns>A list of accounts meeting all filter criteria</returns>
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

        /// <summary>
        /// Get a specific account
        /// </summary>
        /// <param name="accountId">The ID of the account</param>
        /// <returns>The specific account</returns>
        public Account Get(int accountId)
        {
            return GetAsync(accountId).Result;
        }
        /// <summary>
        /// Get a specific account
        /// </summary>
        /// <param name="accountId">The ID of the account</param>
        /// <returns>The specific account</returns>
        public async Task<Account> GetAsync(int accountId)
        {
            JToken account = await GetJsonAsync(accountId.ToString());
            return account.ToObject<Account>();
        }

        /// <summary>
        /// Get a specific account by account number
        /// </summary>
        /// <param name="accountNumber">The account number of the account</param>
        /// <returns>The specific account</returns>
        public Account Get(string accountNumber)
        {
            return GetAsync(accountNumber).Result;
        }
        /// <summary>
        /// Get a specific account by account number
        /// </summary>
        /// <param name="accountNumber">The account number of the account</param>
        /// <returns>The specific account</returns>
        public async Task<Account> GetAsync(string accountNumber)
        {
            JToken account = await GetJsonAsync(accountNumber);
            return account.ToObject<Account>();
        }

        /// <summary>
        /// Gets a simple list of accounts
        /// </summary>
        /// <param name="hasValue"></param>
        /// <param name="isActive"></param>
        /// <param name="top">Number of accounts to return</param>
        /// <param name="skip">Number of accounts to skip</param>
        /// <returns>A simple list of accounts</returns>
        public List<AccountSimple> GetSimple(bool? hasValue = null, bool? isActive = null, int top = 5000, int skip = 0)
        {
            return GetSimpleAsync(hasValue, isActive, top, skip).Result;
        }
        /// <summary>
        /// Gets a simple list of accounts
        /// </summary>
        /// <param name="hasValue"></param>
        /// <param name="isActive"></param>
        /// <param name="top">Number of accounts to return</param>
        /// <param name="skip">Number of accounts to skip</param>
        /// <returns>A simple list of accounts</returns>
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
        /// <summary>
        /// Performs a simple search on the accounts
        /// </summary>
        /// <param name="searchedAccountNum">Account Id, partial account number, or outside id to search for</param>
        /// <param name="hasValue"></param>
        /// <param name="isActive"></param>
        /// <param name="top">Number of records to return</param>
        /// <param name="skip">Number of records to skip</param>
        /// <returns>A list of simple accounts matching the search string</returns>
        public List<AccountSimple> GetSimpleSearch(string searchedAccountNum, bool? hasValue = null, bool? isActive = null, int top = 5000, int skip = 0)
        {
            return GetSimpleSearchAsync(searchedAccountNum, hasValue, isActive, top, skip).Result;
        }
        /// <summary>
        /// Performs a simple search on the accounts
        /// </summary>
        /// <param name="searchedAccountNum">Account Id, partial account number, or outside id to search for</param>
        /// <param name="hasValue"></param>
        /// <param name="isActive"></param>
        /// <param name="top">Number of records to return</param>
        /// <param name="skip">Number of records to skip</param>
        /// <returns>A list of simple accounts matching the search string</returns>
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

        /// <summary>
        /// Performs an advanced search of accounts the user has access to
        /// </summary>
        /// <param name="assetId"></param>
        /// <param name="registrationTypeId"></param>
        /// <param name="lastName"></param>
        /// <param name="firstName"></param>
        /// <param name="accountNumber"></param>
        /// <param name="secondaryAccountNumber"></param>
        /// <param name="outsideId"></param>
        /// <param name="registrationId"></param>
        /// <param name="clientId"></param>
        /// <param name="accountId"></param>
        /// <returns>The list of accounts matching the search paramteres</returns>
        public List<Account> GetAdvancedSearch(int? assetId = null, int? registrationTypeId = null, string lastName = null, string firstName = null,
            string accountNumber = null, string secondaryAccountNumber = null, string outsideId = null, int? registrationId = null, int? clientId = null, int? accountId = null)
        {
            return GetAdvancedSearchAsync(assetId, registrationTypeId, lastName, firstName, accountNumber, secondaryAccountNumber, outsideId, registrationId, clientId, accountId).Result;
        }
        /// <summary>
        /// Performs an advanced search of accounts the user has access to
        /// </summary>
        /// <param name="assetId"></param>
        /// <param name="registrationTypeId"></param>
        /// <param name="lastName"></param>
        /// <param name="firstName"></param>
        /// <param name="accountNumber"></param>
        /// <param name="secondaryAccountNumber"></param>
        /// <param name="outsideId"></param>
        /// <param name="registrationId"></param>
        /// <param name="clientId"></param>
        /// <param name="accountId"></param>
        /// <returns>The list of accounts matching the search paramteres</returns>
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
        /// <summary>
        /// Gets the value of all accounts the user has access to
        /// </summary>
        /// <param name="hasValue"></param>
        /// <returns>The list of accounts and their values</returns>
        public List<AccountSimple> GetValue(bool? hasValue = null)
        {
            return GetValueAsync(hasValue).Result;
        }
        /// <summary>
        /// Gets the value of all accounts the user has access to
        /// </summary>
        /// <param name="hasValue"></param>
        /// <returns>The list of accounts and their values</returns>
        public async Task<List<AccountSimple>> GetValueAsync(bool? hasValue = null)
        {
            JToken accounts = await GetJsonAsync("Value", new Dictionary<string, object>
            {
                { "hasValue", hasValue }
            });
            return accounts.ToObject<List<AccountSimple>>();
        }

        /// <summary>
        /// Gets the value of all accounts the user has access to as of a specific date
        /// </summary>
        /// <param name="asOfDate">Specific date to check</param>
        /// <param name="hasValue"></param>
        /// <returns>The list of accounts and their values</returns>
        public List<AccountSimple> GetValue(DateTime asOfDate, bool? hasValue = null)
        {
            return GetValueAsync(asOfDate, hasValue).Result;
        }
        /// <summary>
        /// Gets the value of all accounts the user has access to as of a specific date
        /// </summary>
        /// <param name="asOfDate">Specific date to check</param>
        /// <param name="hasValue"></param>
        /// <returns>The list of accounts and their values</returns>
        public async Task<List<AccountSimple>> GetValueAsync(DateTime asOfDate, bool? hasValue = null)
        {
            JToken accounts = await GetJsonAsync(string.Format("Value/{0:MM-dd-yyyy}", asOfDate), new Dictionary<string, object>
            {
                { "hasValue", hasValue }
            });
            return accounts.ToObject<List<AccountSimple>>();
        }

        /// <summary>
        /// Get the account value of a specific account
        /// </summary>
        /// <param name="accountId">The ID of the account</param>
        /// <param name="includeCash"></param>
        /// <returns>The value of the specified account</returns>
        public AccountSimple GetValue(int accountId, bool? includeCash = null)
        {
            return GetValueAsync(accountId, includeCash).Result;
        }
        /// <summary>
        /// Get the account value of a specific account
        /// </summary>
        /// <param name="accountId">The ID of the account</param>
        /// <param name="includeCash"></param>
        /// <returns>The value of the specified account</returns>
        public async Task<AccountSimple> GetValueAsync(int accountId, bool? includeCash = null)
        {
            JToken account = await GetJsonAsync(string.Format("{0}/Value", accountId), new Dictionary<string, object>
            {
                { "includeCash", includeCash }
            });
            return account.ToObject<AccountSimple>();
        }

        /// <summary>
        /// Get the account value of a specific account as of a specific date
        /// </summary>
        /// <param name="accountId">The ID of the account</param>
        /// <param name="asOfDate">Specific date to check</param>
        /// <param name="includeCash"></param>
        /// <returns>The value of the specified account</returns>
        public AccountSimple GetValue(int accountId, DateTime asOfDate, bool? includeCash = null)
        {
            return GetValueAsync(accountId, asOfDate, includeCash).Result;
        }
        /// <summary>
        /// Get the account value of a specific account as of a specific date
        /// </summary>
        /// <param name="accountId">The ID of the account</param>
        /// <param name="asOfDate">Specific date to check</param>
        /// <param name="includeCash"></param>
        /// <returns>The value of the specified account</returns>
        public async Task<AccountSimple> GetValueAsync(int accountId, DateTime asOfDate, bool? includeCash = null)
        {
            JToken account = await GetJsonAsync(string.Format("{0}/Value/{1:MM-dd-yyyy}", accountId, asOfDate), new Dictionary<string, object>
            {
                { "includeCash", includeCash }
            });
            return account.ToObject<AccountSimple>();
        }
        #endregion

        /// <summary>
        /// Gets the list of assets associated with a specific account
        /// </summary>
        /// <param name="accountId">The account ID</param>
        /// <param name="includeCostBasis"></param>
        /// <returns>The list of assets for a specific account</returns>
        public List<Asset> GetAssets(int accountId, bool? includeCostBasis = null)
        {
            return GetAssetsAsync(accountId, includeCostBasis).Result;
        }
        /// <summary>
        /// Gets the list of assets associated with a specific account
        /// </summary>
        /// <param name="accountId">The account ID</param>
        /// <param name="includeCostBasis"></param>
        /// <returns>The list of assets for a specific account</returns>
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
