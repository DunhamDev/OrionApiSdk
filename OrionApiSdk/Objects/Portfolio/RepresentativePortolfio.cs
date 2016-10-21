using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace OrionApiSdk.Objects.Portfolio
{
    public class RepresentativePortolfio : Portfolio
    {
        [JsonProperty("actgLedgerNum")]
        public string ActgLedgerNum { get; set; }

        [JsonProperty("branchID")]
        public string BranchID { get; set; }

        [JsonProperty("brokerDealerId")]
        public int BrokerDealerId { get; set; }

        [JsonProperty("copyToRep")]
        public bool CopyToRep { get; set; }

        [JsonProperty("firmName")]
        public string FirmName { get; set; }

        [JsonProperty("hasADV")]
        public bool HasADV { get; set; }

        [JsonProperty("hasU4")]
        public bool HasU4 { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("impDate")]
        public DateTime ImpDate { get; set; }

        [JsonProperty("isDefault")]
        public bool IsDefault { get; set; }

        [JsonProperty("isDstDwnld")]
        public bool IsDstDwnld { get; set; }

        [JsonProperty("israActive")]
        public bool? IsRaActive { get; set; }

        [JsonProperty("isria")]
        public bool Isria { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("oldRep_ID")]
        public int? OldRep_ID { get; set; }

        [JsonProperty("payeeId")]
        public int PayeeId { get; set; }

        [JsonProperty("planAdministratorId")]
        public int? PlanAdministratorId { get; set; }

        [JsonProperty("raAmount")]
        public decimal? RaAmount { get; set; }

        [JsonProperty("raDate")]
        public DateTime? RaDate { get; set; }

        [JsonProperty("repNasds")]
        public List<RepNasd> RepNasds { get; set; }

        [JsonProperty("repOnHolds")]
        public List<RepOnHold> RepOnHolds { get; set; }

        [JsonProperty("repRestrict")]
        public string RepRestrict { get; set; }

        [JsonProperty("repStates")]
        public List<RepState> RepStates { get; set; }

        [JsonProperty("repStatus")]
        public string RepStatus { get; set; }

        [JsonProperty("riaId")]
        public int RiaId { get; set; }

        [JsonProperty("riaName")]
        public string RiaName { get; set; }

        [JsonProperty("royalTCode")]
        public string RoyalTCode { get; set; }

        [JsonProperty("wholesaler401KId")]
        public int? Wholesaler401KId { get; set; }

        [JsonProperty("wholesalerId")]
        public int WholesalerId { get; set; }
    }
}
