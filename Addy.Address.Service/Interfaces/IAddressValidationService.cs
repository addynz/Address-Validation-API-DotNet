using System;
using System.Threading.Tasks;

namespace Addy.Address.Service
{
    public interface IAddressValidationService : IDisposable
    {
        /// <summary>
        /// Validate an address
        /// </summary>
        /// <param name="address">Address to validation</param>
        /// <returns>Address search result</returns>
        Task<AddressVerificationResult> AddressValidateAsync(string address);

        /// <summary>
        /// Validate an address
        /// </summary>
        /// <param name="address">Address to validation</param>
        /// <param name="exludeSpellingCorrection">True will disable spelling correction</param>
        /// <param name="excludeInvalidWord">True will disable invalid word replacement</param>
        /// <returns>Address search result</returns>
        Task<AddressVerificationResult> AddressValidateAsync(string address, bool? exludeSpellingCorrection, bool? excludeInvalidWord);
    }
}
