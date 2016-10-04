using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OrionApiSdk.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http.Headers;

namespace OrionApiSdk.ApiEndpoints
{
    public abstract class ApiEndpointBase
    {
        #region Properties
        #region Static properties
        private const string ORION_API_URL = "https://api.orionadvisor.com/api/v1/";
        #endregion

        #region Instance properties
        protected string EndpointName { get; private set; }

        private string _authToken { get; set; }
        private UserCredentials _credentials { get; set; }
        #endregion
        #endregion

        #region Constructors
        internal ApiEndpointBase(string endpointName)
        {
            EndpointName = endpointName;
            _authToken = null;
            _credentials = null;
        }
        internal ApiEndpointBase(string endpointName, string authToken)
        {
            EndpointName = endpointName;
            _authToken = authToken;
        }
        #endregion

        #region Methods
        #region Protected methods
        protected void UpdateAuthToken(string authToken)
        {
            _authToken = authToken;
        }

        protected void UpdateCredentials(string username, string password)
        {
            _credentials = new UserCredentials(username, password);
        }

        protected async Task<JObject> GetJsonAsync(string endpointMethod, Dictionary<string, object> endpointParameters = null)
        {
            using (HttpClient httpClient = BuildHttpClient())
            {
                var response = await httpClient.GetAsync(EndpointUri(endpointMethod, endpointParameters));

                // Throws exception in the event there was a non-success status
                response.EnsureSuccessStatusCode();
                return await ParseJsonResponseAsync(response);
            }
        }

        protected async Task<JObject> PutJsonAsync(string endpointMethod, object body)
        {
            using (HttpClient httpClient = BuildHttpClient())
            {
                var putContent = new StringContent(JsonConvert.SerializeObject(body));
                var response = await httpClient.PutAsync(EndpointUri(endpointMethod, null), putContent);

                response.EnsureSuccessStatusCode();
                return await ParseJsonResponseAsync(response);
            }
        }

        protected async Task<JObject> PostJsonAsync(string endpointMethod, object body)
        {
            using (HttpClient httpClient = BuildHttpClient())
            {
                var postContent = new StringContent(JsonConvert.SerializeObject(body));
                var response = await httpClient.PostAsync(EndpointUri(endpointMethod, null), postContent);

                response.EnsureSuccessStatusCode();
                return await ParseJsonResponseAsync(response);
            }
        }
        #endregion

        #region Private methods
        private HttpClient BuildHttpClient()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = RequestAuthorization();
            return httpClient;
        }

        private AuthenticationHeaderValue RequestAuthorization()
        {
            if (_authToken != null)
            {
                return new AuthenticationHeaderValue("Session", _authToken);
            }
            else
            {
                return new AuthenticationHeaderValue("Basic", _credentials.ToString());
            }
        }

        private string EndpointUri(string endpointMethod, Dictionary<string, object> endpointParameters)
        {
            UriBuilder uriBuilder = new UriBuilder(ORION_API_URL + EndpointName + "/" + endpointMethod);
            uriBuilder.Query = GenerateQueryString(endpointParameters);
            return uriBuilder.ToString();
        }

        private string GenerateQueryString(Dictionary<string, object> endpointParameters)
        {
            if (endpointParameters == null)
            {
                return "";
            }

            var endpointQuery = HttpUtility.ParseQueryString("");
            foreach (var pair in endpointParameters)
            {
                endpointParameters.Add(pair.Key, pair.Value);
            }
            return endpointQuery.ToString();
        }

        private async Task<JObject> ParseJsonResponseAsync(HttpResponseMessage response)
        {
            string jsonStr = await response.Content.ReadAsStringAsync();
            return JObject.Parse(jsonStr);
        }
        #endregion
        #endregion
    }
}
