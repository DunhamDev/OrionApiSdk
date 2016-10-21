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
    public class RegistrationVerbose : BaseSimpleEntity, ICreatable, IUpdatable
    {
        #region Properties
        #region Instance properties
        [JsonProperty("portfolio")]
        public RegistrationPortfolio Portfolio { get; set; }

        [JsonProperty("notes")]
        public List<Note> Notes { get; set; }

        [JsonProperty("beneficiaries")]
        public List<RegistrationBeneficiary> Beneficiaries { get; set; }

        [JsonProperty("suitability")]
        public RegistrationSuitability Suitability { get; set; }
        #endregion
        #endregion

        #region Methods
        #region Public methods
        public void CheckNecessaryDataForCreate()
        {
            if (Portfolio == null)
            {
                throw new UninitializedPropertyException("Portfolio");
            }
            if (string.IsNullOrWhiteSpace(Portfolio.LastName))
            {
                throw new EmptyStringException("Portfolio.LastName");
            }
            if (string.IsNullOrWhiteSpace(Portfolio.Name))
            {
                throw new EmptyStringException("Portfolio.Name");
            }
            if (Portfolio.ClientId == 0)
            {
                throw new UninitializedPropertyException("Portfolio.ClientId");
            }
            if (Portfolio.TypeId == 0)
            {
                throw new UninitializedPropertyException("Portfolio.TypeId");
            }
        }

        public void CheckNecessaryDataForUpdate()
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
    }
}
