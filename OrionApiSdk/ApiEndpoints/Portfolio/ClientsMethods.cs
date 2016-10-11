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
    public class ClientsMethods : ApiMethodContainer
    {
        public ClientsMethods(AuthToken token) : base("Portfolio", "Clients", token) { }

        #region Get clients
        public List<Client> Get(bool? hasValue = null, bool? isActive = null, int? representativeId = null, string registrationId = null, int top = 5000, int skip = 0)
        {
            return GetAsync(hasValue, isActive, representativeId, registrationId, top, skip).Result;
        }
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

        public Client Get(int clientId)
        {
            return GetAsync(clientId).Result;
        }
        public async Task<Client> GetAsync(int clientId)
        {
            JToken client = await GetJsonAsync(clientId.ToString());
            return client.ToObject<Client>();
        }

        public List<ClientSimple> GetSimple(bool? hasValue = null, int top = 5000, int skip = 0)
        {
            return GetSimpleAsync(hasValue, top, skip).Result;
        }
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

        public ClientSimple GetSimple(int clientId)
        {
            return GetSimpleAsync(clientId).Result;
        }
        public async Task<ClientSimple> GetSimpleAsync(int clientId)
        {
            JToken client = await GetJsonAsync(string.Format("{0}/Simple", clientId));
            return client.ToObject<ClientSimple>();
        }
        #endregion

        #region Client values
        public List<ClientSimple> GetValues(bool? hasValue = null, bool? resetCache = null, bool? includeCash = null, int top = 5000, int skip = 0)
        {
            return GetValuesAsync(hasValue, resetCache, includeCash, top, skip).Result;
        }
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

        public List<ClientSimple> GetValues(DateTime asOfDate, bool? hasValue = null, bool? resetCache = null, bool? includeCash = null, int top = 5000, int skip = 0)
        {
            return GetValuesAsync(asOfDate, hasValue, resetCache, includeCash, top, skip).Result;
        }
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

        public ClientSimple GetValue(int clientId, bool? includeCash = null)
        {
            return GetValueAsync(clientId, includeCash).Result;
        }
        public async Task<ClientSimple> GetValueAsync(int clientId, bool? includeCash = null)
        {
            JToken client = await GetJsonAsync(string.Format("{0}/Value", clientId), new Dictionary<string, object>
            {
                { "includeCash", includeCash }
            });
            return client.ToObject<ClientSimple>();
        }

        public ClientSimple GetValue(int clientId, DateTime asOfDate, bool? includeCash = null)
        {
            return GetValueAsync(clientId, asOfDate, includeCash).Result;
        }
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
        public List<Account> GetAccounts(int clientId, bool? isActive = null)
        {
            return GetAccountsAsync(clientId, isActive).Result;
        }
        public async Task<List<Account>> GetAccountsAsync(int clientId, bool? isActive = null)
        {
            JToken accounts = await GetJsonAsync(string.Format("{0}/Accounts", clientId), new Dictionary<string, object>
            {
                { "isActive", isActive }
            });
            return accounts.ToObject<List<Account>>();
        }

        public List<Account> GetAdditionalAccounts(int clientId)
        {
            return GetAdditionalAccountsAsync(clientId).Result;
        }
        public async Task<List<Account>> GetAdditionalAccountsAsync(int clientId)
        {
            JToken accounts = await GetJsonAsync(string.Format("{0}/AdditionalAccounts", clientId));
            return accounts.ToObject<List<Account>>();
        }

        public List<AccountSimple> GetAccountValues(int clientId, bool? hasValue = null)
        {
            return GetAccountValuesAsync(clientId, hasValue).Result;
        }
        public async Task<List<AccountSimple>> GetAccountValuesAsync(int clientId, bool? hasValue = null)
        {
            JToken accountValues = await GetJsonAsync(string.Format("{0}/Accounts/Value", clientId), new Dictionary<string, object>
            {
                { "hasValue", hasValue }
            });
            return accountValues.ToObject<List<AccountSimple>>();
        }

        public List<AccountSimple> GetAccountValues(int clientId, DateTime asOfDate, bool? hasValue = null)
        {
            return GetAccountValuesAsync(clientId, asOfDate, hasValue).Result;
        }
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
        public List<ClientSimple> GetSimpleSearch(string search, int top = 5000, int skip = 0, bool? hasValue = null, bool? isActive = null)
        {
            return GetSimpleSearchAsync(search, top, skip, hasValue, isActive).Result;
        }
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

        public List<ClientSimple> GetSimpleLastNameSearch(string lastNameSearch, int top = 5000, int skip = 0, bool? hasValue = null, bool? isActive = null)
        {
            return GetSimpleLastNameSearchAsync(lastNameSearch, top, skip, hasValue, isActive).Result;
        }
        public async Task<List<ClientSimple>> GetSimpleLastNameSearchAsync(string lastNameSearch, int top = 5000, int skip = 0, bool? hasValue = null, bool? isActive = null)
        {
            JToken clients = await GetJsonAsync("Simple/Search/LastName", new Dictionary<string, object>
            {
                { "search", lastNameSearch }
            });
            return clients.ToObject<List<ClientSimple>>();
        }

        public List<Client> GetAdvancedSearch(int? clientId = null, string firstName = null, string lastName = null, string ssnLast4 = null, string repLastName = null,
            string repNumber = null, int? repId = null)
        {
            return GetAdvancedSearchAsync(clientId, firstName, lastName, ssnLast4, repLastName, repNumber, repId).Result;
        }
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
    }
}
