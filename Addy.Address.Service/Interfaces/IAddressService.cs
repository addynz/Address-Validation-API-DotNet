using System;
using System.Threading.Tasks;

namespace Addy.Address.Service
{
    public interface IAddressService : IDisposable
    {
        Task<AddressSearchResult> AddressSearchAsync(string criteria);
        Task<AddressSearchResult> AddressSearchAsync(string criteria, bool? excludePostBox, bool? excludeRural, bool? excludeUndeliverable, int? maxRecords);
        Task<AddressDetail> GetAddressDetailByIdAsync(int id);
        Task<AddressDetail> GetAddressDetailByDpIdAsync(int dpid);
        Task<AddressDetail> GetAddressDetailByLinzIdAsync(int linzid);
    }
}
