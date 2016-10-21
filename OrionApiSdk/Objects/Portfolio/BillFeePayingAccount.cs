using Newtonsoft.Json;

namespace OrionApiSdk.Objects.Portfolio
{
    public class BillFeePayingAccount
    {
        [JsonProperty("accountId")]
        public int AccountId { get; set; }
        
        [JsonProperty("registration")]
        public string Registration { get; set; }
        
        [JsonProperty("accountType")]
        public string AccountType { get; set; }
        
        [JsonProperty("managementStyle")]
        public string ManagementStyle { get; set; }
        
        [JsonProperty("custodian")]
        public string Custodian { get; set; }
        
        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }
        
        [JsonProperty("active")]
        public bool Active { get; set; }
        
        [JsonProperty("payPercent")]
        public decimal PayPercent { get; set; }
    }
}
