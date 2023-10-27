namespace CargoDeliveryBlog.Domain.BlogPosts.Dtos;

using Destructurama.Attributed;

public sealed record BlogPostForUpdateDto
{
    public string Title { get; set; }
    public string Content { get; set; }

}
