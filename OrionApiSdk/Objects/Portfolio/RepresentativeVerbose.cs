using Newtonsoft.Json;
using OrionApiSdk.Objects.Abstract;
using OrionApiSdk.Objects.Interfaces;
using System.Collections.Generic;
using System;
using OrionApiSdk.Objects.Exceptions;

namespace OrionApiSdk.Objects.Portfolio
{

    public class RepresentativeVerbose : BaseSimpleEntity, IUpdatable, ICreatable
    {
        #region Properties
        #region Instance properties
        [JsonProperty("portfolio")]
        public RepresentativePortolfio Portfolio { get; set; }
        
        [JsonProperty("notes")]
        public List<Note> Notes { get; set; }
        
        [JsonProperty("documents")]
        public List<Document> Documents { get; set; }
        
        [JsonProperty("billRepresentativePlatforms")]
        public List<BillRepresentativePlatform> BillRepresentativePlatforms { get; set; }
        
        [JsonProperty("reportImage")]
        public ReportImage ReportImage { get; set; }
        
        [JsonProperty("userDefinedFields")]
        public List<object> UserDefinedFields { get; set; }
        
        [JsonProperty("entityOptions")]
        public List<object> EntityOptions { get; set; }
        #endregion
        #endregion

        #region Methods
        #region Public methods
        public void CheckNecessaryDataForCreate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new EmptyStringException("Name");
            }
            if (Portfolio == null)
            {
                throw new UninitializedPropertyException("Portfolio");
            }
            CheckPortfolioName();
            CheckPortfolioLastName();
        }

        public void CheckNecessaryDataForUpdate()
        {
            if (Portfolio != null)
            {
                CheckPortfolioName();
                CheckPortfolioLastName();
            }
        }
        #endregion

        #region Private methods
        private void CheckPortfolioName()
        {
            if (string.IsNullOrWhiteSpace(Portfolio.Name))
            {
                throw new EmptyStringException("Portfolio.Name");
            }
        }

        private void CheckPortfolioLastName()
        {
            if (string.IsNullOrWhiteSpace(Portfolio.LastName))
            {
                throw new EmptyStringException("Portfolio.LastName");
            }
        }
        #endregion
        #endregion
    }
}
