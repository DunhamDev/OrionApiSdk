using OrionApiSdk.ApiEndpoints.Abstract;
using OrionApiSdk.Objects;
using OrionApiSdk.Objects.Global;
using OrionApiSdk.Objects.Global.Enums;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionApiSdk.ApiEndpoints.Global
{
    public class ProductsMethods : ApiMethodContainer
    {
        public ProductsMethods(AuthToken token) : this(token, false) { }
        public ProductsMethods(AuthToken token, bool useTestingApi) : base("Global", "Products", token, useTestingApi) { }

        /// <summary>
        /// HTTP GET: /Global/Products/{productId}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product Get(int id)
        {
            return GetAsync(id).Result;
        }
        /// <summary>
        /// HTTP GET: /Global/Products/{productId}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Product> GetAsync(int id)
        {
            var productJson = await GetJsonAsync(id.ToString());
            return productJson.ToObject<Product>();
        }

        /// <summary>
        /// HTTP GET: /Global/Products
        /// </summary>
        /// <param name="top"></param>
        /// <param name="skip"></param>
        /// <param name="searchTicker"></param>
        /// <param name="exactTicker"></param>
        /// <param name="exactCusip"></param>
        /// <param name="searchCusip"></param>
        /// <param name="exactDownloadSymbol"></param>
        /// <param name="searchDownloadSymbol"></param>
        /// <param name="exactSymbol"></param>
        /// <param name="searchSymbol"></param>
        /// <param name="searchName"></param>
        /// <param name="searchId"></param>
        /// <param name="productType"></param>
        /// <param name="fundFamilyId"></param>
        /// <returns></returns>
        public List<Product> Get(int top = 5000, int skip = 0, string searchTicker = null, string exactTicker = null,
            string exactCusip = null, string searchCusip = null, string exactDownloadSymbol = null, string searchDownloadSymbol = null,
            string exactSymbol = null, string searchSymbol = null, string searchName = null, string searchId = null,
            int? fundFamilyId = null, params ProductType[] productTypes)
        {
            return GetAsync(top, skip, searchTicker, exactTicker, exactCusip, searchCusip, exactDownloadSymbol,
                searchDownloadSymbol, exactSymbol, searchSymbol, searchName, searchId, fundFamilyId, productTypes).Result;
        }
        /// <summary>
        /// HTTP GET: /Global/Products
        /// </summary>
        /// <param name="top"></param>
        /// <param name="skip"></param>
        /// <param name="searchTicker"></param>
        /// <param name="exactTicker"></param>
        /// <param name="exactCusip"></param>
        /// <param name="searchCusip"></param>
        /// <param name="exactDownloadSymbol"></param>
        /// <param name="searchDownloadSymbol"></param>
        /// <param name="exactSymbol"></param>
        /// <param name="searchSymbol"></param>
        /// <param name="searchName"></param>
        /// <param name="searchId"></param>
        /// <param name="productType"></param>
        /// <param name="fundFamilyId"></param>
        /// <returns></returns>
        public async Task<List<Product>> GetAsync(int top = 5000, int skip = 0, string searchTicker = null, string exactTicker = null,
            string exactCusip = null, string searchCusip = null, string exactDownloadSymbol = null, string searchDownloadSymbol = null,
            string exactSymbol = null, string searchSymbol = null, string searchName = null, string searchId = null,
            int? fundFamilyId = null, params ProductType[] productTypes)
        {
            #region Build query string
            var queryString = new NameValueCollection
            {
                { "searchTicker", searchTicker },
                { "exactTicker", exactTicker },
                { "exactCusip", exactCusip },
                { "searchCusip", searchCusip },
                { "exactDownloadSymbol", exactDownloadSymbol },
                { "searchDownloadSymbol", searchDownloadSymbol },
                { "exactSymbol", exactSymbol },
                { "searchSymbol", searchSymbol },
                { "searchName", searchName },
                { "searchId", searchId },
                { "fundFamilyId", fundFamilyId.ToString() },
            };
            foreach (ProductType typeFilter in productTypes)
            {
                queryString.Add("productType", typeFilter.ToString());
            }
            queryString.Add("$top", top.ToString());
            queryString.Add("$skip", skip.ToString());
            #endregion

            var productsListJson = await GetJsonAsync("", queryString);
            return productsListJson.ToObject<List<Product>>();
        }
    }
}
