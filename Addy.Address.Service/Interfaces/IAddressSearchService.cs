using System;
using System.Threading.Tasks;

namespace Addy.Address.Service
{
    public interface IAddressSearchService : IDisposable
    {
        /// <summary>
        /// Search for addresses
        /// </summary>
        /// <param name="criteria">Search criteria</param>
        /// <returns>Address search result</returns>
        Task<AddressSearchResult> AddressSearchAsync(string criteria);

        /// <summary>
        /// Search for addresses
        /// </summary>
        /// <param name="criteria">Search criteria. Minimum of 3 characters.</param>
        /// <param name="excludePostBox">Exclude PO Box addresses</param>
        /// <param name="excludeRural">Exclude Rural addresses</param>
        /// <param name="excludeUndeliverable">Exclude Undeliverable mail addresses</param>
        /// <param name="maxRecords">Maximum number of records to return (Range of 1 to 50)</param>
        /// <returns>Address search result</returns>
        Task<AddressSearchResult> AddressSearchAsync(string criteria, bool? excludePostBox, bool? excludeRural, bool? excludeUndeliverable, int? maxRecords);
    }
}
