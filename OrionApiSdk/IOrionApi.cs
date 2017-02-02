using OrionApiSdk.ApiEndpoints.Authorization.Interfaces;
using OrionApiSdk.ApiEndpoints.Billing.Interfaces;
using OrionApiSdk.ApiEndpoints.Portfolio.Interfaces;

namespace OrionApiSdk
{
    public interface IOrionApi
    {
        IAuthorizationEndpoint Authorization { get; }

        IPortfolioEndpoint Portfolio { get; }

        IBillingEndpoint Billing { get; }

        void UseTestApi();
        void UseProductionApi();
    }
}
