﻿using Newtonsoft.Json;

namespace OrionApiSdk.Objects.Portfolio
{
    public class BillRepresentativePlatform
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("billFeeScheduleId")]
        public int BillFeeScheduleId { get; set; }
        
        [JsonProperty("platformId")]
        public int PlatformId { get; set; }
        
        [JsonProperty("billMasterPayoutScheduleId")]
        public int BillMasterPayoutScheduleId { get; set; }
    }
}
