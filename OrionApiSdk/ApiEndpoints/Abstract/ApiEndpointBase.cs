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
using System.Collections.Specialized;

namespace OrionApiSdk.ApiEndpoints.Abstract
{
    public abstract class ApiEndpointBase
    {
        #region Properties
        #region Static properties
        private const string ORION_API_URL = "https://api.orionadvisor.com/api/";
        private const string TEST_ORION_API_RUL = "https://testapi.orionadvisor.com/api/";
        private const string VERSION = "v1";
        #endregion

        #region Instance properties
        protected string EndpointName { get; private set; }

        protected AuthToken AuthToken { get; set; }
        private string _accessToken
        {
            get
            {
                return AuthToken.AccessToken;
            }
        }
        private UserCredentials _credentials { get; set; }

        private bool UseTestApi { get; set; }

        private string ApiUrl
        {
            get
            {
                if (UseTestApi)
                {
                    return TEST_ORION_API_RUL + VERSION + "/";
                }
                return ORION_API_URL + VERSION + "/";
            }
        }
        #endregion
        #endregion

        #region Constructors
        internal ApiEndpointBase(string endpointName)
        {
            EndpointName = endpointName;
            AuthToken = null;
            _credentials = null;
            UseTestApi = false;
        }
        internal ApiEndpointBase(string endpointName, bool useTestApi) : this(endpointName)
        {
            UseTestApi = useTestApi;
        }

        internal ApiEndpointBase(string endpointName, AuthToken authToken)
        {
            EndpointName = endpointName;
            AuthToken = authToken;
            UseTestApi = false;
        }
        internal ApiEndpointBase(string endpointName, AuthToken authToken, bool useTestApi) : this(endpointName, authToken)
        {
            UseTestApi = useTestApi;
        }
        #endregion

        #region Methods
        #region Protected methods
        protected void UpdateAuthToken(AuthToken authToken)
        {
            AuthToken = authToken;
        }

        protected void UpdateCredentials(string username, string password)
        {
            _credentials = new UserCredentials(username, password);
            UseTestApi = false;
        }

        protected async Task<JToken> GetJsonAsync(string endpointMethod, NameValueCollection endpointParameters = null)
        {
            using (HttpClient httpClient = BuildHttpClient())
            {
                var response = await httpClient.GetAsync(EndpointUri(endpointMethod, endpointParameters));

                // Throws exception in the event there was a non-success status
                await CheckHttpRequestResponse(response);
                return await ParseJsonResponseAsync(response);
            }
        }
        
        protected async Task<JToken> PutJsonAsync(string endpointMethod, object body)
        {
            using (HttpClient httpClient = BuildHttpClient())
            {
                var putContent = new StringContent(JsonConvert.SerializeObject(body));
                var response = await httpClient.PutAsync(EndpointUri(endpointMethod, null), putContent);

                await CheckHttpRequestResponse(response);
                return await ParseJsonResponseAsync(response);
            }
        }

        protected async Task<JToken> PostJsonAsync(string endpointMethod, object body, NameValueCollection endpointParameters = null)
        {
            using (HttpClient httpClient = BuildHttpClient())
            {
                HttpContent postContent;
                if (body is HttpContent)
                {
                    postContent = (HttpContent)body;
                }
                else
                {
                    postContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
                }
                var response = await httpClient.PostAsync(EndpointUri(endpointMethod, endpointParameters), postContent);

                await CheckHttpRequestResponse(response);
                return await ParseJsonResponseAsync(response);
            }
        }
        #endregion

        #region Private methods
        private HttpClient BuildHttpClient()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (AuthToken != null || _credentials != null)
            {
                httpClient.DefaultRequestHeaders.Authorization = RequestAuthorization();
            }
            return httpClient;
        }

        private AuthenticationHeaderValue RequestAuthorization()
        {
            if (AuthToken != null)
            {
                return new AuthenticationHeaderValue("Session", _accessToken);
            }
            else
            {
                return new AuthenticationHeaderValue("Basic", _credentials.ToString());
            }
        }

        private string EndpointUri(string endpointMethod, NameValueCollection endpointParameters)
        {
            string uri = ApiUrl + EndpointName;
            if (!string.IsNullOrWhiteSpace(endpointMethod))
            {
                uri += "/" + endpointMethod;
            }
            UriBuilder uriBuilder = new UriBuilder(uri);
            uriBuilder.Query = GenerateQueryString(endpointParameters);
            return uriBuilder.ToString();
        }

        private string GenerateQueryString(NameValueCollection endpointParameters)
        {
            if (endpointParameters == null)
            {
                return "";
            }

            var endpointQuery = HttpUtility.ParseQueryString("");
            foreach (string key in endpointParameters.AllKeys)
            {
                foreach (string value in endpointParameters.GetValues(key))
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        endpointQuery.Add(key, value);
                    }
                }
            }
            return endpointQuery.ToString();
        }

        private async Task<JToken> ParseJsonResponseAsync(HttpResponseMessage response)
        {
            string jsonStr = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<JToken>(jsonStr);
        }

        private static async Task CheckHttpRequestResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(
                    string.Format("HTTP Status Code: {0}\n{1}", response.StatusCode, await response.Content.ReadAsStringAsync())
                );
            }
        }
        #endregion
        #endregion
    }
}
