using OrionApiSdk.ApiEndpoints.Abstract;
using OrionApiSdk.ApiEndpoints.Billing.Interfaces;
using OrionApiSdk.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Billing
{
    public class BillingEndpoint : ApiEndpointBase, IBillingEndpoint
    {
        public BillingEndpoint(AuthToken token) : this(token, false)
        {

        }
        public BillingEndpoint(AuthToken token, bool useTesting) : base("Billing", token, useTesting)
        {

        }

        private ISchedulesMethods _schedules;
        public ISchedulesMethods Schedules
        {
            get
            {
                return _schedules ??
                    (_schedules = new SchedulesMethods(AuthToken));
            }
        }
    }
}
