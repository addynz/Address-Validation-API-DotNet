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
        private const string BaseUrl = "https://www.addy.co.nz/api/";
        private const string ApiKeyProperty = "ADDY_API_KEY";

        private readonly string _apiKey;

        public RequestFactory()
        {
            _apiKey = ConfigurationManager.AppSettings[ApiKeyProperty];
            if (string.IsNullOrWhiteSpace(_apiKey)) throw new Exception(string.Format("An API key must be specified. Verify that the '{0}' application property exist.", ApiKeyProperty));
        }

        public RequestFactory(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey)) throw new ArgumentNullException("apiKey");
            _apiKey = apiKey;
        }

        /// <summary>
        /// Create a new HttpClient instance that can be used for calling the Web API
        /// </summary>
        /// <returns>HttpClient</returns>
        public HttpClient CreateClient()
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
