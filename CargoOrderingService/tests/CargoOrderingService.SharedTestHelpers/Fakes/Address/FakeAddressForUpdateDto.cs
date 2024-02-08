namespace CargoOrderingService.SharedTestHelpers.Fakes.Address;

using AutoBogus;
using CargoOrderingService.Domain.Addresses.Dtos;

public sealed class FakeAddressForUpdateDto : AutoFaker<AddressForUpdateDto>
{
    public FakeAddressForUpdateDto()
    {
        RuleFor(u => u.Line1, f => f.Address.StreetAddress());
        RuleFor(u => u.Line2, f => f.Address.SecondaryAddress());
        RuleFor(u => u.City, f => f.Address.City());
        RuleFor(u => u.State, f => f.Address.State());
        RuleFor(u => u.PostalCode, f => f.Address.ZipCode());
        RuleFor(u => u.Country, f => f.Address.Country());
    }
}