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
    public class RegistrationsMethods : ApiMethodContainer
    {
        public RegistrationsMethods(AuthToken token) : base("Portfolio", "Registrations", token) { }

        #region Get registrations
        public List<Registration> Get(bool? isActive = null, int? representativeId = null, int top = 5000, int skip = 0)
        {
            return GetAsync(isActive, representativeId, top, skip).Result;
        }
        public async Task<List<Registration>> GetAsync(bool? isActive = null, int? representativeId = null, int top = 5000, int skip = 0)
        {
            JToken registrations = await GetJsonAsync("", new Dictionary<string, object>
            {
                { "isActive", isActive },
                { "representativeId", representativeId },
                { "$top", top },
                { "$skip", skip }
            });
            return registrations.ToObject<List<Registration>>();
        }

        public Registration Get(int registrationId)
        {
            return GetAsync(registrationId).Result;
        }
        public async Task<Registration> GetAsync(int registrationId)
        {
            JToken registration = await GetJsonAsync(registrationId.ToString());
            return registration.ToObject<Registration>();
        }

        public List<RegistrationSimple> GetSimple(int top = 5000, int skip = 0)
        {
            return GetSimpleAsync(top, skip).Result;
        }
        public async Task<List<RegistrationSimple>> GetSimpleAsync(int top = 5000, int skip = 0)
        {
            JToken registations = await GetJsonAsync("Simple", new Dictionary<string, object>
            {
                { "$top", top },
                { "$skip", skip }
            });
            return registations.ToObject<List<RegistrationSimple>>();
        }

        public RegistrationSimple GetSimple(int registrationId)
        {
            return GetSimpleAsync(registrationId).Result;
        }
        public async Task<RegistrationSimple> GetSimpleAsync(int registrationId)
        {
            JToken registration = await GetJsonAsync(string.Format("{0}/Simple", registrationId));
            return registration.ToObject<RegistrationSimple>();
        }
        #endregion

        #region Registration searches
        public List<RegistrationSimple> GetSimpleSearch(string search, int top = 5000, int skip = 0, bool? isActive = null)
        {
            return GetSimpleSearchAsync(search, top, skip, isActive).Result;
        }
        public async Task<List<RegistrationSimple>> GetSimpleSearchAsync(string search, int top = 5000, int skip = 0, bool? isActive = null)
        {
            JToken registrations = await GetJsonAsync("Simple/Search", new Dictionary<string, object>
            {
                { "search", search },
                { "top", top },
                { "skip", skip },
                { "isActive", isActive }
            });
            return registrations.ToObject<List<RegistrationSimple>>();
        }

        public List<RegistrationSimple> GetSimpleLastNameSearch(string search)
        {
            return GetSimpleLastNameSearchAsync(search).Result;
        }
        public async Task<List<RegistrationSimple>> GetSimpleLastNameSearchAsync(string search)
        {
            JToken registrations = await GetJsonAsync("Simple/Search/LastName", new Dictionary<string, object>
            {
                { "search", search }
            });
            return registrations.ToObject<List<RegistrationSimple>>();
        }

        public List<Registration> GetAdvancedSearch(int? registrationId = null, string firstName = null, string lastName = null, string name = null,
            string ssnLast4 = null, int? clientId = null)
        {
            return GetAdvancedSearchAsync(registrationId, firstName, lastName, name, ssnLast4, clientId).Result;
        }
        public async Task<List<Registration>> GetAdvancedSearchAsync(int? registrationId = null, string firstName = null, string lastName = null, string name = null,
            string ssnLast4 = null, int? clientId = null)
        {
            JToken registrations = await GetJsonAsync("Search/Advanced", new Dictionary<string, object>
            {
                { "registrationId", registrationId },
                { "firstName", firstName },
                { "lastName", lastName },
                { "name", name },
                { "ssnLast4", ssnLast4 },
                { "clientId", clientId }
            });
            return registrations.ToObject<List<Registration>>();
        }
        #endregion

        #region Registration accounts
        public List<Account> GetAccounts(int registrationId, bool? isActive = null)
        {
            return GetAccountsAsync(registrationId, isActive).Result;
        }
        public async Task<List<Account>> GetAccountsAsync(int registrationId, bool? isActive = null)
        {
            JToken accounts = await GetJsonAsync(string.Format("{0}/Accounts", registrationId), new Dictionary<string, object>
            {
                { "isActive", isActive }
            });
            return accounts.ToObject<List<Account>>();
        }

        public List<AccountSimple> GetAccountValues(int registrationId, bool? hasValue = null)
        {
            return GetAccountValuesAsync(registrationId, hasValue).Result;
        }
        public async Task<List<AccountSimple>> GetAccountValuesAsync(int registrationId, bool? hasValue = null)
        {
            JToken accounts = await GetJsonAsync(string.Format("{0}/Accounts/Value", registrationId), new Dictionary<string, object>
            {
                { "hasValue", hasValue }
            });
            return accounts.ToObject<List<AccountSimple>>();
        }

        public List<AccountSimple> GetAccountValues(int registrationId, DateTime asOfDate, bool? hasValue = null)
        {
            return GetAccountValuesAsync(registrationId, hasValue).Result;
        }
        public async Task<List<AccountSimple>> GetAccountValuesAsync(int registrationId, DateTime asOfDate, bool? hasValue = null)
        {
            JToken accounts = await GetJsonAsync(string.Format("{0}/Accounts/Value/{1:MM-dd-yyyy}", registrationId, asOfDate), new Dictionary<string, object>
            {
                { "hasValue", hasValue }
            });
            return accounts.ToObject<List<AccountSimple>>();
        }
        #endregion

        #region Registration assets
        public List<Asset> GetAssets(int registrationId, bool? includeCostBasis = null)
        {
            return GetAssetsAsync(registrationId, includeCostBasis).Result;
        }
        public async Task<List<Asset>> GetAssetsAsync(int registrationId, bool? includeCostBasis = null)
        {
            JToken assets = await GetJsonAsync(string.Format("{0}/Assets", registrationId), new Dictionary<string, object>
            {
                { "includeCostBasis", includeCostBasis }
            });
            return assets.ToObject<List<Asset>>();
        }

        public List<Asset> GetAssets(int registrationId, DateTime asOfDate, bool? includeCostBasis = null)
        {
            return GetAssetsAsync(registrationId, includeCostBasis).Result;
        }
        public async Task<List<Asset>> GetAssetsAsync(int registrationId, DateTime asOfDate, bool? includeCostBasis = null)
        {
            JToken assets = await GetJsonAsync(string.Format("{0}/Assets/{1:MM-dd-yyyy}", registrationId, asOfDate), new Dictionary<string, object>
            {
                { "includeCostBasis", includeCostBasis }
            });
            return assets.ToObject<List<Asset>>();
        }

        public List<Asset> GetAssetValues(int registrationId, bool? hasValue = null)
        {
            return GetAssetValuesAsync(registrationId, hasValue).Result;
        }
        public async Task<List<Asset>> GetAssetValuesAsync(int registrationId, bool? hasValue = null)
        {
            JToken assets = await GetJsonAsync(string.Format("{0}/Assets/Value", registrationId), new Dictionary<string, object>
            {
                { "hasValue", hasValue }
            });
            return assets.ToObject<List<Asset>>();
        }

        public List<Asset> GetAssetValues(int registrationId, DateTime asOfDate, bool? hasValue = null)
        {
            return GetAssetValuesAsync(registrationId, hasValue).Result;
        }
        public async Task<List<Asset>> GetAssetValuesAsync(int registrationId, DateTime asOfDate, bool? hasValue = null)
        {
            JToken assets = await GetJsonAsync(string.Format("{0}/Assets/Value/{1:MM-dd-yyyy}", registrationId, asOfDate), new Dictionary<string, object>
            {
                { "hasValue", hasValue }
            });
            return assets.ToObject<List<Asset>>();
        }
        #endregion
    }
}
