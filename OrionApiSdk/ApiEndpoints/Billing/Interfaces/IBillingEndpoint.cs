using OrionApiSdk.ApiEndpoints.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Billing.Interfaces
{
    public interface IBillingEndpoint : IApiEndpoint
    {
        ISchedulesMethods Schedules { get; }
    }
}
