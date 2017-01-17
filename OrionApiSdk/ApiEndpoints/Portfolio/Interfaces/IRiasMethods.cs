using OrionApiSdk.ApiEndpoints.Interfaces;
using OrionApiSdk.Objects.Portfolio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Portfolio.Interfaces
{
    public interface IRiasMethods : IApiMethodContainer<RIA>
    {
        List<RIA> Get();
        Task<List<RIA>> GetAsync();

        RIA Get(int riaId);
        Task<RIA> GetAsync(int riaId);

        List<RIASimple> GetSimple();
        Task<List<RIASimple>> GetSimpleAsync();
    }
}
