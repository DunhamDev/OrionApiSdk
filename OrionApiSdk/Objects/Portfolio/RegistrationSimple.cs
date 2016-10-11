using Newtonsoft.Json;
using OrionApiSdk.Objects.Abstract;

namespace OrionApiSdk.Objects.Portfolio
{
    public class RegistrationSimple : BaseSimpleEntity
    {
        [JsonProperty("isActive")]
        public bool? IsActive { get; set; }

        [JsonProperty("value")]
        public decimal? Value { get; set; }
    }
}
