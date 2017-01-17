using Newtonsoft.Json.Linq;
using OrionApiSdk.ApiEndpoints.Abstract;
using OrionApiSdk.ApiEndpoints.Portfolio.Interfaces;
using OrionApiSdk.Objects;
using OrionApiSdk.Objects.Portfolio;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Portfolio
{
    public class BrokerDealersMethods : ApiMethodContainer<BrokerDealer>, IBrokerDealersMethods
    {
        /// <summary>
        /// Constructs an instance of a /Portfolio/BrokerDealers endpoint instance
        /// </summary>
        /// <param name="token">The access token of the user making requests</param>
        public BrokerDealersMethods(AuthToken token) : base("Portfolio", "BrokerDealers", token) { }

        #region Get BDs
        /// <summary>
        /// HTTP GET: /Portfolio/BrokerDealers
        /// Gets a list of Broker-Dealers available to the user
        /// </summary>
        /// <param name="top">Number of BDs to return</param>
        /// <param name="skip">Number of BDs to skip</param>
        /// <returns>A list of Broker-Dealers</returns>
        public List<BrokerDealer> Get(int top = 500, int skip = 0)
        {
            return GetAsync(top, skip).Result;
        }
        /// <summary>
        /// HTTP GET: /Portfolio/BrokerDealers
        /// Gets a list of Broker-Dealers available to the user
        /// </summary>
        /// <param name="top">Number of BDs to return</param>
        /// <param name="skip">Number of BDs to skip</param>
        /// <returns>A list of Broker-Dealers</returns>
        public async Task<List<BrokerDealer>> GetAsync(int top = 500, int skip = 0)
        {
            JToken dealers = await GetJsonAsync("", new NameValueCollection
            {
                { "$top", top.ToString() },
                { "$skip", skip.ToString() }
            });
            return dealers.ToObject<List<BrokerDealer>>();
        }

        /// <summary>
        /// HTTP GET: /Portfolio/BrokerDealers/{bdId}
        /// Gets a specific Broker-Dealer
        /// </summary>
        /// <param name="bdId">ID of the Broker-Dealer to retrieve</param>
        /// <returns>The specified Broker-Dealer</returns>
        public BrokerDealer Get(int bdId)
        {
            return GetAsync(bdId).Result;
        }
        /// <summary>
        /// HTTP GET: /Portfolio/BrokerDealers/{bdId}
        /// Gets a specific Broker-Dealer
        /// </summary>
        /// <param name="bdId">ID of the Broker-Dealer to retrieve</param>
        /// <returns>The specified Broker-Dealer</returns>
        public async Task<BrokerDealer> GetAsync(int bdId)
        {
            JToken brokerDealer = await GetJsonAsync(bdId.ToString());
            return brokerDealer.ToObject<BrokerDealer>();
        }

        /// <summary>
        /// HTTP GET: /Portfolio/BrokerDealers/Simple
        /// Gets a simple list of Broker-Dealers available to the user
        /// </summary>
        /// <param name="hasValue"></param>
        /// <returns>The list of Broker-Dealers</returns>
        public List<BrokerDealerSimple> GetSimple(bool? hasValue = null)
        {
            return GetSimpleAsync().Result;
        }
        /// <summary>
        /// HTTP GET: /Portfolio/BrokerDealers/Simple
        /// Gets a simple list of Broker-Dealers available to the user
        /// </summary>
        /// <param name="hasValue"></param>
        /// <returns>The list of Broker-Dealers</returns>
        public async Task<List<BrokerDealerSimple>> GetSimpleAsync(bool? hasValue = null)
        {
            JToken brokerDealers = await GetJsonAsync("", new NameValueCollection
            {
                { "hasValue", hasValue.ToString() }
            });
            return brokerDealers.ToObject<List<BrokerDealerSimple>>();
        }
        #endregion

        #region Search BDs
        /// <summary>
        /// HTTP GET: /Portfolio/BrokerDealers/Simple/Search
        /// Gets a simple list of Broker-Dealers available to the user
        /// </summary>
        /// <param name="startsWith">Partial Broker-Dealer name to search for</param>
        /// <returns>A list of Broker-Dealers matching the search</returns>
        public List<BrokerDealerSimple> GetSimpleSearch(string startsWith)
        {
            return GetSimpleSearchAsync(startsWith).Result;
        }
        /// <summary>
        /// HTTP GET: /Portfolio/BrokerDealers/Simple/Search
        /// Gets a simple list of Broker-Dealers available to the user
        /// </summary>
        /// <param name="startsWith">Partial Broker-Dealer name to search for</param>
        /// <returns>A list of Broker-Dealers matching the search</returns>
        public async Task<List<BrokerDealerSimple>> GetSimpleSearchAsync(string startsWith)
        {
            JToken dealers = await GetJsonAsync("Simple/Search", new NameValueCollection
            {
                { "search", startsWith.ToString() }
            });
            return dealers.ToObject<List<BrokerDealerSimple>>();
        }
        #endregion

        #region BD value
        /// <summary>
        /// HTTP GET: /Portfolio/BrokerDealers/Value
        /// Gets the Broker-Dealers and their values
        /// </summary>
        /// <param name="hasValue"></param>
        /// <returns>The list of Broker-Dealer values</returns>
        public List<BrokerDealerSimple> GetValue(bool? hasValue = null)
        {
            return GetValueAsync(hasValue).Result;
        }
        /// <summary>
        /// HTTP GET: /Portfolio/BrokerDealers/Value
        /// Gets the Broker-Dealers and their values
        /// </summary>
        /// <param name="hasValue"></param>
        /// <returns>The list of Broker-Dealer values</returns>
        public async Task<List<BrokerDealerSimple>> GetValueAsync(bool? hasValue = null)
        {
            JToken dealerValues = await GetJsonAsync("Value", new NameValueCollection
            {
                { "hasValue", hasValue.ToString() }
            });
            return dealerValues.ToObject<List<BrokerDealerSimple>>();
        }

        /// <summary>
        /// HTTP GET: /Portfolio/BrokerDealers/Value/{asOfDate}
        /// Gets the Broker-Dealers and their values as of a specific date
        /// </summary>
        /// <param name="asOfDate">The specific date</param>
        /// <param name="hasValue"></param>
        /// <returns>The list of Broker-Dealer values as of the given date</returns>
        public List<BrokerDealerSimple> GetValue(DateTime asOfDate, bool? hasValue = null)
        {
            return GetValueAsync(asOfDate, hasValue).Result;
        }
        /// <summary>
        /// HTTP GET: /Portfolio/BrokerDealers/Value/{asOfDate}
        /// Gets the Broker-Dealers and their values as of a specific date
        /// </summary>
        /// <param name="asOfDate">The specific date</param>
        /// <param name="hasValue"></param>
        /// <returns>The list of Broker-Dealer values as of the given date</returns>
        public async Task<List<BrokerDealerSimple>> GetValueAsync(DateTime asOfDate, bool? hasValue = null)
        {
            JToken dealerValues = await GetJsonAsync(string.Format("Value/{0:MM-dd-yyyy}", asOfDate), new NameValueCollection
            {
                { "hasValue", hasValue.ToString() }
            });
            return dealerValues.ToObject<List<BrokerDealerSimple>>();
        }
        #endregion
    }
}
