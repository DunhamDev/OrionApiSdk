using Newtonsoft.Json;
using OrionApiSdk.Objects.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects.Security
{
    public class CompleteUser : SimpleUser
    {
        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("profiles")]
        public List<Profile> Profiles { get; set; }
    }
}
