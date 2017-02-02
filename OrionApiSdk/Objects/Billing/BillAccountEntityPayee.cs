using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects.Billing
{
    public class BillAccountEntityPayee
    {
        [JsonProperty("billEntityId")]
        public int BillEntityId { get; set; }

        [JsonProperty("PayeeId")]
        public int PayeeId { get; set; }

        [JsonProperty("payout")]
        public string Payout { get; set; }

        [JsonProperty("readOnly")]
        public bool ReadOnly { get; set; }
    }
}
