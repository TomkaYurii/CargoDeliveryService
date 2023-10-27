namespace CargoDeliveryBlog.Domain.Comments.Dtos;

using CargoDeliveryBlog.Resources;

public sealed class CommentParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
