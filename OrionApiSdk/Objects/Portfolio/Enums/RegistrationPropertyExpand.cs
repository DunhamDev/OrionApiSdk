using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects.Portfolio.Enums
{
    public enum RegistrationPropertyExpand
    {
        None = 0,
        Portfolio = 1,
        Notes = 2,
        Beneficiaries = 4,
        Suitability = 8,
        UserDefinedFields = 16,
        EntityOptions = 32,
        All = 63
    }
}
