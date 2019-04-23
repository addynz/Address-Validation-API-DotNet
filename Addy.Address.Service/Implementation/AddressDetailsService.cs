using System;
using System.Threading.Tasks;

namespace Addy.Address.Service
{
    /// <summary>
    /// Calls Addy's Address Details API for address autocomplete. 
    /// See: https://www.addy.co.nz/address-details-api
    /// </summary>
    public class AddressDetailsService : IAddressDetailsService
    {
        private readonly IRequestClient _client;
 
        public AddressDetailsService()
        {
            // Clients should use the Dependency Injection contructor below instead to reduce coupling.
            var requestFactory = new RequestFactory();
            _client = requestFactory.CreateClient();
        }

        public AddressDetailsService(IRequestFactory requestFactory)
        {
            if (requestFactory == null) throw new ArgumentNullException(nameof(requestFactory));
            _client = requestFactory.CreateClient();
        }

        /// <summary>
        /// Retrieve full address details using the unique Id.
        /// </summary>
        /// <param name="id">Addy's unique Id</param>
        /// <returns>Address details</returns>
        public async Task<AddressDetail> GetAddressDetailByIdAsync(int id)
        {
            return await _client.GetAsync<AddressDetail>(string.Format("address/{0}", id));
        }

        /// <summary>
        /// Retrieve full address details using the NZ Post DPID
        /// </summary>
        /// <param name="dpid">DPID</param>
        /// <returns>Address details</returns>
        public async Task<AddressDetail> GetAddressDetailByDpIdAsync(int dpid)
        {
            return await _client.GetAsync<AddressDetail>(string.Format("address?type=dpid&id={0}", dpid));
        }

        /// <summary>
        /// Retrieve full address details using the LINZ Street ID
        /// </summary>
        /// <param name="linzid">LINZ Street ID</param>
        /// <returns>Address details</returns>
        public async Task<AddressDetail> GetAddressDetailByLinzIdAsync(int linzid)
        {
            return await _client.GetAsync<AddressDetail>(string.Format("address?type=linz&id={0}", linzid));
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
