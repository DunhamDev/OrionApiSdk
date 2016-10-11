using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects.Portfolio
{
    public class AumOverTime
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("grouping")]
        public int Grouping { get; set; }

        [JsonProperty("asOfDate")]
        public DateTime AsOfDate { get; set; }

        [JsonProperty("value")]
        public decimal Value { get; set; }
    }
}
