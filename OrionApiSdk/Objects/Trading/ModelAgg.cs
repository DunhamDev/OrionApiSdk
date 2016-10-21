using Newtonsoft.Json;
using OrionApiSdk.Objects.Abstract;
using OrionApiSdk.Objects.Exceptions;
using OrionApiSdk.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrionApiSdk.Objects.Trading
{
    public class ModelAgg : BaseSimpleEntity, IUpdatable, ICreatable
    {
        #region Properties
        #region Instance properties
        [JsonProperty("isSystemMaintained")]
        public bool IsSystemMaintained { get; set; }
        
        [JsonProperty("accountNumberSuffix")]
        public string AccountNumberSuffix { get; set; }
        
        [JsonProperty("keepAlways")]
        public bool KeepAlways { get; set; }
        
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("createdDate")]
        public DateTime? CreatedDate { get; set; }

        [JsonProperty("editedBy")]
        public string EditedBy { get; set; }
        
        [JsonProperty("editedDate")]
        public DateTime? EditedDate { get; set; }
        
        [JsonProperty("entityId")]
        public int? EntityId { get; set; }
        
        [JsonProperty("entityEnum")]
        public string EntityEnum { get; set; }
        
        [JsonProperty("include")]
        public bool Include { get; set; }
        
        [JsonProperty("owned")]
        public bool Owned { get; set; }
        
        [JsonProperty("canMaintain")]
        public bool CanMaintain { get; set; }
        
        [JsonProperty("modelAggTypeId")]
        public int? ModelAggTypeId { get; set; }
        
        [JsonProperty("modelAggType")]
        public string ModelAggType { get; set; }

        [JsonProperty("accounts")]
        public List<Account> Accounts { get; set; }

        [JsonProperty("items")]
        public List<ModelItem> Items { get; set; }

        [JsonProperty("details")]
        public List<ModelAggDetail> Details { get; set; }

        [JsonProperty("entities")]
        public List<ModelAggEntity> Entities { get; set; }
        #endregion
        #endregion

        #region Methods
        #region Public methods
        /// <summary>
        /// Validates that <see cref="BaseSimpleEntity.Name"/>  is populated, and that <see cref="Details"/> 
        /// is initialized, and that <see cref="Details"/> contains <see cref="ModelAggDetail"/>s which
        /// have a total <see cref="ModelAggDetail.WeightPercent"/> of 100
        /// </summary>
        public void CheckForMinimumDataForCreate()
        {
            CheckName();
            if (Details == null)
            {
                throw new UninitializedPropertyException("Details");
            }
            if (!DetailsWeightTotal100())
            {
                throw new ArgumentException("WeightPercent of Details does not total 100");
            }
        }

        /// <summary>
        /// Validates that <see cref="BaseSimpleEntity.Name"/>  is populated, and that <see cref="Details"/> 
        /// is initialized, and that <see cref="Details"/> contains <see cref="ModelAggDetail"/>s which
        /// have a total <see cref="ModelAggDetail.WeightPercent"/> of 100
        /// </summary>
        public void CheckForMinimumDataForUpdate()
        {
            CheckName();
            if (Details != null && !DetailsWeightTotal100())
            {
                throw new ArgumentException("WeightPercent of Details does not total 100");
            }
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Validates that <see cref="BaseSimpleEntity.Name"/> is not null or whitespace
        /// </summary>
        private void CheckName()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new EmptyStringException("Name");
            }
        }

        /// <summary>
        /// Checks that the total <see cref="ModelAggDetail.WeightPercent"/> in <see cref="Details"/>
        /// totals 100
        /// </summary>
        /// <returns>True iff the total is 100, otherwise false</returns>
        private bool DetailsWeightTotal100()
        {
            decimal totalWeight = Details.Sum(d => d.WeightPercent);
            return totalWeight == 100;
        }
        #endregion
        #endregion
    }
}
