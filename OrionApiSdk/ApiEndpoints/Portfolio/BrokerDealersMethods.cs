using OrionApiSdk.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Portfolio
{
    public class BrokerDealersMethods : ApiMethodContainer
    {
        public BrokerDealersMethods(AuthToken token) : base("Portfolio", "BrokerDealers", token) { }
    }
}
