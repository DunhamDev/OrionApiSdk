using OrionApiSdk.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints
{
    public interface IApiMethodContainer : IApiEndpoint
    {
    }

    public interface IApiMethodContainer<TObject> : IApiEndpoint
        where TObject : IUpdatable, ICreatable
    {
        TObject Create(TObject toCreate);
        Task<TObject> CreateAsync(TObject toCreate);

        TObject Update(TObject toUpdate);
        Task<TObject> UpdateAsync(TObject toUpdate);
    }
}
