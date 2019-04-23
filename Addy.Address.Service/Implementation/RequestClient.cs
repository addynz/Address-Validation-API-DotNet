using System;
using System.Net;
using System.Net.Http;

using System.Threading.Tasks;

namespace Addy.Address.Service
{
    /// <summary>
    /// HTTP Request Client to make calls to the API.
    /// </summary>
    public class RequestClient : IRequestClient
    {
        private readonly Lazy<HttpClient> _client;

        public RequestClient(Lazy<HttpClient> client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        /// <summary>
        /// Make a call to an API.
        /// </summary>
        /// <typeparam name="T">The response object expected.</typeparam>
        /// <param name="query">The URL querystring.</param>
        /// <returns>Response model/dto.</returns>
        public async Task<T> GetAsync<T>(string query) where T : class
        {
            var response = await _client.Value.GetAsync(query);
            ValidateResponse(response);
            return await response.Content.ReadAsAsync<T>();
        }

        private void ValidateResponse(HttpResponseMessage response)
        {
            if (response == null) throw new ArgumentException("message");
            if (response.IsSuccessStatusCode) return;
            if (response.StatusCode == HttpStatusCode.Unauthorized) throw new UnauthorizedAccessException("Unauthorised. Verify that the API key and Secret is valid.");
            if (response.StatusCode == HttpStatusCode.BadRequest) throw new InvalidOperationException("A bad request was made. Verify the input paramters.");
            throw new Exception(string.Format("A general exception occured. Reason: {0}", response.ReasonPhrase));
        }
        
        public void Dispose()
        {
            if (_client != null && _client.Value != null)
            {
                _client.Value.Dispose();
            }
        }
    }
}
