using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OrionApiSdk.Common.Converters;
using OrionApiSdk.Objects.Portfolio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects.Portfolio
{
    public class Transaction
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter))]
        [JsonProperty("transDate")]
        public DateTime TransDate { get; set; }

        [JsonProperty("transactionDescription")]
        public string TransactionDescription { get; set; }

        [JsonProperty("productName")]
        public string ProductName { get; set; }

        [JsonProperty("ticker")]
        public string Ticker { get; set; }

        [JsonProperty("transAmount")]
        public decimal TransAmount { get; set; }

        [JsonProperty("noUnits")]
        public decimal NoUnits { get; set; }

        [JsonProperty("navPrice")]
        public decimal NavPrice { get; set; }

        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter))]
        [JsonProperty("transTime")]
        public DateTime? TransTime { get; set; }

        [JsonProperty("assetId")]
        public int AssetId { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("transTypeId")]
        public int TransTypeId { get; set; }

        [JsonProperty("contributionCodeId")]
        public int? ContributionCodeId { get; set; }

        [JsonProperty("contributionCodeName")]
        public string ContributionCodeName { get; set; }

        [JsonProperty("distributionCodeId")]
        public int? DistributionCodeId { get; set; }

        [JsonProperty("distributionCodeName")]
        public string DistributionCodeName { get; set; }

        [JsonProperty("accountId")]
        public int AccountId { get; set; }

        [JsonProperty("managementStyle")]
        public string ManagementStyle { get; set; }

        [JsonProperty("payee")]
        public int? Payee { get; set; }

        [JsonProperty("advisorNotes")]
        public string AdvisorNotes { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter))]
        [JsonProperty("settleDate")]
        public DateTime? SettleDate { get; set; }

        [JsonProperty("tradeReferenceNumber")]
        public string TradeReferenceNumber { get; set; }

        [JsonProperty("transactionLinkCode")]
        public string TransactionLinkCode { get; set; }

        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter))]
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("editedBy")]
        public string EditedBy { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter))]
        [JsonProperty("editedDate")]
        public DateTime EditedDate { get; set; }

        [JsonProperty("registrationId")]
        public int RegistrationId { get; set; }

        [JsonProperty("clientId")]
        public int ClientId { get; set; }

        [JsonProperty("typeCode")]
        public string TypeCode { get; set; }

        [JsonProperty("brokerCode")]
        public object BrokerCode { get; set; }

        [JsonProperty("accountType")]
        public string AccountType { get; set; }

        [JsonProperty("fundFamily")]
        public string FundFamily { get; set; }

        [JsonProperty("custodian")]
        public string Custodian { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("registrationName")]
        public string RegistrationName { get; set; }

        [JsonProperty("unitBalance")]
        public decimal UnitBalance { get; set; }

        [JsonProperty("productId")]
        public int ProductId { get; set; }

        [JsonProperty("financialType")]
        public string FinancialType { get; set; }
    }
}
