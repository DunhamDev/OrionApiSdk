using OrionApiSdk.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Trading
{
    public class TradingEndpoint : ApiEndpointBase
    {
        public TradingEndpoint(AuthToken token) : base("Trading", token) { }

        private ModelsMethods _modelsMethods;
        public ModelsMethods Models
        {
            get
            {
                return _modelsMethods ?? (_modelsMethods = new ModelsMethods(AuthToken));
            }
        }

        private ModelAggsMethods _modelAggsMethods;
        public ModelAggsMethods ModelAggs
        {
            get
            {
                return _modelAggsMethods ?? (_modelAggsMethods = new ModelAggsMethods(AuthToken));
            }
        }
    }
}
