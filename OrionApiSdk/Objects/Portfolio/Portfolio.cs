using Newtonsoft.Json;
using System;

namespace OrionApiSdk.Objects.Portfolio
{

    public class Portfolio
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
        
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }
        
        [JsonProperty("editedDate")]
        public DateTime EditedDate { get; set; }
        
        [JsonProperty("editedBy")]
        public string EditedBy { get; set; }
        
        [JsonProperty("startDate")]
        public DateTime StartDate { get; set; }
        
        [JsonProperty("importKey")]
        public Guid? ImportKey { get; set; }
        
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
        
        
    }
}
