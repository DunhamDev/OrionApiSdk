using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects.Trading
{
    public class Account
    {
        [JsonProperty("accountId")]
        public int AccountId { get; set; }
        
        [JsonProperty("accountName")]
        public string AccountName { get; set; }
        
        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }
        
        [JsonProperty("canDelete")]
        public bool CanDelete { get; set; }
        
        [JsonProperty("lastRebalanced")]
        public DateTime? LastRebalanced { get; set; }
        
        [JsonProperty("editedDate")]
        public DateTime EditedDate { get; set; }
        
        [JsonProperty("editedBy")]
        public string EditedBy { get; set; }
        
        [JsonProperty("value")]
        public decimal Value { get; set; }
        
        [JsonProperty("modelId")]
        public int ModelId { get; set; }
    }
}
