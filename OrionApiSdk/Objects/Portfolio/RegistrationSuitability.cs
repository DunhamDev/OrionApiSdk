using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects.Portfolio
{
    public class RegistrationSuitability
    {
        [JsonProperty("netWorthIncludingResidence")]
        public decimal NetWorthIncludingResidence { get; set; }

        [JsonProperty("netWorthExcludingResidence")]
        public decimal NetWorthExcludingResidence { get; set; }

        [JsonProperty("liquidNetWorth")]
        public decimal LiquidNetWorth { get; set; }

        [JsonProperty("investmentKnowledge")]
        public string InvestmentKnowledege { get; set; }

        [JsonProperty("riskExposure")]
        public string RiskExposure { get; set; }

        [JsonProperty("investmentExperience")]
        public string InvestmentExperience { get; set; }

        [JsonProperty("returnObjective")]
        public string ReturnObjective { get; set; }

        [JsonProperty("investmentObjective")]
        public string InvestmentObjective { get; set; }

        [JsonProperty("timeHorizon")]
        public string TimeHorizon { get; set; }

        [JsonProperty("stockPercent")]
        public string StockPercent { get; set; }

        [JsonProperty("riskTolerance")]
        public int RiskTolerance { get; set; }

        [JsonProperty("netWorth")]
        public decimal NetWorth { get; set; }

        [JsonProperty("netIncome")]
        public decimal NetIncome { get; set; }

        [JsonProperty("riskBudget")]
        public int RiskBudget { get; set; }

        [JsonProperty("isLifestyleOption")]
        public bool IsLifestyleOption { get; set; }
    }
}
