using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Addy.Address.Service
{
    /// <summary>
    /// Calls Addy's Address Validation API for validate, match and cleanse addresses. 
    /// See: https://www.addy.co.nz/address-validation-api
    /// </summary>
    public class AddressValidationService : IAddressValidationService
    {
        private readonly IRequestClient _client;
 
        public AddressValidationService()
        {
            // Clients should use the Dependency Injection contructor below instead to reduce coupling.
            var requestFactory = new RequestFactory();
            _client = requestFactory.CreateClient();
        }

        public AddressValidationService(IRequestFactory requestFactory)
        {
            if (requestFactory == null) throw new ArgumentNullException(nameof(requestFactory));
            _client = requestFactory.CreateClient();
        }

        /// <summary>
        /// Validate an address
        /// </summary>
        /// <param name="address">Address to validation</param>
        /// <returns>Address search result</returns>
        public async Task<AddressVerificationResult> AddressValidateAsync(string address)
        {
            return await AddressValidateAsync(address, null, null).ConfigureAwait(false);
        }

        /// <summary>
        /// Validate an address
        /// </summary>
        /// <param name="address">Address to validation</param>
        /// <param name="exludeSpellingCorrection">True will disable spelling correction</param>
        /// <param name="excludeInvalidWord">True will disable invalid word replacement</param>
        /// <returns>Address search result</returns>
        public async Task<AddressVerificationResult> AddressValidateAsync(string address, bool? exludeSpellingCorrection, bool? excludeInvalidWord)
        {
            var query = new StringBuilder();
            query.Append(string.Format("validation?address={0}", WebUtility.UrlEncode(address)));

            if (exludeSpellingCorrection.HasValue)
            {
                query.Append(string.Format("&exspelling={0}", exludeSpellingCorrection.Value));
            }
            if (excludeInvalidWord.HasValue)
            {
                query.Append(string.Format("&exword={0}", excludeInvalidWord.Value));
            }

            return await _client.GetAsync<AddressVerificationResult>(query.ToString());
        }

        public void Dispose()
        {
            if (_client != null)
            {
                _client.Dispose();
            }
        }
    }
}
