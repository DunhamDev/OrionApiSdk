using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects.Portfolio
{
    public class HouseholdMember
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("type")]
        public string Type { get; set; }
        
        [JsonProperty("salutation")]
        public string Salutation { get; set; }
        
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        
        [JsonProperty("fullName")]
        public string FullName { get; set; }
        
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
        
        [JsonProperty("email")]
        public string Email { get; set; }
        
        [JsonProperty("ssN_TaxID")]
        public string SsN_TaxID { get; set; }
        
        [JsonProperty("gender")]
        public string Gender { get; set; }
        
        [JsonProperty("dob")]
        public DateTime? Dob { get; set; }
        
        [JsonProperty("webAddress")]
        public string WebAddress { get; set; }

        [JsonProperty("additionalAddresses")]
        public List<HouseholdMemberAdditionalAddress> AdditionalAddresses { get; set; }
    }
}
