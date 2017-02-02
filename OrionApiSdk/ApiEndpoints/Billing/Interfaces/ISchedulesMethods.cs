using OrionApiSdk.ApiEndpoints.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Billing.Interfaces
{
    public interface ISchedulesMethods : IApiMethodContainer
    {
        List<Objects.Billing.BillSchedule> Get(int? billEntityId = null, Objects.Billing.Enums.BillSchedule[] schedules = null);
        Task<List<Objects.Billing.BillSchedule>> GetAsync(int? billEntityId = null, Objects.Billing.Enums.BillSchedule[] schedules = null);

        Objects.Billing.BillSchedule Get(int id);
        Task<Objects.Billing.BillSchedule> GetAsync(int id);
    }
}
