using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects.Portfolio.Enums
{
    public enum FinancialType
    {
        None = 0,
        Contribution,
        Distribution,
        Exchange = 4,
        DivReinvest,
        MgmntFees,
        DivCash,
        MiscFees = 10,
        Journal,
        Merges
    }
}
