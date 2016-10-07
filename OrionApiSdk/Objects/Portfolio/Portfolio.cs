using Newtonsoft.Json;
using OrionApiSdk.Objects.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects.Portfolio
{

    public class Portfolio : BaseSimpleEntity
    {
        [JsonProperty("brokerDealerId")]
        public int BrokerDealerId { get; set; }
        
        [JsonProperty("wholesalerId")]
        public int WholesalerId { get; set; }
        
        [JsonProperty("payeeId")]
        public int PayeeId { get; set; }
        
        [JsonProperty("riaId")]
        public int RiaId { get; set; }
        
        [JsonProperty("wholesaler401KId")]
        public int? Wholesaler401KId { get; set; }
        
        [JsonProperty("planAdministratorId")]
        public int? PlanAdministratorId { get; set; }
        
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        
        [JsonProperty("copyToRep")]
        public bool CopyToRep { get; set; }
        
        [JsonProperty("isria")]
        public bool Isria { get; set; }
        
        [JsonProperty("riaName")]
        public string RiaName { get; set; }
        
        [JsonProperty("royalTCode")]
        public string RoyalTCode { get; set; }
        
        [JsonProperty("hasADV")]
        public bool HasADV { get; set; }
        
        [JsonProperty("hasU4")]
        public bool HasU4 { get; set; }
        
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
        
        [JsonProperty("isDstDwnld")]
        public bool IsDstDwnld { get; set; }
        
        [JsonProperty("branchID")]
        public string BranchID { get; set; }
        
        [JsonProperty("oldRep_ID")]
        public int? OldRep_ID { get; set; }
        
        [JsonProperty("number")]
        public string Number { get; set; }
        
        [JsonProperty("impDate")]
        public DateTime ImpDate { get; set; }
        
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }
        
        [JsonProperty("editedDate")]
        public DateTime EditedDate { get; set; }
        
        [JsonProperty("editedBy")]
        public string EditedBy { get; set; }
        
        [JsonProperty("startDate")]
        public DateTime StartDate { get; set; }
        
        [JsonProperty("repStatus")]
        public string RepStatus { get; set; }
        
        [JsonProperty("firmName")]
        public string FirmName { get; set; }
        
        [JsonProperty("actgLedgerNum")]
        public string ActgLedgerNum { get; set; }
        
        [JsonProperty("isDefault")]
        public bool IsDefault { get; set; }
        
        [JsonProperty("importKey")]
        public Guid? ImportKey { get; set; }
        
        [JsonProperty("raAmount")]
        public decimal? RaAmount { get; set; }
        
        [JsonProperty("raDate")]
        public DateTime? RaDate { get; set; }
        
        [JsonProperty("israActive")]
        public bool? IsRaActive { get; set; }
        
        [JsonProperty("repRestrict")]
        public string RepRestrict { get; set; }
        
        [JsonProperty("salutation")]
        public string Salutation { get; set; }
        
        [JsonProperty("address1")]
        public string Address1 { get; set; }
        
        [JsonProperty("address2")]
        public string Address2 { get; set; }
        
        [JsonProperty("address3")]
        public string Address3 { get; set; }
        
        [JsonProperty("zip")]
        public string Zip { get; set; }
        
        [JsonProperty("homePhone")]
        public string HomePhone { get; set; }
        
        [JsonProperty("homePhoneExt")]
        public string HomePhoneExt { get; set; }
        
        [JsonProperty("fax")]
        public string Fax { get; set; }
        
        [JsonProperty("faxExt")]
        public string FaxExt { get; set; }
        
        [JsonProperty("pager")]
        public string Pager { get; set; }
        
        [JsonProperty("pagerExt")]
        public string PagerExt { get; set; }
        
        [JsonProperty("mobilePhone")]
        public string MobilePhone { get; set; }
        
        [JsonProperty("businessPhone")]
        public string BusinessPhone { get; set; }
        
        [JsonProperty("businessPhoneExt")]
        public string BusinessPhoneExt { get; set; }
        
        [JsonProperty("otherPhone")]
        public string OtherPhone { get; set; }
        
        [JsonProperty("otherPhoneExt")]
        public string OtherPhoneExt { get; set; }
        
        [JsonProperty("reportName")]
        public string ReportName { get; set; }
        
        [JsonProperty("company")]
        public string Company { get; set; }
        
        [JsonProperty("jobTitle")]
        public string JobTitle { get; set; }
        
        [JsonProperty("ssN_TaxID")]
        public string SSN_TaxID { get; set; }
        
        [JsonProperty("gender")]
        public string Gender { get; set; }
        
        [JsonProperty("dob")]
        public DateTime? DoB { get; set; }
        
        [JsonProperty("webAddress")]
        public string WebAddress { get; set; }
        
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        
        [JsonProperty("city")]
        public string City { get; set; }
        
        [JsonProperty("state")]
        public string State { get; set; }
        
        [JsonProperty("email")]
        public string Email { get; set; }
        
        [JsonProperty("repNasds")]
        public List<RepNasd> RepNasds { get; set; }
        
        [JsonProperty("repOnHolds")]
        public List<RepOnHold> RepOnHolds { get; set; }
        
        [JsonProperty("repStates")]
        public List<RepState> RepStates { get; set; }
    }
}
