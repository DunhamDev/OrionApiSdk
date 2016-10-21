using Newtonsoft.Json;
using OrionApiSdk.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects.Portfolio
{
    public class AccountPortfolio : Portfolio, ICreatable, IUpdatable
    {
        #region Properties
        #region Instance properties
        [JsonProperty("accountHistoryId")]
        public int? AccountHistoryId { get; set; }

        [JsonProperty("accountStartDate")]
        public DateTime AccountStartDate { get; set; }

        [JsonProperty("accountStartValue")]
        public decimal AccountStartValue { get; set; }

        [JsonProperty("accountStatusDescription")]
        public string AccountStatusDescription { get; set; }

        [JsonProperty("accountStatusId")]
        public int AccountStatusId { get; set; }

        [JsonProperty("accountType")]
        public string AccountType { get; set; }

        [JsonProperty("businessLine")]
        public int? BuisnessLine { get; set; }

        [JsonProperty("clientId")]
        public int? ClientId { get; set; }

        [JsonProperty("custodian")]
        public string Custodian { get; set; }

        [JsonProperty("custodianId")]
        public int CustodianId { get; set; }

        [JsonProperty("downloadSource")]
        public string DownloadSource { get; set; }

        [JsonProperty("downloadSourceId")]
        public int? DownloadSourceId { get; set; }

        [JsonProperty("fundFamily")]
        public string FundFamily { get; set; }

        [JsonProperty("fundFamilyId")]
        public int FundFamilyId { get; set; }

        [JsonProperty("isDiscretionary")]
        public bool IsDiscretionary { get; set; }

        [JsonProperty("isManaged")]
        public bool IsManaged { get; set; }

        [JsonProperty("isSleeveAccount")]
        public bool IsSleeveAccount { get; set; }

        [JsonProperty("isSweepAccount")]
        public bool IsSweepAccount { get; set; }

        [JsonProperty("isWrapManaged")]
        public bool IsWrapManaged { get; set; }

        [JsonProperty("managementStyle")]
        public string ManagementStyle { get; set; }

        [JsonProperty("managementStyleId")]
        public int ManagementStyleId { get; set; }

        [JsonProperty("modelName")]
        public string ModelName { get; set; }

        [JsonProperty("outsideId")]
        public string OutsideId { get; set; }

        [JsonProperty("plan")]
        public int? Plan { get; set; }

        [JsonProperty("portfolioGroupCompositeId")]
        public int? PortfolioGroupCompositeId { get; set; }

        [JsonProperty("provider")]
        public string Provider { get; set; }

        [JsonProperty("registrationId")]
        public int RegistrationId { get; set; }

        [JsonProperty("registrationName")]
        public string RegistrationName { get; set; }

        [JsonProperty("shareClass")]
        public string ShareClass { get; set; }

        [JsonProperty("shareClassId")]
        public int ShareClassId { get; set; }

        [JsonProperty("subAdvisor")]
        public string SubAdvisor { get; set; }

        [JsonProperty("SubAdvisorId")]
        public int? SubAdvisorId { get; set; }
        #endregion
        #endregion

        #region Methods
        #region Public methods
        public void CheckNecessaryDataForCreate()
        {
            throw new NotImplementedException();
        }

        public void CheckNecessaryDataForUpdate()
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
    }
}
