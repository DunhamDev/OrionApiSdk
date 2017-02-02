using Newtonsoft.Json;
using OrionApiSdk.Objects.Abstract;
using OrionApiSdk.Objects.Billing;
using OrionApiSdk.Objects.Exceptions;
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
        #region Properties
        #region Public properties
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
        #endregion
        #endregion

        #region Constructors
        public AccountVerbose()
        {
            Portfolio = new AccountPortfolio();
            Billing = new AccountBilling();
            ModelingInfo = new AccountModelingInfo();
            Sma = new AccountSma();
            BondTrade = new AccountBondTrade();
            Notes = new List<Note>();
            Systematics = new List<Systematic>();
            AccountManagers = new List<AccountManager>();
            RecurringAdjustments = new List<BillRecurrentAdjustment>();
            GeneralAccounts = new List<GeneralAccount>();
            ReferralSchedules = new List<AccountReferral>();
            BillAccountSchedules = new List<BillAccountSchedule>();
            TargetAllocations = new List<TargetAllocation>();
            ProductEquivalents = new List<ProductEquivalent>();
            CompositeExclusions = new List<CompositeAccountExclude>();
        }
        #endregion

        #region Methods
        #region Public methods
        public void CheckNecessaryDataForCreate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new EmptyStringException("Name");
            }
            CheckPortfolioPropertiesForCreateAndUpdate();
            CheckBillingProperties();
            if (Portfolio.AccountStartDate == new DateTime())
            {
                throw new UninitializedPropertyException("Portfolio.AccountStartDate");
            }
        }

        public void CheckNecessaryDataForUpdate()
        {
            if (Portfolio != null)
            {
                CheckPortfolioPropertiesForCreateAndUpdate();
            }
        }
        #endregion

        #region Private methods
        private void CheckPortfolioPropertiesForCreateAndUpdate()
        {
            if (Portfolio.AccountStatusId == 0)
            {
                throw new UninitializedPropertyException("Portfolio.AccountStatusId");
            }
            if (Portfolio.FundFamilyId == 0)
            {
                throw new UninitializedPropertyException("Portfolio.FundFamilyId");
            }
            if (Portfolio.CustodianId == 0)
            {
                throw new UninitializedPropertyException("Portfolio.CustodianId");
            }
            if (Portfolio.RegistrationId == 0)
            {
                throw new UninitializedPropertyException("Portfolio.RegistrationId");
            }
        }

        private void CheckBillingProperties()
        {
            if (string.IsNullOrWhiteSpace(Billing.ValuationMethod))
            {
                throw new UninitializedPropertyException("Billing.ValuationMethod");
            }
            if (string.IsNullOrWhiteSpace(Billing.BillStyle))
            {
                throw new UninitializedPropertyException("Billing.BillStyle");
            }
            if (string.IsNullOrWhiteSpace(Billing.BillFrequency))
            {
                throw new UninitializedPropertyException("Billing.BillFrequency");
            }
        }
        #endregion
        #endregion
    }
}
