namespace CargoDeliveryBlog.Domain.Users.Dtos;

using CargoDeliveryBlog.Resources;

public sealed class UserParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
