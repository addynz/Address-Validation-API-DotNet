using System.Collections.Generic;

namespace Addy.Address.Service
{
    /// <summary>
    /// Address Search Result containing a list of address references
    /// </summary>
    public class AddressSearchResult
    {
        /// <summary>
        /// The total number of addresses that were matched
        /// </summary>
        public int matched { get; set; }

        /// <summary>
        /// A list of address references
        /// </summary>
        public List<AddressSearchReference> addresses { get; set; }

        /// <summary>
        /// A list of words that were removed from the search criteria
        /// </summary>
        public List<string> badwords { get; set; }

        /// <summary>
        /// Search criteria used after eliminating bad matching words
        /// </summary>
        public string q { get; set; }
    }
}
