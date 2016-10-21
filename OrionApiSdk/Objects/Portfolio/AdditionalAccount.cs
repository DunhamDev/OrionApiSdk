using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects.Portfolio
{
    public class AdditionalAccount
    {
        [JsonProperty("accountId")]
        public int AccountId { get; set; }
        
        [JsonProperty("registration")]
        public string Registration { get; set; }
        
        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }
        
        [JsonProperty("type")]
        public int Type { get; set; }
        
        [JsonProperty("typeName")]
        public string TypeName { get; set; }
        
        [JsonProperty("fundFamily")]
        public int FundFamily { get; set; }
        
        [JsonProperty("fundFamilyName")]
        public string FundFamilyName { get; set; }
        
        [JsonProperty("custodian")]
        public int Custodian { get; set; }
        
        [JsonProperty("custodianName")]
        public string CustodianName { get; set; }
        
        [JsonProperty("managementStyle")]
        public int ManagementStyle { get; set; }
        
        [JsonProperty("managementStyleName")]
        public string ManagementStyleName { get; set; }
        
        [JsonProperty("model")]
        public int Model { get; set; }
        
        [JsonProperty("modelName")]
        public string ModelName { get; set; }
    }
}
