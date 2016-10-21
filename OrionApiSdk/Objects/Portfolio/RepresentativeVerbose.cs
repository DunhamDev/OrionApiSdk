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
            if (string.IsNullOrWhiteSpace(Portfolio.Name))
            {
                throw new EmptyStringException("Portfolio.Name");
            }
            if (string.IsNullOrWhiteSpace(Portfolio.LastName))
            {
                throw new EmptyStringException("Portfolio.LastName");
            }
        }

        public void CheckNecessaryDataForUpdate()
        {
            throw new NotImplementedException();
        }
    }
}
