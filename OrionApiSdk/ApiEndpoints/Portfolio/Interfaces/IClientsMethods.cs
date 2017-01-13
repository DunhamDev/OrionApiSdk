using OrionApiSdk.ApiEndpoints.Interfaces;
using OrionApiSdk.Objects.Portfolio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Portfolio.Interfaces
{
    public interface IClientsMethods : IApiMethodContainer<ClientVerbose>
    {
        List<Client> Get(bool? hasValue = null, bool? isActive = null, int? representativeId = null, string registrationId = null, int top = 5000, int skip = 0);
        Task<List<Client>> GetAsync(bool? hasValue = null, bool? isActive = null, int? representativeId = null, string registrationId = null, int top = 5000, int skip = 0);

        Client Get(int clientId);
        Task<Client> GetAsync(int clientId);

        List<ClientSimple> GetSimple(bool? hasValue = null, int top = 5000, int skip = 0);
        Task<List<ClientSimple>> GetSimpleAsync(bool? hasValue = null, int top = 5000, int skip = 0);

        ClientSimple GetSimple(int clientId);
        Task<ClientSimple> GetSimpleAsync(int clientId);

        List<ClientVerbose> GetVerbose(bool? isActive = null, int top = 5000, int skip = 0);
        Task<List<ClientVerbose>> GetVerboseAsync(bool? isActive = null, int top = 5000, int skip = 0);

        ClientVerbose GetVerbose(int clientId);
        Task<ClientVerbose> GetVerboseAsync(int clientId);
    }
}
