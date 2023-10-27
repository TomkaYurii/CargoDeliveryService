namespace CargoDeliveryBlog.Domain.BlogPosts.Dtos;

using CargoDeliveryBlog.Resources;

public sealed class BlogPostParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
