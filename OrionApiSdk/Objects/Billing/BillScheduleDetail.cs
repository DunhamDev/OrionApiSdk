using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects.Billing
{
    public class BillScheduleDetail
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("minimumAmount")]
        public decimal MinimumAmount { get; set; }

        [JsonProperty("maximumAmount")]
        public decimal MaximumAmount { get; set; }

        [JsonProperty("rate")]
        public decimal Rate { get; set; }

        [JsonProperty("points")]
        public decimal Points { get; set; }

        [JsonProperty("flatFee")]
        public decimal FlatFee { get; set; }
    }
}
