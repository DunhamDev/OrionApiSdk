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
    public class BrokerDealerVerbose : BaseSimpleEntity, ICreatable, IUpdatable
    {
        [JsonProperty("portfolio")]
        public BrokerDealerPortfolio Portfolio { get; set; }

        [JsonProperty("notes")]
        public List<Note> Notes { get; set; }

        [JsonProperty("documents")]
        public List<Document> Documents { get; set; }

        [JsonProperty("additionalContacts")]
        public List<BrokerDealerAdditionalContact> AdditionalContacts { get; set; }

        [JsonProperty("reportImage")]
        public BrokerDealerReportImage ReportImage { get; set; }

        public void CheckNecessaryDataForCreate()
        {
            throw new NotImplementedException();
        }

        public void CheckNecessaryDataForUpdate()
        {
            throw new NotImplementedException();
        }
    }
}
