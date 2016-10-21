﻿using OrionApiSdk.Objects;
using OrionApiSdk.Objects.Abstract;
using OrionApiSdk.Objects.Interfaces;
using System;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Abstract
{
    public abstract class ApiMethodContainer<TObject> : ApiEndpointBase
        where TObject : BaseSimpleEntity, IUpdatable, ICreatable
    {
        internal ApiMethodContainer(string apiEndpointName, string apiEndpointContainerMethod, AuthToken token)
            : base(apiEndpointName + "/" + apiEndpointContainerMethod, token) { }

        public virtual TObject Create(TObject toCreate)
        {
            try
            {
                return CreateAsync(toCreate).Result;
            }
            catch (Exception ex)
            {
                throw ex.InnerException ?? ex;
            }
        }
        public virtual async Task<TObject> CreateAsync(TObject toCreate)
        {
            if (toCreate == null)
            {
                throw new ArgumentNullException("toCreate");
            }

            toCreate.CheckForMinimumDataForCreate();
            var responseObject = await PostJsonAsync("", toCreate);
            return responseObject.ToObject<TObject>();
        }

        public virtual TObject Update(TObject toUpdate)
        {
            try
            {
                return UpdateAsync(toUpdate).Result;
            }
            catch (Exception ex)
            {
                throw ex.InnerException ?? ex;
            }
        }
        public virtual async Task<TObject> UpdateAsync(TObject toUpdate)
        {
            if (toUpdate == null)
            {
                throw new ArgumentNullException("toUpdate");
            }

            toUpdate.CheckForMinimumDataForUpdate();
            var responseObject = await PostJsonAsync(toUpdate.Id.ToString(), toUpdate);
            return responseObject.ToObject<TObject>();
        }
    }
}
