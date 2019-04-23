using System;
using System.Threading.Tasks;

namespace Addy.Address.Service
{
    public interface IAddressDetailsService : IDisposable
    {
        /// <summary>
        /// Retrieve full address details using the unique Id.
        /// </summary>
        /// <param name="id">Addy's unique Id</param>
        /// <returns>Address details</returns>
        Task<AddressDetail> GetAddressDetailByIdAsync(int id);

        /// <summary>
        /// Retrieve full address details using the NZ Post DPID
        /// </summary>
        /// <param name="dpid">DPID</param>
        /// <returns>Address details</returns>
        Task<AddressDetail> GetAddressDetailByDpIdAsync(int dpid);

        /// <summary>
        /// Retrieve full address details using the LINZ Street ID
        /// </summary>
        /// <param name="linzid">LINZ Street ID</param>
        /// <returns>Address details</returns>
        Task<AddressDetail> GetAddressDetailByLinzIdAsync(int linzid);
    }
}
