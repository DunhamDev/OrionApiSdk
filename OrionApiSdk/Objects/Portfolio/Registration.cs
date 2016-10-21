using Newtonsoft.Json;
using OrionApiSdk.Objects.Abstract;
using OrionApiSdk.Objects.Interfaces;
using System;

namespace OrionApiSdk.Objects.Portfolio
{
    public class Registration : BaseSimpleEntity, IUpdatable, ICreatable
    {
        #region Properties
        #region Instance properties
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
        
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        
        [JsonProperty("accountType")]
        public string AccountType { get; set; }
        
        [JsonProperty("currentValue")]
        public decimal CurrentValue { get; set; }
        
        [JsonProperty("ssN_TaxID")]
        public string SSN_TaxID { get; set; }
        
        [JsonProperty("dob")]
        public DateTime Dob { get; set; }
        
        [JsonProperty("clientId")]
        public int ClientId { get; set; }
        
        [JsonProperty("typeCode")]
        public string TypeCode { get; set; }
        
        [JsonProperty("typeId")]
        public int TypeId { get; set; }
        
        [JsonProperty("company")]
        public string Company { get; set; }
        
        [JsonProperty("jobTitle")]
        public string JobTitle { get; set; }
        
        [JsonProperty("gender")]
        public string Gender { get; set; }
        
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }
        
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        
        [JsonProperty("editedBy")]
        public string EditedBy { get; set; }
        
        [JsonProperty("editedDate")]
        public DateTime EditedDate { get; set; }
        
        [JsonProperty("riskBudget")]
        public int RiskBudget { get; set; }
        
        [JsonProperty("representativeName")]
        public string RepresentativeName { get; set; }
        
        [JsonProperty("representativeNumber")]
        public string RepresentativeNumber { get; set; }
        
        [JsonProperty("missingInformation")]
        public string MissingInformation { get; set; }
        
        [JsonProperty("returnObjective")]
        public string ReturnObjective { get; set; }
        
        [JsonProperty("investmentObjective")]
        public string InvestmentObjective { get; set; }
        
        [JsonProperty("timeHorizon")]
        public string TimeHorizon { get; set; }
        
        [JsonProperty("stockPercent")]
        public string StockPercent { get; set; }
        
        [JsonProperty("bondPercent")]
        public string BondPercent { get; set; }
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
