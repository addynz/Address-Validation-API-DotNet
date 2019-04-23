using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addy.Address.Service
{
    /// <summary>
    /// Address Validation Result
    /// </summary>
    public class AddressVerificationResult
    {
        /// <summary>
        /// The matched address.
        /// </summary>
        public AddressDetail address { get; set; }

        /// <summary>
        /// Alternative address matches.
        /// </summary>
        public AddressReference[] alternatives { get; set; }

        /// <summary>
        /// The reason for the match result.
        /// </summary>
        public string reason { get; set; }

        /// <summary>
        /// True if a prefix was found.
        /// </summary>
        public bool foundPrefix { get; set; }

        /// <summary>
        /// Found a prefix, such as "Front Door" or "Rear Unit"
        /// </summary>
        public string prefix { get; set; }
    }
}
