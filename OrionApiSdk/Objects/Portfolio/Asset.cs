using Newtonsoft.Json;
using OrionApiSdk.Objects.Abstract;
using System;

namespace OrionApiSdk.Objects.Portfolio
{
    public class Asset : BaseSimpleEntity
    { 
        [JsonProperty("costBasis")]
        public decimal? CostBasis { get; set; }
        
        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }
        
        [JsonProperty("ticker")]
        public string Ticker { get; set; }
        
        [JsonProperty("currentShares")]
        public decimal CurrentShares { get; set; }
        
        [JsonProperty("currentValue")]
        public decimal CurrentValue { get; set; }
        
        [JsonProperty("currentPrice")]
        public decimal CurrentPrice { get; set; }
        
        [JsonProperty("isManaged")]
        public bool IsManaged { get; set; }
        
        [JsonProperty("assetClass")]
        public string AssetClass { get; set; }
        
        [JsonProperty("productCategory")]
        public string ProductCategory { get; set; }
        
        [JsonProperty("productCategoryAbbreviation")]
        public string ProductCategoryAbbreviation { get; set; }
        
        [JsonProperty("isCustodialCash")]
        public bool IsCustodialCash { get; set; }
        
        [JsonProperty("secondaryAccountNumber")]
        public string SecondaryAccountNumber { get; set; }
        
        [JsonProperty("productId")]
        public int ProductId { get; set; }
        
        [JsonProperty("assetLevelStrategyId")]
        public int? AssetLevelStrategyId { get; set; }
        
        [JsonProperty("assetLevelStrategy")]
        public string AssetLevelStrategy { get; set; }
        
        [JsonProperty("status")]
        public int Status { get; set; }
        
        [JsonProperty("isStrategyOverride")]
        public bool IsStrategyOverride { get; set; }
        
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }
        
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        
        [JsonProperty("editedBy")]
        public string EditedBy { get; set; }
        
        [JsonProperty("editedDate")]
        public DateTime EditedDate { get; set; }
        
        [JsonProperty("accountId")]
        public int AccountId { get; set; }
        
        [JsonProperty("registrationId")]
        public int RegistrationId { get; set; }
        
        [JsonProperty("clientId")]
        public int ClientId { get; set; }
        
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
        
        [JsonProperty("downloadSymbol")]
        public int DownloadSymbol { get; set; }
        
        [JsonProperty("accountType")]
        public string AccountType { get; set; }
        
        [JsonProperty("fundFamily")]
        public string FundFamily { get; set; }
        
        [JsonProperty("custodian")]
        public string Custodian { get; set; }
        
        [JsonProperty("asOfDate")]
        public DateTime? AsOfDate { get; set; }
        
        [JsonProperty("registrationName")]
        public string RegistrationName { get; set; }
        
        [JsonProperty("managementStyle")]
        public string ManagementStyle { get; set; }
        
        [JsonProperty("productType")]
        public string ProductType { get; set; }
        
        [JsonProperty("isFeeExcluded")]
        public bool IsFeeExcluded { get; set; }
        
        [JsonProperty("excludeAmountType")]
        public string ExcludeAmountType { get; set; }
        
        [JsonProperty("excludeAmount")]
        public decimal ExcludeAmount { get; set; }
        
        [JsonProperty("excludePercentOf")]
        public string ExcludePercentOf { get; set; }
        
        [JsonProperty("isRebalance")]
        public bool IsRebalance { get; set; }
        
        [JsonProperty("lastReconDate")]
        public DateTime? LastReconDate { get; set; }
    }

}
