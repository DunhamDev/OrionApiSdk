﻿using Newtonsoft.Json.Linq;
using OrionApiSdk.ApiEndpoints.Abstract;
using OrionApiSdk.ApiEndpoints.Portfolio.Interfaces;
using OrionApiSdk.Common.Extensions;
using OrionApiSdk.Objects;
using OrionApiSdk.Objects.Portfolio;
using OrionApiSdk.Objects.Portfolio.Enums;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Portfolio
{
    /// <summary>
    /// Acts as a container for all /Portfolio/Accounts methods
    /// </summary>
    public class AccountsMethods : ApiMethodContainerForVeboseObject<AccountVerbose>, IAccountsMethods
    {
        /// <summary>
        /// Constructs a /Portfolio/Accounts endpoint instance
        /// </summary>
        /// <param name="token">The access token of the user making requests</param>
        public AccountsMethods(AuthToken token) : base ("Portfolio", "Accounts", token) { }

        #region Get account
        /// <summary>
        /// HTTP GET: /Portfolio/Accounts
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
        /// HTTP GET: /Portfolio/Accounts
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
            JToken accounts = await GetJsonAsync("", new NameValueCollection
            {
                { "isActive", isActive.ToString() },
                { "isManager", isManager.ToString() },
                { "createdDateStart", createdDateStart.NullableDateToString() },
                { "newAccountFilter", newAccountFilter },
                { "clientId", clientId.ToString() },
                { "registrationId", registrationId.ToString() },
                { "asOfDate", asOfDate.NullableDateToString() },
                { "hasValue", hasValue.ToString() },
                { "$skip", skip.ToString() },
                { "$top", top.ToString() }
            });
            return accounts.ToObject<List<Account>>();
        }

        /// <summary>
        /// HTTP GET: /Portfolio/Accounts/{accountId}
        /// Get a specific account
        /// </summary>
        /// <param name="accountId">The ID of the account</param>
        /// <returns>The specific account</returns>
        public Account Get(int accountId)
        {
            return GetAsync(accountId).Result;
        }
        /// <summary>
        /// HTTP GET: /Portfolio/Accounts/{accountId}
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
        /// HTTP GET: /Portfolio/Accounts/{accountNumber}
        /// Get a specific account by account number
        /// </summary>
        /// <param name="accountNumber">The account number of the account</param>
        /// <returns>The specific account</returns>
        public Account Get(string accountNumber)
        {
            return GetAsync(accountNumber).Result;
        }
        /// <summary>
        /// HTTP GET: /Portfolio/Accounts/{accountNumber}
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
        /// HTTP GET: /Portfolio/Accounts/Simple
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
        /// HTTP GET: /Portfolio/Accounts/Simple
        /// Gets a simple list of accounts
        /// </summary>
        /// <param name="hasValue"></param>
        /// <param name="isActive"></param>
        /// <param name="top">Number of accounts to return</param>
        /// <param name="skip">Number of accounts to skip</param>
        /// <returns>A simple list of accounts</returns>
        public async Task<List<AccountSimple>> GetSimpleAsync(bool? hasValue = null, bool? isActive = null, int top = 5000, int skip = 0)
        {
            JToken simpleAccounts = await GetJsonAsync("Simple", new NameValueCollection
            {
                { "hasValue", hasValue.ToString() },
                { "isActive", isActive.ToString() },
                { "$top", top.ToString() },
                { "$skip", skip.ToString() }
            });
            return simpleAccounts.ToObject<List<AccountSimple>>();
        }

        public List<AccountVerbose> GetVerbose(bool? isActive = null, bool? isManager = null, int top = 5000, int skip = 0, params AccountPropertyExpand[] expand)
        {
            return GetVerboseAsync(isActive, isManager, top, skip).Result;
        }
        public async Task<List<AccountVerbose>> GetVerboseAsync(bool? isActive = null, bool? isManager = null, int top = 5000, int skip = 0, params AccountPropertyExpand[] expand)
        {
            var queryParams = new NameValueCollection
            {
                { "isActive", isActive.ToString() },
                { "isManager", isManager.ToString() },
                { "$top", top.ToString() },
                { "$skip", skip.ToString() }
            };
            foreach (var expandProperty in expand)
            {
                queryParams.Add("expand", ((int)expandProperty).ToString());
            }

            JToken accounts = await GetJsonAsync("Verbose", queryParams);
            return accounts.ToObject<List<AccountVerbose>>();
        }
        #endregion

        #region Search accounts
        /// <summary>
        /// HTTP GET: /Portfolio/Accounts/Simple/Search
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
        /// HTTP GET: /Portfolio/Accounts/Simple/Search
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
            JToken simpleAccounts = await GetJsonAsync("Simple", new NameValueCollection
            {
                { "search", searchedAccountNum },
                { "hasValue", hasValue.ToString() },
                { "isActive", isActive.ToString() },
                { "$top", top.ToString() },
                { "$skip", skip.ToString() }
            });
            return simpleAccounts.ToObject<List<AccountSimple>>();
        }

        /// <summary>
        /// HTTP GET: /Portfolio/Accounts/Search/Advanced
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
        /// HTTP GET: /Portfolio/Accounts/Search/Advanced
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
            JToken accounts = await GetJsonAsync("Search/Advanced", new NameValueCollection
            {
                { "assetId", assetId.ToString() },
                { "registrationTypeId", registrationTypeId.ToString() },
                { "lastName", lastName },
                { "firstName", firstName },
                { "accountNumber", accountNumber },
                { "secondaryAccountNumber", secondaryAccountNumber },
                { "outsideId", outsideId },
                { "registrationId", registrationId.ToString() },
                { "clientId", clientId.ToString() },
                { "accountId", accountId.ToString() }
            });
            return accounts.ToObject<List<Account>>();
        }
        #endregion

        #region Account value
        /// <summary>
        /// HTTP GET: /Portfolio/Accounts/Value
        /// Gets the value of all accounts the user has access to
        /// </summary>
        /// <param name="hasValue"></param>
        /// <returns>The list of accounts and their values</returns>
        public List<AccountSimple> GetValue(bool? hasValue = null)
        {
            return GetValueAsync(hasValue).Result;
        }
        /// <summary>
        /// HTTP GET: /Portfolio/Accounts/Value
        /// Gets the value of all accounts the user has access to
        /// </summary>
        /// <param name="hasValue"></param>
        /// <returns>The list of accounts and their values</returns>
        public async Task<List<AccountSimple>> GetValueAsync(bool? hasValue = null)
        {
            JToken accounts = await GetJsonAsync("Value", new NameValueCollection
            {
                { "hasValue", hasValue.ToString() }
            });
            return accounts.ToObject<List<AccountSimple>>();
        }

        /// <summary>
        /// HTTP GET: /Portfolio/Accounts/Value/{asOfDate}
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
        /// HTTP GET: /Portfolio/Accounts/Value/{asOfDate}
        /// Gets the value of all accounts the user has access to as of a specific date
        /// </summary>
        /// <param name="asOfDate">Specific date to check</param>
        /// <param name="hasValue"></param>
        /// <returns>The list of accounts and their values</returns>
        public async Task<List<AccountSimple>> GetValueAsync(DateTime asOfDate, bool? hasValue = null)
        {
            JToken accounts = await GetJsonAsync(string.Format("Value/{0:MM-dd-yyyy}", asOfDate), new NameValueCollection
            {
                { "hasValue", hasValue.ToString() }
            });
            return accounts.ToObject<List<AccountSimple>>();
        }

        /// <summary>
        /// HTTP GET: /Portfolio/Accounts/{accountId}/Value
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
        /// HTTP GET: /Portfolio/Accounts/{accountId}/Value
        /// Get the account value of a specific account
        /// </summary>
        /// <param name="accountId">The ID of the account</param>
        /// <param name="includeCash"></param>
        /// <returns>The value of the specified account</returns>
        public async Task<AccountSimple> GetValueAsync(int accountId, bool? includeCash = null)
        {
            JToken account = await GetJsonAsync(string.Format("{0}/Value", accountId), new NameValueCollection
            {
                { "includeCash", includeCash.ToString() }
            });
            return account.ToObject<AccountSimple>();
        }

        /// <summary>
        /// HTTP GET: /Portfolio/Accounts/{accountId}/Value/{asOfDate}
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
        /// HTTP GET: /Portfolio/Accounts/{accountId}/Value/{asOfDate}
        /// Get the account value of a specific account as of a specific date
        /// </summary>
        /// <param name="accountId">The ID of the account</param>
        /// <param name="asOfDate">Specific date to check</param>
        /// <param name="includeCash"></param>
        /// <returns>The value of the specified account</returns>
        public async Task<AccountSimple> GetValueAsync(int accountId, DateTime asOfDate, bool? includeCash = null)
        {
            JToken account = await GetJsonAsync(string.Format("{0}/Value/{1:MM-dd-yyyy}", accountId, asOfDate), new NameValueCollection
            {
                { "includeCash", includeCash.ToString() }
            });
            return account.ToObject<AccountSimple>();
        }
        #endregion

        /// <summary>
        /// HTTP GET: /Portfolio/Accounts/{accountId}/Assets
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
        /// HTTP GET: /Portfolio/Accounts/{accountId}/Assets
        /// Gets the list of assets associated with a specific account
        /// </summary>
        /// <param name="accountId">The account ID</param>
        /// <param name="includeCostBasis"></param>
        /// <returns>The list of assets for a specific account</returns>
        public async Task<List<Asset>> GetAssetsAsync(int accountId, bool? includeCostBasis = null)
        {
            JToken assets = await GetJsonAsync(string.Format("{0}/Assets", accountId), new NameValueCollection
            {
                { "includeCostBasis", includeCostBasis.ToString() }
            });
            return assets.ToObject<List<Asset>>();
        }
    }
}
