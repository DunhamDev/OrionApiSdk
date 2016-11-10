using OrionApiSdk.ApiEndpoints.Abstract;
using OrionApiSdk.Objects;
using OrionApiSdk.Objects.Billing;
using OrionApiSdk.Objects.Billing.Enums;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Billing
{
    public class SchedulesMethods : ApiMethodContainer
    {
        public SchedulesMethods(AuthToken token) : this(token, false)
        {

        }
        public SchedulesMethods(AuthToken token, bool useTesting) : base("Billing", "Schedules", token, useTesting)
        {

        }

        public List<Objects.Billing.BillSchedule> Get(int? billEntityId = null, Objects.Billing.Enums.BillSchedule[] schedules = null)
        {
            return GetAsync(billEntityId, schedules).Result;
        }
        public async Task<List<Objects.Billing.BillSchedule>> GetAsync(int? billEntityId = null, Objects.Billing.Enums.BillSchedule[] schedules = null)
        {
            NameValueCollection queryStringParams = new NameValueCollection();
            if (billEntityId != null)
            {
                queryStringParams.Add("billEntityId", billEntityId.Value.ToString());
            }
            if (schedules != null)
            {
                foreach (var schedule in schedules)
                {
                    queryStringParams.Add("schedule", schedule.ToString());
                }
            }

            var response = await GetJsonAsync("", queryStringParams);
            return response.ToObject<List<Objects.Billing.BillSchedule>>();
        }

        public Objects.Billing.BillSchedule Get(int id)
        {
            return GetAsync(id).Result;
        }
        public async Task<Objects.Billing.BillSchedule> GetAsync(int id)
        {
            var response = await GetJsonAsync(id.ToString());
            return response.ToObject<Objects.Billing.BillSchedule>();
        }
    }
}
