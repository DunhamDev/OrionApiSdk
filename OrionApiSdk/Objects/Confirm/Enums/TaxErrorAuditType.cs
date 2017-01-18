using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects.Confirm.Enums
{
    public enum TaxErrorAuditType
    {
        CustodialRealizedSharesDoNotMatch = 1,
        CustodialRealizedMissing,
        CustodialUnrealizedMissing,
        CustodialRealizedUnknownAcquiredDate,
        CustodialUnrealizedUnknownAcquiredDate,
        CustodialRealizedUnknownCostBasis,
        CustodialUnrealizedUnknownCostBasis,
        OrionUnknownCostBasis,
        MoneyMarketProducts,
        OrionMissingCostBasis,
    }
}
