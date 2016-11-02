using Newtonsoft.Json;
using System;

namespace OrionApiSdk.Objects.Portfolio
{
    public class BrokerDealerPortfolio : Portfolio
    {
        [JsonProperty("actgLedgerNum")]
        public string ActgLedgerNum { get; set; }
        
        [JsonProperty("advOneAgreeDate")]
        public DateTime? AdvOneAgreeDate { get; set; }
        
        [JsonProperty("advOneRestrictions")]
        public string AdvOneRestrictions { get; set; }
        
        [JsonProperty("advYear")]
        public int? AdvYear { get; set; }
        
        [JsonProperty("agentID")]
        public string AgentID { get; set; }
        
        [JsonProperty("agreeDate")]
        public DateTime? AgreeDate { get; set; }
        
        [JsonProperty("agreeRestrictions")]
        public string AgreeRestrictions { get; set; }
        
        [JsonProperty("albridgeID")]
        public int? AlbridgeID { get; set; }
        
        [JsonProperty("bdRepRestrict")]
        public string BdRepRestrict { get; set; }
        
        [JsonProperty("bdStatus")]
        public string BdStatus { get; set; }
        
        [JsonProperty("billPayoutScheduleId")]
        public int? BillPayoutScheduleId { get; set; }
        
        [JsonProperty("clsSendAdvTo")]
        public string ClsSendAdvTo { get; set; }
        
        [JsonProperty("registrationName")]
        public string RegistrationName { get; set; }
        
        [JsonProperty("crdNumber")]
        public string CrdNumber { get; set; }
        
        [JsonProperty("clearingFirm")]
        public string ClearingFirm { get; set; }
        
        [JsonProperty("dazlid")]
        public string Dazlid { get; set; }
        
        [JsonProperty("frequency")]
        public int Frequency { get; set; }
        
        [JsonProperty("howIsAdvRegistered")]
        public string HowIsAdvRegistered { get; set; }
        
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("impDate")]
        public DateTime? ImpDate { get; set; }
        
        [JsonProperty("isAdvOnFile")]
        public bool IsAdvOnFile { get; set; }
        
        [JsonProperty("isAdvOneAgree")]
        public bool IsAdvOneAgree { get; set; }
        
        [JsonProperty("isMktingMaterialSent")]
        public bool IsMktingMaterialSent { get; set; }
        
        [JsonProperty("isProductionReported")]
        public bool IsProductionReported { get; set; }
        
        [JsonProperty("isSendingQuestionaire")]
        public bool IsSendingQuestionaire { get; set; }
        
        [JsonProperty("marketingNotes")]
        public string MarketingNotes { get; set; }
        
        [JsonProperty("mktMaterialEmail")]
        public string MktMaterialEmail { get; set; }
        
        [JsonProperty("mktMaterialFax")]
        public string MktMaterialFax { get; set; }
        
        [JsonProperty("mktMaterialSendTo")]
        public string MktMaterialSendTo { get; set; }
        
        [JsonProperty("natConference")]
        public string NatConference { get; set; }
        
        [JsonProperty("oldBDCode")]
        public string OldBDCode { get; set; }
        
        [JsonProperty("oldBD_ID")]
        public int? OldBD_ID { get; set; }
        
        [JsonProperty("overideCode")]
        public string OverideCode { get; set; }
        
        [JsonProperty("overidePerc")]
        public decimal? OveridePerc { get; set; }
        
        [JsonProperty("payeeId")]
        public int PayeeId { get; set; }
        
        [JsonProperty("lName")]
        public string LName { get; set; }
        
        [JsonProperty("riaId")]
        public int? RiaId { get; set; }
    }
}