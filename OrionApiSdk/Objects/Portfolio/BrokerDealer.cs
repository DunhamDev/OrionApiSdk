using Newtonsoft.Json;
using OrionApiSdk.Objects.Abstract;
using OrionApiSdk.Objects.Interfaces;
using System;

namespace OrionApiSdk.Objects.Portfolio
{
    public class BrokerDealer : BaseSimpleEntity, IUpdatable, ICreatable
    {
        #region Properties
        #region Instance properties
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
        
        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("crdNumber")]
        public string CrdNumber { get; set; }
        
        [JsonProperty("clearingFirm")]
        public string ClearingFirm { get; set; }
        
        [JsonProperty("ledgerNumber")]
        public string LedgerNumber { get; set; }
        
        [JsonProperty("albridgeId")]
        public int? AlbridgeId { get; set; }
        
        [JsonProperty("value")]
        public float Value { get; set; }
        
        [JsonProperty("dazlId")]
        public string DazlId { get; set; }
        
        [JsonProperty("agreementDate")]
        public DateTime? AgreementDate { get; set; }
        
        [JsonProperty("agreementRestriction")]
        public string AgreementRestriction { get; set; }
        
        [JsonProperty("advisorOneDate")]
        public DateTime? AdvisorOneDate { get; set; }
        
        [JsonProperty("advisorOneAgree")]
        public bool AdvisorOneAgree { get; set; }
        
        [JsonProperty("advisorOneRestriction")]
        public bool? AdvisorOneRestriction { get; set; }
        
        [JsonProperty("restriction")]
        public string Restriction { get; set; }
        
        [JsonProperty("repCount")]
        public int RepCount { get; set; }
        
        [JsonProperty("agentId")]
        public string AgentId { get; set; }
        
        [JsonProperty("bdCode")]
        public string BdCode { get; set; }
        
        [JsonProperty("advOnFile")]
        public bool AdvOnFile { get; set; }
        
        [JsonProperty("advYear")]
        public int? AdvYear { get; set; }
        
        [JsonProperty("clsSendAdvTo")]
        public string ClsSendAdvTo { get; set; }
        
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }
        
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        
        [JsonProperty("editedBy")]
        public string EditedBy { get; set; }
        
        [JsonProperty("editedDate")]
        public DateTime EditedDate { get; set; }
        
        [JsonProperty("frequency")]
        public int Frequency { get; set; }
        
        [JsonProperty("howAdvRegistered")]
        public string HowAdvRegistered { get; set; }
        
        [JsonProperty("marketingNotes")]
        public string MarketingNotes { get; set; }
        
        [JsonProperty("mktgMaterialEmail")]
        public string MktgMaterialEmail { get; set; }
        
        [JsonProperty("mktgMaterialFax")]
        public string MktgMaterialFax { get; set; }
        
        [JsonProperty("mktgMaterialSendTo")]
        public string MktgMaterialSendTo { get; set; }
        
        [JsonProperty("nationalConference")]
        public string NationalConference { get; set; }
        
        [JsonProperty("overrideCode")]
        public string OverrideCode { get; set; }
        
        [JsonProperty("overridePercent")]
        public decimal? OverridePercent { get; set; }
        
        [JsonProperty("productReported")]
        public bool ProductReported { get; set; }
        
        [JsonProperty("regionalConference")]
        public string RegionalConference { get; set; }
        
        [JsonProperty("repListReceiveDate")]
        public DateTime? RepListReceiveDate { get; set; }
        
        [JsonProperty("reportsEmail")]
        public string ReportsEmail { get; set; }
        
        [JsonProperty("reportsFax")]
        public string ReportsFax { get; set; }
        
        [JsonProperty("reportsSendTo")]
        public string ReportsSendTo { get; set; }
        
        [JsonProperty("sendingQuestionare")]
        public bool SendingQuestionare { get; set; }
        
        [JsonProperty("transmissionFormat")]
        public int TransmissionFormat { get; set; }
        
        [JsonProperty("transmissionMethod")]
        public int TransmissionMethod { get; set; }
        #endregion
        #endregion

        #region Methods
        #region Public methods
        public void CheckNecessaryDataForUpdate()
        {
            throw new NotImplementedException();
        }

        public void CheckNecessaryDataForCreate()
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
    }
}
