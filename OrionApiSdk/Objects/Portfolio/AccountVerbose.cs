using Newtonsoft.Json;
using OrionApiSdk.Objects.Abstract;
using OrionApiSdk.Objects.Billing;
using OrionApiSdk.Objects.Interfaces;
using OrionApiSdk.Objects.Trading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects.Portfolio
{
    public class AccountVerbose : BaseSimpleEntity, ICreatable, IUpdatable
    {
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("portfolio")]
        public AccountPortfolio Portfolio { get; set; }

        [JsonProperty("billing")]
        public AccountBilling Billing { get; set; }

        [JsonProperty("modelingInfo")]
        public AccountModelingInfo ModelingInfo { get; set; }

        [JsonProperty("notes")]
        public List<Note> Notes { get; set; }

        [JsonProperty("documents")]
        public List<Document> Documents { get; set; }

        [JsonProperty("systematics")]
        public List<Systematic> Systematics { get; set; }

        [JsonProperty("accountManagers")]
        public List<AccountManager> AccountManagers { get; set; }

        [JsonProperty("recurringAdjustments")]
        public List<BillRecurrentAdjustment> RecurringAdjustments { get; set; }

        [JsonProperty("generalAccounts")]
        public List<GeneralAccount> GeneralAccounts { get; set; }

        [JsonProperty("referralSchedules")]
        public List<AccountReferral> ReferralSchedules { get; set; }

        [JsonProperty("billAccountSchedules")]
        public List<BillAccountSchedule> BillAccountSchedules { get; set; }

        [JsonProperty("targetAllocations")]
        public List<TargetAllocation> TargetAllocations { get; set; }

        [JsonProperty("productEquivalents")]
        public List<ProductEquivalent> ProductEquivalents { get; set; }

        [JsonProperty("sma")]
        public AccountSma Sma { get; set; }

        [JsonProperty("bondTrade")]
        public AccountBondTrade BondTrade { get; set; }

        [JsonProperty("compositeExclusions")]
        public List<CompositeAccountExclude> CompositeExclusions { get; set; }

        public void CheckNecessaryDataForCreate()
        {
            throw new NotImplementedException();
        }

        public void CheckNecessaryDataForUpdate()
        {
            throw new NotImplementedException();
        }
    }
}
