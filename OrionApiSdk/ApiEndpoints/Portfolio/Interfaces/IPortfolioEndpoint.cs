using OrionApiSdk.ApiEndpoints.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Portfolio.Interfaces
{
    public interface IPortfolioEndpoint : IApiEndpoint
    {
        IAccountsMethods Accounts { get; }

        IRepresentativesMethods Representatives { get; }

        IRegistrationsMethods Registrations { get; }
    }
}
