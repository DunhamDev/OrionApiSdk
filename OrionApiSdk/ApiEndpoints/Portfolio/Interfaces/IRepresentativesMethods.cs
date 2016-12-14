using OrionApiSdk.ApiEndpoints.Interfaces;
using OrionApiSdk.Objects.Portfolio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Portfolio.Interfaces
{
    public interface IRepresentativesMethods : IApiMethodContainer<RepresentativeVerbose>
    {
        List<Representative> Get(bool? isUsed = null, int top = 5000, int skip = 0);
        Task<List<Representative>> GetAsync(bool? isUsed = null, int top = 5000, int skip = 0);

        Representative Get(int repId);
        Task<Representative> GetAsync(int repId);

        List<RepresentativeSimple> GetSimple(bool? isUsed = null);
        Task<List<RepresentativeSimple>> GetSimpleAsync(bool? isUsed = null);

        List<RepresentativeVerbose> GetVerbose(bool? isActive = null, int top = 5000, int skip = 0);
        Task<List<RepresentativeVerbose>> GetVerboseAsync(bool? isActive = null, int top = 5000, int skip = 0);

        RepresentativeVerbose GetVerbose(int repId);
        Task<RepresentativeVerbose> GetVerboseAsync(int repId);

        List<Account> GetAccounts(int repId, int top = 5000, int skip = 0);
        Task<List<Account>> GetAccountsAsync(int repId, int top = 5000, int skip = 0);
    }
}
