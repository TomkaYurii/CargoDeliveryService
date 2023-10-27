namespace CargoDeliveryBlog.Domain.Likes.Dtos;

using CargoDeliveryBlog.Resources;

public sealed class LikeParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
