using OrionApiSdk.Objects;
using OrionApiSdk.Objects.Abstract;
using OrionApiSdk.Objects.Interfaces;
using System;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Abstract
{
    public abstract class ApiMethodContainerForVeboseObject<TObject> : ApiMethodContainer<TObject>
        where TObject : BaseSimpleEntity, ICreatable, IUpdatable
    {
        internal ApiMethodContainerForVeboseObject(string apiEndpointName, string apiEndpointContainerMethod, AuthToken token)
            : base(apiEndpointName, apiEndpointContainerMethod, token) { }

        public override TObject Create(TObject toCreate)
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
        public override async Task<TObject> CreateAsync(TObject toCreate)
        {
            if (toCreate == null)
            {
                throw new ArgumentNullException("toCreate");
            }

            toCreate.CheckNecessaryDataForCreate();
            var responseObject = await PostJsonAsync("Verbose", toCreate);
            return responseObject.ToObject<TObject>();
        }

        public override TObject Update(TObject toUpdate)
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
        public override async Task<TObject> UpdateAsync(TObject toUpdate)
        {
            if (toUpdate == null)
            {
                throw new ArgumentNullException("toUpdate");
            }

            toUpdate.CheckNecessaryDataForUpdate();
            var responseObject = await PostJsonAsync("Verbose/" + toUpdate.Id.ToString(), toUpdate);
            return responseObject.ToObject<TObject>();
        }
    }
}
