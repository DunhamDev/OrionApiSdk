using OrionApiSdk.ApiEndpoints.Interfaces;
using OrionApiSdk.Objects.Confirm.Enums;
using OrionApiSdk.Objects.Portfolio;
using OrionApiSdk.Objects.Trading.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Portfolio.Interfaces
{
    public interface ITransactionsMethods : IApiMethodContainer
    {
        Task<List<Transaction>> GetAsync(TradeStatus? status = null, DateTime? startDate = null, DateTime? endDate = null,
            int[] transactionTypeIds = null, int? clientId = null, int? registrationId = null, int? accountId = null, int? assetId = null,
            int? transactionId = null, bool? hasErrors = null, TaxErrorAuditType[] auditTypes = null,
            DateTime? editedStartDate = null, DateTime? editedEndDate = null, int top = 5000, int skip = 0);
    }
}
