using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects.Global
{
    public class Product
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("productName")]
        public string ProductName { get; set; }
        
        [JsonProperty("ticker")]
        public string Ticker { get; set; }
        
        [JsonProperty("cusip")]
        public string Cusip { get; set; }
        
        [JsonProperty("currentOrionPrice")]
        public decimal CurrentOrionPrice { get; set; }
        
        [JsonProperty("currentOrionPriceDate")]
        public string CurrentOrionPriceDate { get; set; }
        
        [JsonProperty("productType")]
        public string ProductType { get; set; }
        
        [JsonProperty("productSubTypeName")]
        public string ProductSubTypeName { get; set; }
        
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        
        [JsonProperty("productSubTypeId")]
        public int? ProductSubTypeId { get; set; }
        
        [JsonProperty("shareClassId")]
        public int ShareClassId { get; set; }
        
        [JsonProperty("shareClassName")]
        public string ShareClassName { get; set; }
        
        [JsonProperty("shareClassDescription")]
        public string ShareClassDescription { get; set; }
        
        [JsonProperty("fundNumber")]
        public string FundNumber { get; set; }
        
        [JsonProperty("globalFundFamilyId")]
        public int GlobalFundFamilyId { get; set; }
        
        [JsonProperty("globalFundFamilyName")]
        public string GlobalFundFamilyName { get; set; }
        
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
        
        [JsonProperty("is144A")]
        public bool Is144A { get; set; }
        
        [JsonProperty("isUsePriceTime")]
        public bool IsUsePriceTime { get; set; }
        
        [JsonProperty("defaultPrice")]
        public decimal DefaultPrice { get; set; }
        
        [JsonProperty("expirationDate")]
        public DateTime? ExpirationDate { get; set; }
        
        [JsonProperty("priceStatus")]
        public string PriceStatus { get; set; }
        
        [JsonProperty("productParentId")]
        public int? ProductParentId { get; set; }
        
        [JsonProperty("productParentName")]
        public string ProductParentName { get; set; }
        
        [JsonProperty("repurchaseBlockDays")]
        public int RepurchaseBlockDays { get; set; }
        
        [JsonProperty("apcCode")]
        public string ApcCode { get; set; }
        
        [JsonProperty("shortTermTradeFeeDays")]
        public int? ShortTermTradeFeeDays { get; set; }
        
        [JsonProperty("shortTermTradeFeePercent")]
        public decimal? ShortTermTradeFeePercent { get; set; }
        
        [JsonProperty("editedDate")]
        public DateTime EditedDate { get; set; }
        
        [JsonProperty("editedBy")]
        public string EditedBy { get; set; }
        
        [JsonProperty("micropalCode")]
        public string MicropalCode { get; set; }
        
        [JsonProperty("estimatedDividendFrequency")]
        public decimal EstimatedDividendFrequency { get; set; }
        
        [JsonProperty("subHoldingId")]
        public int? SubHoldingId { get; set; }
        
        [JsonProperty("strikePrice")]
        public decimal StrikePrice { get; set; }
        
        [JsonProperty("optionLotSize")]
        public int OptionLotSize { get; set; }
    }
}
