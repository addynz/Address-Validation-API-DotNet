using System.Net.Http;

namespace Addy.Address.Service
{
    /// <summary>
    /// Manage the creation of Web API Client instances
    /// </summary>
    public interface IRequestFactory
    {
        /// <summary>
        /// Create an instance of the web client that can be used again the Addy APIs: https://api.addy.co.nz/
        /// </summary>
        /// <returns>Web API Client.</returns>
        IRequestClient CreateClient();
    }
}
