using OrionApiSdk.ApiEndpoints.Interfaces;
using OrionApiSdk.Objects.Portfolio;
using OrionApiSdk.Objects.Portfolio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Portfolio.Interfaces
{
    public interface IRegistrationsMethods : IApiMethodContainer<RegistrationVerbose>
    {
        List<Registration> Get(bool? isActive = null, int? representativeId = null, int top = 5000, int skip = 0);
        Task<List<Registration>> GetAsync(bool? isActive = null, int? representativeId = null, int top = 5000, int skip = 0);

        Registration Get(int registrationId);
        Task<Registration> GetAsync(int registrationId);

        List<RegistrationSimple> GetSimple(int top = 5000, int skip = 0);
        Task<List<RegistrationSimple>> GetSimpleAsync(int top = 5000, int skip = 0);

        RegistrationSimple GetSimple(int registrationId);
        Task<RegistrationSimple> GetSimpleAsync(int registrationId);

        List<RegistrationVerbose> GetVerbose(bool? isActive = null, int top = 5000, int skip = 0, params RegistrationPropertyExpand[] expand);
        Task<List<RegistrationVerbose>> GetVerboseAsync(bool? isActive = null, int top = 5000, int skip = 0, params RegistrationPropertyExpand[] expand);

        RegistrationVerbose GetVerbose(int registrationId, params RegistrationPropertyExpand[] expand);
        Task<RegistrationVerbose> GetVerboseAsync(int registrationId, params RegistrationPropertyExpand[] expand);
    }
}
