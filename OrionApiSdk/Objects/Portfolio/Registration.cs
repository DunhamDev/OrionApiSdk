using OrionApiSdk.Objects.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects.Portfolio
{
    public class Registration : BaseSimpleEntity
    {
        public bool isActive { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string accountType { get; set; }
        public int currentValue { get; set; }
        public object ssN_TaxID { get; set; }
        public string dob { get; set; }
        public int clientId { get; set; }
        public string typeCode { get; set; }
        public int typeId { get; set; }
        public object company { get; set; }
        public object jobTitle { get; set; }
        public object gender { get; set; }
        public string createdBy { get; set; }
        public DateTime createdDate { get; set; }
        public string editedBy { get; set; }
        public DateTime editedDate { get; set; }
        public object riskBudget { get; set; }
        public string representativeName { get; set; }
        public string representativeNumber { get; set; }
        public string missingInformation { get; set; }
        public object returnObjective { get; set; }
        public object investmentObjective { get; set; }
        public object timeHorizon { get; set; }
        public object stockPercent { get; set; }
        public object bondPercent { get; set; }
    }

}
