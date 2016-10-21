using Newtonsoft.Json.Linq;
using OrionApiSdk.ApiEndpoints.Abstract;
using OrionApiSdk.Common.ExtensionMethods;
using OrionApiSdk.Objects;
using OrionApiSdk.Objects.Portfolio;
using OrionApiSdk.Objects.Reporting.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Portfolio
{
    public class ClientsMethods : ApiMethodContainer<Client>
    {
        /// <summary>
        /// Constructs a /Portfolio/Clients endpoint instance
        /// </summary>
        /// <param name="token">The access token of the user making requests</param>
        public ClientsMethods(AuthToken token) : base("Portfolio", "Clients", token) { }

        #region Get clients
        /// <summary>
        /// HTTP GET: /Portfolio/Clients
        /// Gets a list of clients available to the user
        /// </summary>
        /// <param name="hasValue"></param>
        /// <param name="isActive"></param>
        /// <param name="representativeId"></param>
        /// <param name="registrationId"></param>
        /// <param name="top">The number of records to return</param>
        /// <param name="skip">The number of records to skip</param>
        /// <returns>The list of clients matching the filter criteria</returns>
        public List<Client> Get(bool? hasValue = null, bool? isActive = null, int? representativeId = null, string registrationId = null, int top = 5000, int skip = 0)
        {
            return GetAsync(hasValue, isActive, representativeId, registrationId, top, skip).Result;
        }
        /// <summary>
        /// HTTP GET: /Portfolio/Clients
        /// Gets a list of clients available to the user
        /// </summary>
        /// <param name="hasValue"></param>
        /// <param name="isActive"></param>
        /// <param name="representativeId"></param>
        /// <param name="registrationId"></param>
        /// <param name="top">The number of records to return</param>
        /// <param name="skip">The number of records to skip</param>
        /// <returns>The list of clients matching the filter criteria</returns>
        public async Task<List<Client>> GetAsync(bool? hasValue = null, bool? isActive = null, int? representativeId = null, string registrationId = null, int top = 5000, int skip = 0)
        {
            JToken clients = await GetJsonAsync("", new Dictionary<string, object>
            {
                { "hasValue", hasValue },
                { "isActive", isActive },
                { "representativeId", representativeId },
                { "registrationId", registrationId },
                { "$top", top },
                { "$skip", skip }
            });
            return clients.ToObject<List<Client>>();
        }

        /// <summary>
        /// HTTP GET: /Portfolio/Clients/{clientId}
        /// Gets a specific client
        /// </summary>
        /// <param name="clientId">The ID of the client</param>
        /// <returns>The specified client</returns>
        public Client Get(int clientId)
        {
            return GetAsync(clientId).Result;
        }
        /// <summary>
        /// HTTP GET: /Portfolio/Clients/{clientId}
        /// Gets a specific client
        /// </summary>
        /// <param name="clientId">The ID of the client</param>
        /// <returns>The specified client</returns>
        public async Task<Client> GetAsync(int clientId)
        {
            JToken client = await GetJsonAsync(clientId.ToString());
            return client.ToObject<Client>();
        }

        /// <summary>
        /// HTTP GET: /Portfolio/Clients/Simple
        /// Gets a simple list of clients available to the user
        /// </summary>
        /// <param name="hasValue"></param>
        /// <param name="top">The number of records to return</param>
        /// <param name="skip">The number of records to skip</param>
        /// <returns>The simple list of clients matching the filter criteria</returns>
        public List<ClientSimple> GetSimple(bool? hasValue = null, int top = 5000, int skip = 0)
        {
            return GetSimpleAsync(hasValue, top, skip).Result;
        }
        /// <summary>
        /// HTTP GET: /Portfolio/Clients/Simple
        /// Gets a simple list of clients available to the user
        /// </summary>
        /// <param name="hasValue"></param>
        /// <param name="top">The number of records to return</param>
        /// <param name="skip">The number of records to skip</param>
        /// <returns>The simple list of clients matching the filter criteria</returns>
        public async Task<List<ClientSimple>> GetSimpleAsync(bool? hasValue = null, int top = 5000, int skip = 0)
        {
            JToken simpleClients = await GetJsonAsync("Simple", new Dictionary<string, object>
            {
                { "hasValue", hasValue },
                { "$skip", skip },
                { "$top", top }
            });
            return simpleClients.ToObject<List<ClientSimple>>();
        }

        /// <summary>
        /// HTTP GET: /Portfolio/Clients/{clientId}/Simple
        /// Gets a simple version of a specific client
        /// </summary>
        /// <param name="clientId">The ID of the client</param>
        /// <returns>The simple specified client</returns>
        public ClientSimple GetSimple(int clientId)
        {
            return GetSimpleAsync(clientId).Result;
        }
        /// <summary>
        /// HTTP GET: /Portfolio/Clients/{clientId}/Simple
        /// Gets a simple version of a specific client
        /// </summary>
        /// <param name="clientId">The ID of the client</param>
        /// <returns>The simple specified client</returns>
        public async Task<ClientSimple> GetSimpleAsync(int clientId)
        {
            JToken client = await GetJsonAsync(string.Format("{0}/Simple", clientId));
            return client.ToObject<ClientSimple>();
        }
        #endregion

        #region Client values
        /// <summary>
        /// HTTP GET: /Portfolio/Clients/Value
        /// Gets the list of clients and their values
        /// </summary>
        /// <param name="hasValue"></param>
        /// <param name="resetCache"></param>
        /// <param name="includeCash"></param>
        /// <param name="top">The number of records to return</param>
        /// <param name="skip">The number of records to skip</param>
        /// <returns>The list of clients and their values</returns>
        public List<ClientSimple> GetValues(bool? hasValue = null, bool? resetCache = null, bool? includeCash = null, int top = 5000, int skip = 0)
        {
            return GetValuesAsync(hasValue, resetCache, includeCash, top, skip).Result;
        }
        /// <summary>
        /// HTTP GET: /Portfolio/Clients/Value
        /// Gets the list of clients and their values
        /// </summary>
        /// <param name="hasValue"></param>
        /// <param name="resetCache"></param>
        /// <param name="includeCash"></param>
        /// <param name="top">The number of records to return</param>
        /// <param name="skip">The number of records to skip</param>
        /// <returns>The list of clients and their values</returns>
        public async Task<List<ClientSimple>> GetValuesAsync(bool? hasValue = null, bool? resetCache = null, bool? includeCash = null, int top = 5000, int skip = 0)
        {
            JToken clients = await GetJsonAsync("Values", new Dictionary<string, object>
            {
                { "hasValue", hasValue },
                { "resetCache", resetCache },
                { "includeCash", includeCash },
                { "$skip", skip },
                { "$top", top }
            });
            return clients.ToObject<List<ClientSimple>>();
        }

        /// <summary>
        /// HTTP GET: /Portfolio/Clients/Value/{asOfDate}
        /// Gets the list of clients and their values as of a specific date
        /// </summary>
        /// <param name="asOfDate">The specific date</param>
        /// <param name="hasValue"></param>
        /// <param name="resetCache"></param>
        /// <param name="includeCash"></param>
        /// <param name="top">The number of records to return</param>
        /// <param name="skip">The number of records to skip</param>
        /// <returns>The list of clients and their values</returns>
        public List<ClientSimple> GetValues(DateTime asOfDate, bool? hasValue = null, bool? resetCache = null, bool? includeCash = null, int top = 5000, int skip = 0)
        {
            return GetValuesAsync(asOfDate, hasValue, resetCache, includeCash, top, skip).Result;
        }
        /// <summary>
        /// HTTP GET: /Portfolio/Clients/Value/{asOfDate}
        /// Gets the list of clients and their values as of a specific date
        /// </summary>
        /// <param name="asOfDate">The specific date</param>
        /// <param name="hasValue"></param>
        /// <param name="resetCache"></param>
        /// <param name="includeCash"></param>
        /// <param name="top">The number of records to return</param>
        /// <param name="skip">The number of records to skip</param>
        /// <returns>The list of clients and their values</returns>
        public async Task<List<ClientSimple>> GetValuesAsync(DateTime asOfDate, bool? hasValue = null, bool? resetCache = null, bool? includeCash = null, int top = 5000, int skip = 0)
        {
            JToken clients = await GetJsonAsync(string.Format("Values/{0:MM-dd-yyyy}", asOfDate), new Dictionary<string, object>
            {
                { "hasValue", hasValue },
                { "resetCache", resetCache },
                { "includeCash", includeCash },
                { "$skip", skip },
                { "$top", top }
            });
            return clients.ToObject<List<ClientSimple>>();
        }

        /// <summary>
        /// HTTP GET: /Portfolio/Clients/{clientId}/Value
        /// Gets a specific client's value
        /// </summary>
        /// <param name="clientId">The ID of the client</param>
        /// <param name="includeCash"></param>
        /// <returns>The specific client's value</returns>
        public ClientSimple GetValue(int clientId, bool? includeCash = null)
        {
            return GetValueAsync(clientId, includeCash).Result;
        }
        /// <summary>
        /// HTTP GET: /Portfolio/Clients/{clientId}/Value
        /// Gets a specific client's value
        /// </summary>
        /// <param name="clientId">The ID of the client</param>
        /// <param name="includeCash"></param>
        /// <returns>The specific client's value</returns>
        public async Task<ClientSimple> GetValueAsync(int clientId, bool? includeCash = null)
        {
            JToken client = await GetJsonAsync(string.Format("{0}/Value", clientId), new Dictionary<string, object>
            {
                { "includeCash", includeCash }
            });
            return client.ToObject<ClientSimple>();
        }

        /// <summary>
        /// HTTP GET: /Portfolio/Clients/{clientId}/Value/{asOfDate}
        /// Gets a specific client's value as of a specific date
        /// </summary>
        /// <param name="clientId">The ID of the client</param>
        /// <param name="asOfDate">The specific date</param>
        /// <param name="includeCash"></param>
        /// <returns>The specific client's value</returns>
        public ClientSimple GetValue(int clientId, DateTime asOfDate, bool? includeCash = null)
        {
            return GetValueAsync(clientId, asOfDate, includeCash).Result;
        }
        /// <summary>
        /// HTTP GET: /Portfolio/Clients/{clientId}/Value/{asOfDate}
        /// Gets a specific client's value as of a specific date
        /// </summary>
        /// <param name="clientId">The ID of the client</param>
        /// <param name="asOfDate">The specific date</param>
        /// <param name="includeCash"></param>
        /// <returns>The specific client's value</returns>
        public async Task<ClientSimple> GetValueAsync(int clientId, DateTime asOfDate, bool? includeCash = null)
        {
            JToken client = await GetJsonAsync(string.Format("{0}/Value/{1:MM-dd-yyyy}", clientId, asOfDate), new Dictionary<string, object>
            {
                { "includeCash", includeCash }
            });
            return client.ToObject<ClientSimple>();
        }
        #endregion

        #region Client accounts
        /// <summary>
        /// HTTP GET: /Portfolio/Clients/{clientId}/Accounts
        /// Gets the list of accounts for a specific client
        /// </summary>
        /// <param name="clientId">The ID of the client</param>
        /// <param name="isActive"></param>
        /// <returns>The list of client's accounts</returns>
        public List<Account> GetAccounts(int clientId, bool? isActive = null)
        {
            return GetAccountsAsync(clientId, isActive).Result;
        }
        /// <summary>
        /// HTTP GET: /Portfolio/Clients/{clientId}/Accounts
        /// Gets the list of accounts for a specific client
        /// </summary>
        /// <param name="clientId">The ID of the client</param>
        /// <param name="isActive"></param>
        /// <returns>The list of client's accounts</returns>
        public async Task<List<Account>> GetAccountsAsync(int clientId, bool? isActive = null)
        {
            JToken accounts = await GetJsonAsync(string.Format("{0}/Accounts", clientId), new Dictionary<string, object>
            {
                { "isActive", isActive }
            });
            return accounts.ToObject<List<Account>>();
        }

        /// <summary>
        /// HTTP GET: /Portfolio/Clients/{clientId}/AdditionalAccounts
        /// Gets the additional accounts for a specific client
        /// </summary>
        /// <param name="clientId">The ID of the client</param>
        /// <returns>The list of client's additional accounts</returns>
        public List<Account> GetAdditionalAccounts(int clientId)
        {
            return GetAdditionalAccountsAsync(clientId).Result;
        }
        /// <summary>
        /// HTTP GET: /Portfolio/Clients/{clientId}/AdditionalAccounts
        /// Gets the additional accounts for a specific client
        /// </summary>
        /// <param name="clientId">The ID of the client</param>
        /// <returns>The list of client's additional accounts</returns>
        public async Task<List<Account>> GetAdditionalAccountsAsync(int clientId)
        {
            JToken accounts = await GetJsonAsync(string.Format("{0}/AdditionalAccounts", clientId));
            return accounts.ToObject<List<Account>>();
        }

        /// <summary>
        /// HTTP GET: /Portfolio/Clients/{clientId}/Accounts/Value
        /// Gets the values of the accounts for a specific client
        /// </summary>
        /// <param name="clientId">The ID of the client</param>
        /// <param name="hasValue"></param>
        /// <returns>The list of account values for the client</returns>
        public List<AccountSimple> GetAccountValues(int clientId, bool? hasValue = null)
        {
            return GetAccountValuesAsync(clientId, hasValue).Result;
        }
        /// <summary>
        /// HTTP GET: /Portfolio/Clients/{clientId}/Accounts/Value
        /// Gets the values of the accounts for a specific client
        /// </summary>
        /// <param name="clientId">The ID of the client</param>
        /// <param name="hasValue"></param>
        /// <returns>The list of account values for the client</returns>
        public async Task<List<AccountSimple>> GetAccountValuesAsync(int clientId, bool? hasValue = null)
        {
            JToken accountValues = await GetJsonAsync(string.Format("{0}/Accounts/Value", clientId), new Dictionary<string, object>
            {
                { "hasValue", hasValue }
            });
            return accountValues.ToObject<List<AccountSimple>>();
        }

        /// <summary>
        /// HTTP GET: /Portfolio/Clients/{clientId}/Accounts/Value/{asOfDate}
        /// Gets the values of the accounts for a specific client as of a specific date
        /// </summary>
        /// <param name="clientId">The ID of the client</param>
        /// <param name="asOfDate">The specific date</param>
        /// <param name="hasValue"></param>
        /// <returns>The list of account values for the client</returns>
        public List<AccountSimple> GetAccountValues(int clientId, DateTime asOfDate, bool? hasValue = null)
        {
            return GetAccountValuesAsync(clientId, asOfDate, hasValue).Result;
        }
        /// <summary>
        /// HTTP GET: /Portfolio/Clients/{clientId}/Accounts/Value/{asOfDate}
        /// Gets the values of the accounts for a specific client as of a specific date
        /// </summary>
        /// <param name="clientId">The ID of the client</param>
        /// <param name="asOfDate">The specific date</param>
        /// <param name="hasValue"></param>
        /// <returns>The list of account values for the client</returns>
        public async Task<List<AccountSimple>> GetAccountValuesAsync(int clientId, DateTime asOfDate, bool? hasValue = null)
        {
            JToken accountValues = await GetJsonAsync(string.Format("{0}/Accounts/Value/{1:MM-dd-yyyy}", clientId, asOfDate), new Dictionary<string, object>
            {
                { "hasValue", hasValue }
            });
            return accountValues.ToObject<List<AccountSimple>>();
        }
        #endregion

        #region Search clients
        /// <summary>
        /// HTTP GET: /Portfolio/Clients/Simple/Search
        /// Gets a simple list of client names whose first name, last name, or entity name begin
        /// with the provided search term
        /// </summary>
        /// <param name="search">The partial name to search for</param>
        /// <param name="top">The number of records to return</param>
        /// <param name="skip">The number of records to skip</param>
        /// <param name="hasValue"></param>
        /// <param name="isActive"></param>
        /// <returns>The simple list of clients matching the search</returns>
        public List<ClientSimple> GetSimpleSearch(string search, int top = 5000, int skip = 0, bool? hasValue = null, bool? isActive = null)
        {
            return GetSimpleSearchAsync(search, top, skip, hasValue, isActive).Result;
        }
        /// <summary>
        /// HTTP GET: /Portfolio/Clients/Simple/Search
        /// Gets a simple list of client names whose first name, last name, or entity name begin
        /// with the provided search term
        /// </summary>
        /// <param name="search">The partial name to search for</param>
        /// <param name="top">The number of records to return</param>
        /// <param name="skip">The number of records to skip</param>
        /// <param name="hasValue"></param>
        /// <param name="isActive"></param>
        /// <returns>The simple list of clients matching the search</returns>
        public async Task<List<ClientSimple>> GetSimpleSearchAsync(string search, int top = 5000, int skip = 0, bool? hasValue = null, bool? isActive = null)
        {
            JToken searchedClients = await GetJsonAsync("Simple/Search", new Dictionary<string, object>
            {
                { "search", search },
                { "top", top },
                { "skip", skip },
                { "hasValue", hasValue },
                { "isActive", isActive }
            });
            return searchedClients.ToObject<List<ClientSimple>>();
        }

        /// <summary>
        /// HTTP GET: /Portfolio/Clients/Simple/Search/LastName
        /// Gets a list of clients whose last name begins with the provided search term
        /// </summary>
        /// <param name="lastNameSearch">The partial last name to search</param>
        /// <param name="top">The number of records to return</param>
        /// <param name="skip">The number of records to skip</param>
        /// <param name="hasValue"></param>
        /// <param name="isActive"></param>
        /// <returns>The simple list of clients matching the search</returns>
        public List<ClientSimple> GetSimpleLastNameSearch(string lastNameSearch, int top = 5000, int skip = 0, bool? hasValue = null, bool? isActive = null)
        {
            return GetSimpleLastNameSearchAsync(lastNameSearch, top, skip, hasValue, isActive).Result;
        }
        /// <summary>
        /// HTTP GET: /Portfolio/Clients/Simple/Search/LastName
        /// Gets a list of clients whose last name begins with the provided search term
        /// </summary>
        /// <param name="lastNameSearch">The partial last name to search</param>
        /// <param name="top">The number of records to return</param>
        /// <param name="skip">The number of records to skip</param>
        /// <param name="hasValue"></param>
        /// <param name="isActive"></param>
        /// <returns>The simple list of clients matching the search</returns>
        public async Task<List<ClientSimple>> GetSimpleLastNameSearchAsync(string lastNameSearch, int top = 5000, int skip = 0, bool? hasValue = null, bool? isActive = null)
        {
            JToken clients = await GetJsonAsync("Simple/Search/LastName", new Dictionary<string, object>
            {
                { "search", lastNameSearch }
            });
            return clients.ToObject<List<ClientSimple>>();
        }

        /// <summary>
        /// HTTP GET: /Portfolio/Clients/Search/Advanced
        /// Performs an advanced search on the clients available to the user
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="ssnLast4"></param>
        /// <param name="repLastName"></param>
        /// <param name="repNumber"></param>
        /// <param name="repId"></param>
        /// <returns>The list of clients matching the search criteria</returns>
        public List<Client> GetAdvancedSearch(int? clientId = null, string firstName = null, string lastName = null, string ssnLast4 = null, string repLastName = null,
            string repNumber = null, int? repId = null)
        {
            return GetAdvancedSearchAsync(clientId, firstName, lastName, ssnLast4, repLastName, repNumber, repId).Result;
        }
        /// <summary>
        /// HTTP GET: /Portfolio/Clients/Search/Advanced
        /// Performs an advanced search on the clients available to the user
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="ssnLast4"></param>
        /// <param name="repLastName"></param>
        /// <param name="repNumber"></param>
        /// <param name="repId"></param>
        /// <returns>The list of clients matching the search criteria</returns>
        public async Task<List<Client>> GetAdvancedSearchAsync(int? clientId = null, string firstName = null, string lastName = null, string ssnLast4 = null, string repLastName = null,
            string repNumber = null, int? repId = null)
        {
            JToken clients = await GetJsonAsync("Search/Advanced", new Dictionary<string, object>
            {
                { "clientId", clientId },
                { "firstName", firstName },
                { "lastName", lastName },
                { "ssnLast4", ssnLast4 },
                { "repLastName", repLastName },
                { "repNumber", repNumber },
                { "repId", repId }
            });
            return clients.ToObject<List<Client>>();
        }
        #endregion

        #region Client Assets
        /// <summary>
        /// HTTP GET: /Portfolio/Clients/{clientId}/Assets
        /// Get the list of assets for a specific client
        /// </summary>
        /// <param name="clientId">The ID of the client</param>
        /// <param name="includeCostBasis"></param>
        /// <returns>The list of client's assets</returns>
        public List<Asset> GetAssets(int clientId, bool? includeCostBasis = null)
        {
            return GetAssetsAsync(clientId, includeCostBasis).Result;
        }
        /// <summary>
        /// HTTP GET: /Portfolio/Clients/{clientId}/Assets
        /// Get the list of assets for a specific client
        /// </summary>
        /// <param name="clientId">The ID of the client</param>
        /// <param name="includeCostBasis"></param>
        /// <returns>The list of client's assets</returns>
        public async Task<List<Asset>> GetAssetsAsync(int clientId, bool? includeCostBasis = null)
        {
            JToken assets = await GetJsonAsync(string.Format("{0}/Assets", clientId), new Dictionary<string, object>
            {
                { "includeCostBasis", includeCostBasis }
            });
            return assets.ToObject<List<Asset>>();
        }

        /// <summary>
        /// HTTP GET: /Portfolio/Clients/{clientId}/Assets/{asOfDate}
        /// Get the list of assets for a specific client as of a specific date
        /// </summary>
        /// <param name="clientId">The ID of the client</param>
        /// <param name="asOfDate">The specific date</param>
        /// <param name="includeCostBasis"></param>
        /// <returns>The list of client's assets</returns>
        public List<Asset> GetAssets(int clientId, DateTime asOfDate, bool? includeCostBasis = null)
        {
            return GetAssetsAsync(clientId, asOfDate, includeCostBasis).Result;
        }
        /// <summary>
        /// HTTP GET: /Portfolio/Clients/{clientId}/Assets/{asOfDate}
        /// Get the list of assets for a specific client as of a specific date
        /// </summary>
        /// <param name="clientId">The ID of the client</param>
        /// <param name="asOfDate">The specific date</param>
        /// <param name="includeCostBasis"></param>
        /// <returns>The list of client's assets</returns>
        public async Task<List<Asset>> GetAssetsAsync(int clientId, DateTime asOfDate, bool? includeCostBasis = null)
        {
            JToken assets = await GetJsonAsync(string.Format("{0}/Assets/{1:MM-dd-yyyy}", clientId, asOfDate), new Dictionary<string, object>
            {
                { "includeCostBasis", includeCostBasis }
            });
            return assets.ToObject<List<Asset>>();
        }
        #endregion

        /// <summary>
        /// HTTP GET: /Portfolio/Clients/{clientId}/AumOverTime
        /// Gets a specific client's AUM over time
        /// </summary>
        /// <param name="clientId">The ID of the client</param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="interval"></param>
        /// <param name="clientPerformanceInclude"></param>
        /// <param name="unmanagedInclusionOverride"></param>
        /// <returns>A list of AUM Over time data points</returns>
        public List<AumOverTime> GetAumOverTime(int clientId, DateTime? startDate = null, DateTime? endDate = null, OverTimeInterval interval = OverTimeInterval.Automatic,
            ReportAccountInclusionOption clientPerformanceInclude = ReportAccountInclusionOption.Default, ReportCategory? unmanagedInclusionOverride = null)
        {
            return GetAumOverTimeAsync(clientId, startDate, endDate, interval, clientPerformanceInclude, unmanagedInclusionOverride).Result;
        }
        /// <summary>
        /// HTTP GET: /Portfolio/Clients/{clientId}/AumOverTime
        /// Gets a specific client's AUM over time
        /// </summary>
        /// <param name="clientId">The ID of the client</param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="interval"></param>
        /// <param name="clientPerformanceInclude"></param>
        /// <param name="unmanagedInclusionOverride"></param>
        /// <returns>A list of AUM Over time data points</returns>
        public async Task<List<AumOverTime>> GetAumOverTimeAsync(int clientId, DateTime? startDate = null, DateTime? endDate = null, OverTimeInterval interval = OverTimeInterval.Automatic,
            ReportAccountInclusionOption clientPerformanceInclude = ReportAccountInclusionOption.Default, ReportCategory? unmanagedInclusionOverride = null)
        {
            JToken aumOverTimePoints = await GetJsonAsync(string.Format("{0}/AumOverTime", clientId), new Dictionary<string, object>
            {
                { "startDate", startDate.NullableDateToString() },
                { "endDate", endDate.NullableDateToString() },
                { "interval", (char)interval },
                { "clientPerformanceInclude", (int)clientPerformanceInclude },
                { "unmanagedInclusionOverride", (int?)unmanagedInclusionOverride }
            });
            return aumOverTimePoints.ToObject<List<AumOverTime>>();
        }
    }
}
