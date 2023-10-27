namespace CargoDeliveryBlog.Domain.Drivers.Mappings;

using CargoDeliveryBlog.Domain.Drivers.Dtos;
using CargoDeliveryBlog.Domain.Drivers.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class DriverMapper
{
    public static partial DriverForCreation ToDriverForCreation(this DriverForCreationDto driverForCreationDto);
    public static partial DriverForUpdate ToDriverForUpdate(this DriverForUpdateDto driverForUpdateDto);
    public static partial DriverDto ToDriverDto(this Driver driver);
    public static partial IQueryable<DriverDto> ToDriverDtoQueryable(this IQueryable<Driver> driver);
}