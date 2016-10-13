﻿using Newtonsoft.Json;
using OrionApiSdk.Objects.Abstract;
using System;
using System.Collections.Generic;

namespace OrionApiSdk.Objects.Trading
{
    public class ModelAgg : BaseSimpleEntity
    {
        [JsonProperty("isSystemMaintained")]
        public bool IsSystemMaintained { get; set; }
        
        [JsonProperty("accountNumberSuffix")]
        public string AccountNumberSuffix { get; set; }
        
        [JsonProperty("keepAlways")]
        public bool KeepAlways { get; set; }
        
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("createdDate")]
        public DateTime? CreatedDate { get; set; }

        [JsonProperty("editedBy")]
        public string EditedBy { get; set; }
        
        [JsonProperty("editedDate")]
        public DateTime? EditedDate { get; set; }
        
        [JsonProperty("entityId")]
        public int? EntityId { get; set; }
        
        [JsonProperty("entityEnum")]
        public string EntityEnum { get; set; }
        
        [JsonProperty("include")]
        public bool Include { get; set; }
        
        [JsonProperty("owned")]
        public bool Owned { get; set; }
        
        [JsonProperty("canMaintain")]
        public bool CanMaintain { get; set; }
        
        [JsonProperty("modelAggTypeId")]
        public int? ModelAggTypeId { get; set; }
        
        [JsonProperty("modelAggType")]
        public string ModelAggType { get; set; }

        [JsonProperty("accounts")]
        public List<Account> Accounts { get; set; }

        [JsonProperty("items")]
        public List<ModelItem> Items { get; set; }

        [JsonProperty("details")]
        public List<ModelAggDetail> Details { get; set; }

        [JsonProperty("entities")]
        public List<ModelAggEntity> Entities { get; set; }
    }

}