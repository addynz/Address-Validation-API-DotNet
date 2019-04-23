using System;
using System.Threading.Tasks;
using Addy.Address.Service;

namespace Addy.Address
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a free API Key: https://www.addy.co.nz/
            const string apiKey = "your-api-key";
            IRequestFactory requestFactory = new RequestFactory(apiKey);

            try
            {
                ValidateAddress(requestFactory).Wait();

                var address = FindAddress(requestFactory).Result;

                if (address != null)
                {
                    WriteAddressDetail(requestFactory, address.id).Wait();
                }  
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                if (ex.InnerException != null) message = ex.InnerException.Message;
                Console.WriteLine("An error occured. {0}", message);
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
        
        private static async Task ValidateAddress(IRequestFactory requestFactory)
        {
            using (IAddressValidationService validationService = new AddressValidationService(requestFactory))
            {
                Console.WriteLine("Type an address to validate/cleanse:");
                var criteria = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(criteria)) return;

                var result = await validationService.AddressValidateAsync(criteria);

                if (result.address == null)
                {
                    Console.WriteLine("No match found. " + result.reason);
                } else
                {
                    WriteAddressDetails(result.address);
                }
            }
        }

        private static async Task<AddressSearchReference> FindAddress(IRequestFactory requestFactory)
        {
            using (IAddressSearchService searchService = new AddressSearchService(requestFactory))
            {
                Console.WriteLine("Type in the address to search for:");
                var criteria = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(criteria)) return null;

                var searchResult = await searchService.AddressSearchAsync(criteria);

                Console.WriteLine();
                Console.WriteLine("Found {0} matches.", searchResult.matched);
                Console.WriteLine("Displaying the top 10 addresses: ");
                Console.WriteLine();

                var index = 1;
                foreach (var address in searchResult.addresses)
                {
                    Console.WriteLine("{0}: {1}", index, address.a);
                    index += 1;
                }

                Console.WriteLine(); 
                Console.WriteLine("Type in the address number to retrieve (e.g. 1):");
                var selectedIndex = Convert.ToInt32(Console.ReadLine().Trim().Replace(".", ""));
                               
                if (selectedIndex > searchResult.addresses.Count)
                {
                    Console.WriteLine("A valid index (e.g. 1) must be specified");
                    return null;
                } else
                {
                    return searchResult.addresses[selectedIndex - 1];
                }
            }
        }

        private static async Task WriteAddressDetail(IRequestFactory requestFactory, int addressId)
        {
            using (IAddressDetailsService detailsService = new AddressDetailsService(requestFactory))
            {
                var addressDetail = await detailsService.GetAddressDetailByIdAsync(addressId);
                WriteAddressDetails(addressDetail);
            }
        }

        private static void WriteAddressDetails(AddressDetail addressDetail)
        {
            Console.WriteLine();
            Console.WriteLine("Address details:");
            Console.WriteLine("Full: {0}", addressDetail.full);
            Console.WriteLine("Display: {0}", addressDetail.displayline);
            Console.WriteLine("Line 1: {0}", addressDetail.address1);
            Console.WriteLine("Line 2: {0}", addressDetail.address2);
            Console.WriteLine("Line 3: {0}", addressDetail.address3);
            Console.WriteLine("Line 4: {0}", addressDetail.address4);
            Console.WriteLine("Type: {0}", addressDetail.type);
            Console.WriteLine("Unique ID: {0}", addressDetail.id);
            Console.WriteLine("NZ Post DPID: {0}", addressDetail.dpid);
            Console.WriteLine("LINZ Street ID: {0}", addressDetail.linzid);
            Console.WriteLine("Parcel ID: {0}", addressDetail.parcelid);
            Console.WriteLine("Meshblock ID: {0}", addressDetail.meshblock);
            Console.WriteLine("Number: {0}", addressDetail.number);
            Console.WriteLine("Alpha: {0}", addressDetail.alpha);
            Console.WriteLine("Unit Number: {0}", addressDetail.unitnumber);
            Console.WriteLine("Unit Type: {0}", addressDetail.unittype);
            Console.WriteLine("Foor: {0}", addressDetail.floor);
            Console.WriteLine("Street: {0}", addressDetail.street);
            Console.WriteLine("Suburb: {0}", addressDetail.suburb);
            Console.WriteLine("Mailtown: {0}", addressDetail.mailtown);
            Console.WriteLine("City: {0}", addressDetail.city);
            Console.WriteLine("Postcode: {0}", addressDetail.postcode);
            Console.WriteLine("X: {0}", addressDetail.x);
            Console.WriteLine("Y: {0}", addressDetail.y);
            Console.WriteLine("Territory: {0}", addressDetail.territory);
            Console.WriteLine("Region: {0}", addressDetail.region);
            Console.WriteLine("Building: {0}", addressDetail.building);
            Console.WriteLine("Box Bag Lobby: {0}", addressDetail.boxbaglobby);
            Console.WriteLine("Box bag Number: {0}", addressDetail.boxbagnumber);
            Console.WriteLine("Modified Date: {0}", addressDetail.modified);
        }
    }
}
