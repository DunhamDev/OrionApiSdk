using Newtonsoft.Json;
using OrionApiSdk.Objects.Billing;
using System;
using System.Collections.Generic;

namespace OrionApiSdk.Objects.Portfolio
{

    public class AccountBilling
    {
        #region Properties
        #region Public properties
        [JsonProperty("billAccountId")]
        public int BillAccountId { get; set; }

        [JsonProperty("accountType")]
        public string AccountType { get; set; }

        [JsonProperty("fundName")]
        public string FundName { get; set; }

        [JsonProperty("feeSchedule")]
        public string FeeSchedule { get; set; }

        [JsonProperty("masterPayoutSchedule")]
        public string MasterPayoutSchedule { get; set; }

        [JsonProperty("payMethod")]
        public string PayMethod { get; set; }

        [JsonProperty("billFrequency")]
        public string BillFrequency { get; set; }

        [JsonProperty("billStyle")]
        public string BillStyle { get; set; }

        [JsonProperty("acceptsList")]
        public bool AcceptsList { get; set; }

        [JsonProperty("valuationMethod")]
        public string ValuationMethod { get; set; }

        [JsonProperty("fundFamilyId")]
        public int FundFamilyId { get; set; }

        [JsonProperty("managementStyleId")]
        public int ManagementStyleId { get; set; }

        [JsonProperty("subAdvisorId")]
        public int SubAdvisorId { get; set; }

        [JsonProperty("feeScheduleId")]
        public int FeeScheduleId { get; set; }

        [JsonProperty("masterPayoutScheduleId")]
        public int MasterPayoutScheduleId { get; set; }

        [JsonProperty("payMethodId")]
        public int PayMethodId { get; set; }

        [JsonProperty("billStartDate")]
        public string BillStartDate { get; set; }

        [JsonProperty("bankName")]
        public string BankName { get; set; }

        [JsonProperty("abaNumber")]
        public string AbaNumber { get; set; }

        [JsonProperty("bankAccountNumber")]
        public string BankAccountNumber { get; set; }

        [JsonProperty("nameOnAccount")]
        public string NameOnAccount { get; set; }

        [JsonProperty("custodialAccountNumber")]
        public string CustodialAccountNumber { get; set; }

        [JsonProperty("isPerformanceBilled")]
        public bool IsPerformanceBilled { get; set; }

        [JsonProperty("lastPerfBillDate")]
        public DateTime LastPerfBillDate { get; set; }

        [JsonProperty("expirationDate")]
        public string ExpirationDate { get; set; }

        [JsonProperty("addressLine1")]
        public string AddressLine1 { get; set; }

        [JsonProperty("addressLine2")]
        public string AddressLine2 { get; set; }

        [JsonProperty("addressLine3")]
        public string AddressLine3 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("includeInAggregate")]
        public bool IncludeInAggregate { get; set; }

        [JsonProperty("nonManagedAccountNumber")]
        public string NonManagedAccountNumber { get; set; }

        [JsonProperty("nonManagedAccountName")]
        public string NonManagedAccountName { get; set; }

        [JsonProperty("nonManagedHouseholdName")]
        public string NonManagedHouseholdName { get; set; }

        [JsonProperty("cycleMonth")]
        public int CycleMonth { get; set; }

        [JsonProperty("performanceMasterPayoutSchedule")]
        public string PerformanceMasterPayoutSchedule { get; set; }

        [JsonProperty("performanceFeeSchedule")]
        public string PerformanceFeeSchedule { get; set; }

        [JsonProperty("performanceMasterPayoutScheduleId")]
        public int PerformanceMasterPayoutScheduleId { get; set; }

        [JsonProperty("performanceFeeScheduleId")]
        public int PerformanceFeeScheduleId { get; set; }

        [JsonProperty("cardType")]
        public string CardType { get; set; }

        [JsonProperty("nameOnCard")]
        public string NameOnCard { get; set; }

        [JsonProperty("paysForAccounts")]
        public List<BillPaysForAccount> PaysForAccounts { get; set; }

        [JsonProperty("payedByAccounts")]
        public List<BillPaysForAccount> PayedByAccounts { get; set; }

        [JsonProperty("payeeList")]
        public List<BillAccountEntityPayee> PayeeList { get; set; }

        [JsonProperty("creditCardNumber")]
        public string CreditCardNumber { get; set; }

        [JsonProperty("accountHistoryBillingId")]
        public int AccountHistoryBillingId { get; set; }
        #endregion
        #endregion

        #region Constructor
        public AccountBilling()
        {
            PaysForAccounts = new List<BillPaysForAccount>();
            PayedByAccounts = new List<BillPaysForAccount>();
            PayeeList = new List<BillAccountEntityPayee>();
        }
        #endregion
    }
}