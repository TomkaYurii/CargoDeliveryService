namespace CargoDeliveryBlog.Domain.Drivers.Dtos;

using CargoDeliveryBlog.Resources;

public sealed class DriverParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
