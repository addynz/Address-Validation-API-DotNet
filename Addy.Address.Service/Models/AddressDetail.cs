
namespace Addy.Address.Service
{
    /// <summary>
    /// Address metadata and details. See: https://www.addy.co.nz/address-details-api
    /// </summary>
    public class AddressDetail
    {
        /// <summary>
        /// Unique Addy identifier
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Unique NZ Post identifier.This property can be null for a non-mail deliverable address
        /// </summary>
        public int dpid { get; set; }

        /// <summary>
        /// Unique Land Information New Zealand(LINZ) identifier
        /// </summary>
        public int linzid { get; set; }

        /// <summary>
        /// Unique Parcel identifier
        /// </summary>
        public int parcelid { get; set; }

        /// <summary>
        /// Unique Statistics New Zealand(Stats NZ) identifier to match census data
        /// </summary>
        public int meshblock { get; set; }

        /// <summary>
        /// Street number.Street number will be "80" in case of "80A Queen Street"
        /// </summary>
        public string number { get; set; }

        /// <summary>
        /// Rural delivery number (postal only) for rural addresses
        /// </summary>
        public string rdnumber { get; set; }

        /// <summary>
        /// Street alpha e.g. "A" in the case of "80A Queen Street"
        /// </summary>
        public string alpha { get; set; }

        /// <summary>
        /// Type of unit e.g. "FLAT" in "FLAT 3, 80 Queen Street"
        /// </summary>
        public string unittype { get; set; }

        /// <summary>
        /// Unit number e.g. "3" in "FLAT 3, 80 Queen Street"
        /// </summary>
        public string unitnumber { get; set; }

        /// <summary>
        /// Floor number e.g. "Floor 5" in "Floor 5, 80 Queen Street"
        /// </summary>
        public string floor { get; set; }

        /// <summary>
        /// Street name.The name of the street / road, including prefix
        /// </summary>
        public string street { get; set; }

        /// <summary>
        /// Suburb name string (max 60)
        /// </summary>
        public string suburb { get; set; }

        /// <summary>
        /// Name of the town or city provided by Land Information New Zealand (LINZ) (max 60)
        /// </summary>
        public string city { get; set; }

        /// <summary>
        /// Name of the town or city provided by NZ Post (max 60)
        /// </summary>
        public string mailtown { get; set; }

        /// <summary>
        /// Territorial authority of the address (max 20)
        /// </summary>
        public string territory { get; set; }

        /// <summary>
        /// Regional authority of the address.See regions of NZ (max 20)
        /// </summary>
        public string region { get; set; }

        /// <summary>
        /// NZ Post code used for defining an area string (max 4)
        /// </summary>
        public string postcode { get; set; }

        /// <summary>
        /// Name of the building string (max 60)
        /// </summary>
        public string building { get; set; }

        /// <summary>
        /// Full display name or label for an address (max 90)
        /// </summary>
        public string full { get; set; }

        /// <summary>
        /// One line address display name (max 70)
        /// </summary>
        public string displayline { get; set; }

        /// <summary>
        /// Line 1 in a 4 address field form string (max 60)
        /// </summary>
        public string address1 { get; set; }

        /// <summary>
        /// Line 2 in a 4 address field form string (max 60)
        /// </summary>
        public string address2 { get; set; }

        /// <summary>
        /// Line 3 in a 4 address field form string (max 60)
        /// </summary>
        public string address3 { get; set; }

        /// <summary>
        /// Line 4 in a 4 address field form string (max 60)
        /// </summary>
        public string address4 { get; set; }

        /// <summary>
        /// Address Type (Urban, Rural, PostBox, NonPostal)
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// The PO Box number for PO Box addresses
        /// </summary>
        public string boxbagnumber { get; set; }

        /// <summary>
        /// NZ Post outlet or agency where the PO Box is located
        /// </summary>
        public string boxbaglobby { get; set; }

        /// <summary>
        /// Longitude coordinates in WGS84 format (max 20)
        /// </summary>
        public string x { get; set; }

        /// <summary>
        /// Latitude coordinates in WGS84 format (max 20)
        /// </summary>
        public string y { get; set; }

        /// <summary>
        /// Last updated date
        /// </summary>
        public string modified { get; set; }

        /// <summary>
        /// True/False to indicate if the address was sourced from PAF (or LINZ = false)
        /// </summary>
        public bool paf { get; set; }

        /// <summary>
        /// True/False to indicate if the address was deleted from the source (PAF or LINZ)
        /// </summary>
        public bool deleted { get; set; }
    }
}
