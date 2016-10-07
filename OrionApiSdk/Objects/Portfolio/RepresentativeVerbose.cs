using Newtonsoft.Json;
using OrionApiSdk.Objects.Abstract;
using System.Collections.Generic;

namespace OrionApiSdk.Objects.Portfolio
{

    public class RepresentativeVerbose : BaseSimpleEntity
    {
        [JsonProperty("portfolio")]
        public Portfolio Portfolio { get; set; }
        
        [JsonProperty("notes")]
        public List<Note> Notes { get; set; }
        
        [JsonProperty("documents")]
        public List<Document> Documents { get; set; }
        
        [JsonProperty("billRepresentativePlatforms")]
        public List<BillRepresentativePlatform> BillRepresentativePlatforms { get; set; }
        
        [JsonProperty("reportImage")]
        public ReportImage ReportImage { get; set; }
        
        [JsonProperty("userDefinedFields")]
        public List<object> UserDefinedFields { get; set; }
        
        [JsonProperty("entityOptions")]
        public List<object> EntityOptions { get; set; }
    }
}
