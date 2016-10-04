using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiLibrary.Objects.Enums
{
    public enum LoginEntity
    {
        Unknown = 0,
        BrokerDealer = 1,
        Wholesaler = 2,
        Representative = 3,
        Household = 4,
        Advisor = 5,
        Administrator = 6,
        SubAdvisor = 7,
        ThirdPartyAdministrator = 13,
        Custodian = 14,
        PlanSponsor = 16,
        ThirdParty = 17,
        ServiceAccount = 18,
        Participant = 19,
        RepAccountManager = 20,
        Payee = 23,
    }
}
