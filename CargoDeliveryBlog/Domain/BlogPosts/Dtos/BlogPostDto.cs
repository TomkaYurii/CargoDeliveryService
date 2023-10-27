namespace CargoDeliveryBlog.Domain.BlogPosts.Dtos;

using Destructurama.Attributed;

public sealed record BlogPostDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

}
