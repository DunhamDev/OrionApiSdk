using Newtonsoft.Json;
using OrionApiSdk.Objects.Abstract;
using System;
using System.Collections.Generic;

namespace OrionApiSdk.Objects.Trading
{

    public class Model : BaseSimpleEntity
    {
        [JsonProperty("lastRebalanced")]
        public DateTime? LastRebalanced { get; set; }
        
        [JsonProperty("fundName")]
        public string FundName { get; set; }
        
        [JsonProperty("editedBy")]
        public string EditedBy { get; set; }
        
        [JsonProperty("editedDate")]
        public DateTime EditedDate { get; set; }
        
        [JsonProperty("groupNum")]
        public string GroupNum { get; set; }
        
        [JsonProperty("subAdvisor")]
        public string SubAdvisor { get; set; }
        
        [JsonProperty("modelNum")]
        public int ModelNum { get; set; }
        
        [JsonProperty("percEquity")]
        public int PercEquity { get; set; }
        
        [JsonProperty("modelType")]
        public string ModelType { get; set; }
        
        [JsonProperty("fundList")]
        public string FundList { get; set; }
        
        [JsonProperty("modelTol")]
        public int ModelTol { get; set; }
        
        [JsonProperty("cashPerc")]
        public int CashPerc { get; set; }
        
        [JsonProperty("cashTol")]
        public int CashTol { get; set; }
        
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
        
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }
        
        [JsonProperty("class")]
        public string Class { get; set; }
        
        [JsonProperty("modelCode")]
        public string ModelCode { get; set; }
        
        [JsonProperty("managementStyle")]
        public string ManagementStyle { get; set; }
        
        [JsonProperty("notes")]
        public string Notes { get; set; }
        
        [JsonProperty("isDynamic")]
        public bool IsDynamic { get; set; }
        
        [JsonProperty("custodian")]
        public string Custodian { get; set; }
        
        [JsonProperty("subAdvisorId")]
        public int? SubAdvisorId { get; set; }
        
        [JsonProperty("useRestrictions")]
        public bool UseRestrictions { get; set; }

        [JsonProperty("items")]
        public List<ModelItem> Items { get; set; }

        [JsonProperty("accounts")]
        public List<ModelAccount> Accounts { get; set; }

        [JsonProperty("ranges")]
        public List<ModelRange> Ranges { get; set; }
    }
}
