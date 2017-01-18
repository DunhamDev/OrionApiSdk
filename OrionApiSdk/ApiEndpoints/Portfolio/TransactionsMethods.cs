using OrionApiSdk.ApiEndpoints.Abstract;
using OrionApiSdk.ApiEndpoints.Portfolio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrionApiSdk.Objects.Confirm.Enums;
using OrionApiSdk.Objects.Portfolio;
using OrionApiSdk.Objects.Trading.Enums;
using OrionApiSdk.Objects;
using Newtonsoft.Json.Linq;
using System.Collections.Specialized;
using OrionApiSdk.Common.Extensions;

namespace OrionApiSdk.ApiEndpoints.Portfolio
{
    public class TransactionsMethods : ApiMethodContainer, ITransactionsMethods
    {
        public TransactionsMethods(AuthToken token) : base("Portfolio", "Transactions", token) { }

        public async Task<List<Transaction>> GetAsync(TradeStatus? status = default(TradeStatus?), DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?), int[] transactionTypeIds = null, int? clientId = default(int?), int? registrationId = default(int?), int? accountId = default(int?), int? assetId = default(int?), int? transactionId = default(int?), bool? hasErrors = default(bool?), TaxErrorAuditType[] auditTypes = null, DateTime? editedStartDate = default(DateTime?), DateTime? editedEndDate = default(DateTime?), int top = 5000, int skip = 0)
        {
            NameValueCollection queryParams = new NameValueCollection
            {
                { "$top", top.ToString() },
                { "$skip", skip.ToString() },
                { "status", status.ToString() },
                { "startDate", startDate.NullableDateToString() },
                { "endDate", endDate.NullableDateToString() },
                { "clientId", clientId.ToString() },
                { "registrationId", registrationId.ToString() },
                { "accountId", accountId.ToString() },
                { "assetId", assetId.ToString() },
                { "transactionId", transactionId.ToString() },
                { "editedStartDate", editedStartDate.NullableDateToString() },
                { "editedEndDate", editedEndDate.NullableDateToString() }
            };
            if (transactionTypeIds != null && transactionTypeIds.Length > 0)
            {
                foreach (int transactionTypeId in transactionTypeIds)
                {
                    queryParams.Add("transTypeId", transactionId.ToString());
                }
            }
            if (auditTypes != null && auditTypes.Length > 0)
            {
                foreach (TaxErrorAuditType auditType in auditTypes)
                {
                    queryParams.Add("auditType", ((int)auditType).ToString());
                }
            }

            JToken transactions = await GetJsonAsync("", queryParams);
            return transactions.ToObject<List<Transaction>>();
        }
    }
}
