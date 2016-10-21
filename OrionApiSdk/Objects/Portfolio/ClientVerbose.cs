using Newtonsoft.Json;
using OrionApiSdk.Objects.Abstract;
using OrionApiSdk.Objects.Exceptions;
using OrionApiSdk.Objects.Interfaces;
using System.Collections.Generic;

namespace OrionApiSdk.Objects.Portfolio
{
    public class ClientVerbose : BaseSimpleEntity, IUpdatable, ICreatable
    {
        #region Properties
        #region Instance properties
        // TODO: Create remaining properties
        [JsonProperty("billing")]
        public List<ClientBilling> Billing { get; set; }

        [JsonProperty("recurringAdjustments")]
        public List<BillRecurrentAdjustment> RecurringAdjustments { get; set; }

        [JsonProperty("feePayingAccounts")]
        public List<BillFeePayingAccount> FeePayingAccounts { get; set; }

        [JsonProperty("householdMembers")]
        public List<HouseholdMember> HouseholdMembers { get; set; }

        [JsonProperty("portfolio")]
        public ClientPortfolio Portfolio { get; set; }

        [JsonProperty("notes")]
        public List<Note> Notes { get; set; }

        [JsonProperty("documents")]
        public List<Document> Documents { get; set; }
        #endregion
        #endregion

        #region Methods
        #region Public methods
        public void CheckNecessaryDataForCreate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new EmptyStringException("Name");
            }
            if (Portfolio == null)
            {
                throw new UninitializedPropertyException("Portfolio");
            }
            CheckPortfolioProperties();
        }

        public void CheckNecessaryDataForUpdate()
        {
            if (Portfolio != null)
            {
                CheckPortfolioProperties();
            }
        }
        #endregion

        #region Private methods
        private void CheckPortfolioProperties()
        {
            if (string.IsNullOrWhiteSpace(Portfolio.LastName))
            {
                throw new EmptyStringException("Portfolio.LastName");
            }
            if (string.IsNullOrWhiteSpace(Portfolio.Name))
            {
                throw new EmptyStringException("Portfolio.Name");
            }
        }
        #endregion
        #endregion
    }
}
