using OrionApiSdk.Objects.Portfolio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Portfolio.Interfaces
{
    public interface IAccountsMethods : IApiMethodContainer<AccountVerbose>
    {
        List<Account> Get(bool? isActive = null, bool? isManager = null, DateTime? createdDateStart = null, string newAccountFilter = null,
            int? clientId = null, int? registrationId = null, DateTime? asOfDate = null, bool? hasValue = null, int top = 5000, int skip = 0);
        Task<List<Account>> GetAsync(bool? isActive = null, bool? isManager = null, DateTime? createdDateStart = null, string newAccountFilter = null,
            int? clientId = null, int? registrationId = null, DateTime? asOfDate = null, bool? hasValue = null, int top = 5000, int skip = 0)

        Account Get(int accountId);
        Task<Account> GetAsync(int accountId);

        Account Get(string accountNumber);
        Task<Account> GetAsync(string accountNumber);

        List<AccountSimple> GetSimple(bool? hasValue = null, bool? isActive = null, int top = 5000, int skip = 0);
        Task<List<AccountSimple>> GetSimpleAsync(bool? hasValue = null, bool? isActive = null, int top = 5000, int skip = 0)
    }
}
