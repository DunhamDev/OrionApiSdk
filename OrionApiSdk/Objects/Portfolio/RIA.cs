using Newtonsoft.Json;
using OrionApiSdk.Objects.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects.Portfolio
{

    public class RIA : BaseSimpleEntity
    {
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("fiscalStartDate")]
        public string FiscalStartDate { get; set; }
        
        [JsonProperty("fiscalEndDate")]
        public string FiscalEndDate { get; set; }
        
        [JsonProperty("payeeId")]
        public int PayeeId { get; set; }
        
        [JsonProperty("billingStyle")]
        public int BillingStyle { get; set; }
        
        [JsonProperty("isSolicitor")]
        public bool IsSolicitor { get; set; }
        
        [JsonProperty("isDefault")]
        public bool IsDefault { get; set; }
        
        [JsonProperty("importKey")]
        public Guid? ImportKey { get; set; }
        
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }
        
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        
        [JsonProperty("editedBy")]
        public string EditedBy { get; set; }
        
        [JsonProperty("editedDate")]
        public DateTime EditedDate { get; set; }
        
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        
        [JsonProperty("entityName")]
        public string EntityName { get; set; }
        
        [JsonProperty("email")]
        public string Email { get; set; }
        
        [JsonProperty("city")]
        public string City { get; set; }
        
        [JsonProperty("state")]
        public string State { get; set; }
        
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
        
        [JsonProperty("fax")]
        public string Fax { get; set; }
        
        [JsonProperty("faxExt")]
        public string FaxExt { get; set; }
        
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
        
        [JsonProperty("company")]
        public string Company { get; set; }
        
        [JsonProperty("jobTitle")]
        public string JobTitle { get; set; }
        
        [JsonProperty("webAddress")]
        public string WebAddress { get; set; }
    }

}
