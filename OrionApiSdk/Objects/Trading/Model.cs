﻿using Newtonsoft.Json;
using OrionApiSdk.Objects.Abstract;
using OrionApiSdk.Objects.Exceptions;
using OrionApiSdk.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrionApiSdk.Objects.Trading
{

    public class Model : BaseSimpleEntity, IUpdatable, ICreatable
    {
        #region Properties
        #region Instance properties
        [JsonProperty("fundFamilyId")]
        public int? FundFamilyId { get; set; }

        [JsonProperty("shareClassId")]
        public int? ShareClassId { get; set; }

        [JsonProperty("platformId")]
        public int? PlatformId { get; set; }

        [JsonProperty("isListTraded")]
        public bool? IsListTraded { get; set; }

        [JsonProperty("representativeId")]
        public int? RepresentativeId { get; set; }

        [JsonProperty("modNotes")]
        public string ModNotes { get; set; }

        [JsonProperty("sequence")]
        public int? Sequence { get; set; }

        [JsonProperty("changeReason")]
        public string ChangeReason { get; set; }

        [JsonProperty("modelLevels")]
        public int? ModelLevels { get; set; }

        [JsonProperty("dynamicEffectiveDate")]
        public DateTime? DynamicEffectiveDate { get; set; }

        [JsonProperty("custodianId")]
        public int? CustodianId { get; set; }

        [JsonProperty("lastRebalanced")]
        public DateTime? LastRebalanced { get; set; }
        
        [JsonProperty("fundName")]
        public string FundName { get; set; }
        
        [JsonProperty("editedBy")]
        public string EditedBy { get; set; }
        
        [JsonProperty("editedDate")]
        public DateTime EditedDate { get; set; }
        
        [JsonProperty("groupNum")]
        public string GroupNum { get; set; }
        
        [JsonProperty("subAdvisor")]
        public string SubAdvisor { get; set; }
        
        [JsonProperty("modelNum")]
        public int? ModelNum { get; set; }
        
        [JsonProperty("percEquity")]
        public int? PercEquity { get; set; }
        
        [JsonProperty("modelType")]
        public string ModelType { get; set; }
        
        [JsonProperty("fundList")]
        public string FundList { get; set; }
        
        [JsonProperty("modelTol")]
        public int ModelTol { get; set; }
        
        [JsonProperty("cashPerc")]
        public int CashPerc { get; set; }
        
        [JsonProperty("cashTol")]
        public int CashTol { get; set; }
        
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
        
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }
        
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }
        
        [JsonProperty("class")]
        public string Class { get; set; }
        
        [JsonProperty("modelCode")]
        public string ModelCode { get; set; }
        
        [JsonProperty("managementStyle")]
        public string ManagementStyle { get; set; }
        
        [JsonProperty("notes")]
        public string Notes { get; set; }
        
        [JsonProperty("isDynamic")]
        public bool IsDynamic { get; set; }
        
        [JsonProperty("custodian")]
        public string Custodian { get; set; }
        
        [JsonProperty("subAdvisorId")]
        public int? SubAdvisorId { get; set; }
        
        [JsonProperty("useRestrictions")]
        public bool UseRestrictions { get; set; }

        [JsonProperty("value")]
        public decimal? Value { get; set; }

        [JsonProperty("items")]
        public List<ModelItem> Items { get; set; }

        [JsonProperty("accounts")]
        public List<Account> Accounts { get; set; }

        [JsonProperty("ranges")]
        public List<ModelRange> Ranges { get; set; }
        #endregion
        #endregion

        #region Methods
        #region Public methods
        /// <summary>
        /// Validates that <see cref="BaseSimpleEntity.Name"/> and <see cref="ModelType"/> are populated, that
        /// <see cref="Items"/> is initalized, and <see cref="Items"/> contains either 0 items or
        /// <see cref="ModelItem"/>s which have a total <see cref="ModelItem.TargetPercent"/> which totals 100
        /// </summary>
        public void CheckNecessaryDataForCreate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new EmptyStringException("Name");
            }
            if (string.IsNullOrWhiteSpace(ModelType))
            {
                throw new EmptyStringException("ModelType");
            }
            
            if (Items == null)
            {
                throw new UninitializedPropertyException("Items");
            }
            if (!ItemsTotal100Percent())
            {
                throw new ArgumentException("TargetPercent of Items must equal 100");
            }
        }
        
        /// <summary>
        /// Validates that <see cref="BaseSimpleEntity.Name"/> and <see cref="ModelType"/> are populated, that
        /// <see cref="Items"/> is initalized, and <see cref="Items"/> contains either 0 items or
        /// <see cref="ModelItem"/>s which have a total <see cref="ModelItem.TargetPercent"/> which totals 100
        /// </summary>
        public void CheckNecessaryDataForUpdate()
        {
            CheckNecessaryDataForCreate();
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Verifies that <see cref="Items"/> either contains 0 items, or that the total
        /// <see cref="ModelItem.TargetPercent"/> is 100
        /// </summary>
        /// <returns>True iff <see cref="Items"/>'s size is 0, or if its total percent is 100, otherwise false</returns>
        private bool ItemsTotal100Percent()
        {
            decimal totalPercent = Items.Sum(i => i.TargetPercent);
            return Items.Count == 0 || totalPercent == 100;
        }
        #endregion
        #endregion
    }
}
