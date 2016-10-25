using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects.Abstract
{
    public abstract class BaseUser
    {
        /// <summary>
        /// User's given first name
        /// </summary>
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// User's given last name
        /// </summary>
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// User's given email address
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("entityName")]
        public string EntityName { get; set; }
    }
}
