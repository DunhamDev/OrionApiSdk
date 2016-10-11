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
    }
}
