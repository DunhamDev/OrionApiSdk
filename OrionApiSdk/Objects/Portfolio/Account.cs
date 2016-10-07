using Newtonsoft.Json;

namespace OrionApiSdk.Objects.Portfolio
{
    public class Account
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("number")]
        public string Number { get; set; }
        
        [JsonProperty("custodian")]
        public string Custodian { get; set; }
        
        [JsonProperty("accountType")]
        public string AccountType { get; set; }
        
        [JsonProperty("managementStyle")]
        public string ManagementStyle { get; set; }
        
        [JsonProperty("modelName")]
        public string ModelName { get; set; }
        
        [JsonProperty("currentValue")]
        public double? CurrentValue { get; set; }
        
        [JsonProperty("fundFamily")]
        public string FundFamily { get; set; }
        
        [JsonProperty("accountStartValue")]
        public double? AccountStartValue { get; set; }
        
        [JsonProperty("createdDate")]
        public string CreatedDate { get; set; }
        
        [JsonProperty("isManaged")]
        public bool IsManaged { get; set; }
        
        [JsonProperty("isSweepAccount")]
        public bool IsSweepAccount { get; set; }
        
        [JsonProperty("importKey")]
        public string ImportKey { get; set; }
        
        [JsonProperty("outsideId")]
        public string OutsideId { get; set; }
        
        [JsonProperty("secondaryAccountNumber")]
        public string SecondaryAccountNumber { get; set; }
        
        [JsonProperty("managementStyleId")]
        public int? ManagementStyleId { get; set; }
        
        [JsonProperty("fundFamilyId")]
        public int FundFamilyId { get; set; }
        
        [JsonProperty("accountHistoryId")]
        public int? AccountHistoryId { get; set; }
        
        [JsonProperty("registrationId")]
        public int RegistrationId { get; set; }
        
        [JsonProperty("clientId")]
        public int ClientId { get; set; }
        
        [JsonProperty("custodianId")]
        public int? CustodianId { get; set; }
        
        [JsonProperty("shareClass")]
        public string ShareClass { get; set; }
        
        [JsonProperty("shareClassId")]
        public int? ShareClassId { get; set; }
        
        [JsonProperty("subAdvisor")]
        public string SubAdvisor { get; set; }
        
        [JsonProperty("subAdvisorId")]
        public int? SubAdvisorId { get; set; }
        
        [JsonProperty("provider")]
        public string Provider { get; set; }
        
        [JsonProperty("plan")]
        public int? Plan { get; set; }
        
        [JsonProperty("modelGroupNumber")]
        public string ModelGroupNumber { get; set; }
        
        [JsonProperty("isTradingBlocked")]
        public bool? IsTradingBlocked { get; set; }
        
        [JsonProperty("tradingInstructions")]
        public string TradingInstructions { get; set; }
        
        [JsonProperty("downloadSource")]
        public string DownloadSource { get; set; }
        
        [JsonProperty("businessLine")]
        public string BusinessLine { get; set; }
        
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }
        
        [JsonProperty("accountStartDate")]
        public string AccountStartDate { get; set; }
        
        [JsonProperty("editedBy")]
        public string EditedBy { get; set; }
        
        [JsonProperty("editedDate")]
        public string EditedDate { get; set; }
        
        [JsonProperty("accountStatusId")]
        public int? AccountStatusId { get; set; }
        
        [JsonProperty("accountStatusDescription")]
        public string AccountStatusDescription { get; set; }
        
        [JsonProperty("feeScheduleId")]
        public int? FeeScheduleId { get; set; }
        
        [JsonProperty("feeSchedule")]
        public string FeeSchedule { get; set; }
        
        [JsonProperty("masterPayoutScheduleId")]
        public int? MasterPayoutScheduleId { get; set; }
        
        [JsonProperty("masterPayoutSchedule")]
        public string MasterPayoutSchedule { get; set; }

        [JsonProperty("isQualified")]
        public bool? IsQualified { get; set; }

        [JsonProperty("riskScore")]
        public decimal? RiskScore { get; set; }
    }
}
