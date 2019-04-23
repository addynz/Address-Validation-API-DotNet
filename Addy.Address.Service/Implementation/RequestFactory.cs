using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Addy.Address.Service
{
    /// <summary>
    /// Manage the creation of Web API Client instances
    /// </summary>
    public class RequestFactory : IRequestFactory
    {
        private const string BaseUrl = "https://api.addy.co.nz/";
        private const string ApiKeyProperty = "ADDY_API_KEY";

        private readonly string _apiKey;

        /// <summary>
        /// Default constructor will search for the API key in AppSettings with the key "ADDY_API_KEY".
        /// </summary>
        public RequestFactory()
        {
            _apiKey = ConfigurationManager.AppSettings[ApiKeyProperty];
            if (string.IsNullOrWhiteSpace(_apiKey)) throw new Exception(string.Format("An API key must be specified. Verify that the '{0}' application property exist.", ApiKeyProperty));
        }

        /// <summary>
        /// Create an instance of the factory.
        /// </summary>
        /// <param name="apiKey">The Addy API Key. See: https://www.addy.co.nz</param>
        public RequestFactory(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey)) throw new ArgumentNullException("apiKey");
            _apiKey = apiKey;
        }

        /// <summary>
        /// Create an instance of the web client that can be used again the Addy APIs: https://api.addy.co.nz/
        /// </summary>
        /// <returns>Web API Client.</returns>
        public IRequestClient CreateClient()
        {
            return new RequestClient(new Lazy<HttpClient>(CreateHttpClient));
        }

        /// <summary>
        /// Create a new HttpClient instance that can be used for calling the Web API
        /// </summary>
        /// <returns>HttpClient</returns>
        private HttpClient CreateHttpClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("x-addy-api-key", _apiKey);
            return client;
        }
    }
}
