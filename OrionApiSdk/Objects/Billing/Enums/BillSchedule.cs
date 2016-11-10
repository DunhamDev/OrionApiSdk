using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects.Billing.Enums
{
    public enum BillSchedule
    {
        Undefined = 0,
        Fee = 1,
        Payout = 2,
        BDOveride = 4,
        Remainder = 5,
        PerformanceFee = 6,
        PerformancePayout = 7,
    }
}
