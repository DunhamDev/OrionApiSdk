using Newtonsoft.Json;
using OrionApiSdk.Objects.Abstract;
using OrionApiSdk.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects.Portfolio
{
    public class Client : BaseSimpleEntity, IUpdatable, ICreatable
    {
        #region Properties
        #region Instance properties
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("aum")]
        public decimal? Aum { get; set; }

        [JsonProperty("representativeName")]
        public string RepresentativeName { get; set; }

        [JsonProperty("representativeNumber")]
        public string RepresentativeNumber { get; set; }

        [JsonProperty("representativeId")]
        public int RepresentativeId { get; set; }

        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        [JsonProperty("statementDeliveryMethodId")]
        public int StatementDeliveryMethodId { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("statementDeliveryMethod")]
        public string StatementDeliveryMethod { get; set; }

        [JsonProperty("videoStatementDeliveryMethod")]
        public string VideoStatementDeliveryMethod { get; set; }

        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("editedBy")]
        public string EditedBy { get; set; }

        [JsonProperty("editedDate")]
        public DateTime EditedDate { get; set; }

        [JsonProperty("startDate")]
        public string StartDate { get; set; }

        [JsonProperty("importKey")]
        public string ImportKey { get; set; }

        [JsonProperty("lastStatementSent")]
        public DateTime? LastStatementSent { get; set; }

        [JsonProperty("lastStatementSentTo")]
        public string LastStatementSentTo { get; set; }

        [JsonProperty("additionalAccounts")]
        public int AdditionalAccounts { get; set; }

        [JsonProperty("missingInformation")]
        public string MissingInformation { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("homePhone")]
        public string HomePhone { get; set; }

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
        public string SsN_TaxID { get; set; }

        [JsonProperty("personalId")]
        public int PersonalId { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("dob")]
        public string Dob { get; set; }

        [JsonProperty("webAddress")]
        public string WebAddress { get; set; }

        [JsonProperty("homePhoneExt")]
        public string HomePhoneExt { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("riskScore")]
        public decimal? RiskScore { get; set; }
        #endregion
        #endregion

        #region Methods
        #region Public methods
        public void CheckNecessaryDataForUpdate()
        {
            throw new NotImplementedException();
        }

        public void CheckNecessaryDataForCreate()
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
    }
}
