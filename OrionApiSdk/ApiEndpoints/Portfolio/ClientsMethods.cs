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
    }
}
