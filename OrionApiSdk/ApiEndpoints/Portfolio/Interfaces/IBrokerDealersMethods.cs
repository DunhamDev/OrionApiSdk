using OrionApiSdk.ApiEndpoints.Interfaces;
using OrionApiSdk.Objects.Portfolio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Portfolio.Interfaces
{
    public interface IBrokerDealersMethods : IApiMethodContainer<BrokerDealer>
    {
        /// <summary>
        /// HTTP GET: /Portfolio/BrokerDealers
        /// Gets a list of Broker-Dealers available to the user
        /// </summary>
        /// <param name="top">Number of BDs to return</param>
        /// <param name="skip">Number of BDs to skip</param>
        /// <returns>A list of Broker-Dealers</returns>
        List<BrokerDealer> Get(int top = 500, int skip = 0);
        /// <summary>
        /// HTTP GET: /Portfolio/BrokerDealers
        /// Gets a list of Broker-Dealers available to the user
        /// </summary>
        /// <param name="top">Number of BDs to return</param>
        /// <param name="skip">Number of BDs to skip</param>
        /// <returns>A list of Broker-Dealers</returns>
        Task<List<BrokerDealer>> GetAsync(int top = 500, int skip = 0);

        /// <summary>
        /// HTTP GET: /Portfolio/BrokerDealers/{bdId}
        /// Gets a specific Broker-Dealer
        /// </summary>
        /// <param name="bdId">ID of the Broker-Dealer to retrieve</param>
        /// <returns>The specified Broker-Dealer</returns>
        BrokerDealer Get(int bdId);
        /// <summary>
        /// HTTP GET: /Portfolio/BrokerDealers/{bdId}
        /// Gets a specific Broker-Dealer
        /// </summary>
        /// <param name="bdId">ID of the Broker-Dealer to retrieve</param>
        /// <returns>The specified Broker-Dealer</returns>
        Task<BrokerDealer> GetAsync(int bdId);

        /// <summary>
        /// HTTP GET: /Portfolio/BrokerDealers/Simple
        /// Gets a simple list of Broker-Dealers available to the user
        /// </summary>
        /// <param name="hasValue"></param>
        /// <returns>The list of Broker-Dealers</returns>
        List<BrokerDealerSimple> GetSimple(bool? hasValue = null);
        /// <summary>
        /// HTTP GET: /Portfolio/BrokerDealers/Simple
        /// Gets a simple list of Broker-Dealers available to the user
        /// </summary>
        /// <param name="hasValue"></param>
        /// <returns>The list of Broker-Dealers</returns>
        Task<List<BrokerDealerSimple>> GetSimpleAsync(bool? hasValue = null);
    }
}
