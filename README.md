# Address Validation API for New Zealand Places

https://www.addy.co.nz/

Make it easy for users to find and validate their address in your .NET, C# or VB.NET application.  

Call the Address Search API to find and validate addresses using fuzzy matching to eliminate typos and spelling mistakes.
https://www.addy.co.nz/address-finder-and-postcode-api

Call the Address Details API to retrieve address information, such as New Zealand Post’s Delivery Point Identifier (DPID), LINZ’s Street Address ID or longitude / latitude (x / y) coordinates, street names, city names, suburbs, postal codes, territories, regions and more.
https://www.addy.co.nz/address-details-api

To get started, install the Addy.Address.Service NuGet package or fork this repository.
https://www.nuget.org/packages/Addy.Address.Service/1.2.0

The code sample will automatically convert JSON address search responses into DTO/POCO objects.

## Sample Code in .NET (C#)

Call the Address Lookup API:

```csharp
    using (var addressService = new AddressService())
    {
        // Search for '80 Queen St'
        var searchResult = addressService.AddressSearchAsync("80 Queen St").Result;
        Console.WriteLine("Found {0} matches.", searchResult.matched);

        foreach (var address in searchResult.addresses)
        {
            Console.WriteLine(address.a);
        }

        // Grab the first address in the list
        var addressId = searchResult.addresses[0].id;

        // Perform a detailed lookup for the address
        var addressDetail = addressService.GetAddressDetailByIdAsync(addressId).Result;

        Console.WriteLine("Full: {0}", addressDetail.full);
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
```

## Links

Official Addy site: <https://www.addy.co.nz/>

Address Search API Documentation: <https://www.addy.co.nz/address-finder-and-postcode-api>
