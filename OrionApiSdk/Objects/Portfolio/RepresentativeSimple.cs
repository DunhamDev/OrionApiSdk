using Newtonsoft.Json;
using OrionApiSdk.Objects.Abstract;

namespace OrionApiSdk.Objects.Portfolio
{
    public class RepresentativeSimple : BaseSimpleEntity
    {
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }
    }
}
