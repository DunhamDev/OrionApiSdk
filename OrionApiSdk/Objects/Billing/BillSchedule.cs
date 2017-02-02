using Newtonsoft.Json;
using OrionApiSdk.Objects.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects.Billing
{

    public class BillSchedule : BaseSimpleEntity
    {
        [JsonProperty("howBilled")]
        public int HowBilled { get; set; }

        [JsonProperty("scheduleCode")]
        public string ScheduleCode { get; set; }

        [JsonProperty("details")]
        public List<BillScheduleDetail> Details { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("schedule")]
        public string Schedule { get; set; }

        [JsonIgnore]
        public Enums.BillSchedule ScheduleEnum
        {
            get
            {
                return (Enums.BillSchedule)Enum.Parse(typeof(Enums.BillSchedule), Schedule.Replace(" ", ""));
            }
        }

        [JsonProperty("entity")]
        public string Entity { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("basis")]
        public string Basis { get; set; }

        [JsonProperty("minimumFee")]
        public decimal MinimumFee { get; set; }

        [JsonProperty("billEntityId")]
        public int BillEntityId { get; set; }

        [JsonProperty("billEntityDescription")]
        public string BillEntityDescription { get; set; }

        [JsonProperty("showInFeeCalculator")]
        public bool? ShowInFeeCalculator { get; set; }
    }
}
