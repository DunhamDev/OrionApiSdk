using Newtonsoft.Json;
using OrionApiSdk.Objects.Abstract;
using OrionApiSdk.Objects.Exceptions;
using OrionApiSdk.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.Objects.Portfolio
{
    public class ClientVerbose : BaseSimpleEntity, IUpdatable, ICreatable
    {
        #region Properties
        #region Instance properties
        [JsonProperty("portfolio")]
        public Portfolio Portfolio { get; set; }

        [JsonProperty("notes")]
        public List<Note> Notes { get; set; }

        [JsonProperty("documents")]
        public List<Document> Documents { get; set; }
        #endregion
        #endregion

        #region Methods
        #region Public methods
        public void CheckForMinimumDataForCreate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new EmptyStringException("Name");
            }
            if (Portfolio == null)
            {
                throw new UninitializedPropertyException("Portfolio");
            }
        }

        public void CheckForMinimumDataForUpdate()
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
    }
}
