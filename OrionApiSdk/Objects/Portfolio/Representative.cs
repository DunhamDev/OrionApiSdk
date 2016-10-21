using Newtonsoft.Json;
using OrionApiSdk.Objects.Abstract;
using OrionApiSdk.Objects.Interfaces;
using System;

namespace OrionApiSdk.Objects.Portfolio
{
    public class Representative : BaseSimpleEntity, IUpdatable, ICreatable
    {
        #region Properties
        #region Instance properties
        [JsonProperty("repNo")]
        public string RepNo { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("addressLine1")]
        public string AddressLine1 { get; set; }

        [JsonProperty("addressLine2")]
        public string AddressLine2 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("mobilePhoneNumber")]
        public string MobilePhoneNumber { get; set; }

        [JsonProperty("faxNumber")]
        public string FaxNumber { get; set; }

        [JsonProperty("brokerDealer")]
        public string BrokerDealer { get; set; }

        [JsonProperty("businessPhoneNumber")]
        public string BusinessPhoneNumber { get; set; }

        [JsonProperty("households")]
        public int Households { get; set; }

        [JsonProperty("value")]
        public decimal Value { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("accountingLedgerNo")]
        public string AccountingLedgerNo { get; set; }

        [JsonProperty("branch")]
        public string Branch { get; set; }

        [JsonProperty("copyToRep")]
        public bool CopyToRep { get; set; }

        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("_default")]
        public bool _default { get; set; }

        [JsonProperty("destinationDownload")]
        public bool DestinationDownload { get; set; }

        [JsonProperty("editedBy")]
        public string EditedBy { get; set; }

        [JsonProperty("editedDate")]
        public DateTime? EditedDate { get; set; }

        [JsonProperty("firmName")]
        public string FirmName { get; set; }

        [JsonProperty("hasADV")]
        public bool HasADV { get; set; }

        [JsonProperty("hasU4")]
        public bool HasU4 { get; set; }

        [JsonProperty("importKey")]
        public Guid? ImportKey { get; set; }

        [JsonProperty("payee")]
        public int Payee { get; set; }

        [JsonProperty("planAdministrator")]
        public int? PlanAdministrator { get; set; }

        [JsonProperty("raActive")]
        public bool? RaActive { get; set; }

        [JsonProperty("raAmount")]
        public decimal? RaAmount { get; set; }

        [JsonProperty("raDate")]
        public DateTime? RaDate { get; set; }

        [JsonProperty("repRestriction")]
        public string RepRestriction { get; set; }

        [JsonProperty("riaId")]
        public int RiaId { get; set; }

        [JsonProperty("riaName")]
        public string RiaName { get; set; }

        [JsonProperty("royalTCode")]
        public string RoyalTCode { get; set; }

        [JsonProperty("startDate")]
        public DateTime StartDate { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("wholeSaler")]
        public string WholeSaler { get; set; }
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
