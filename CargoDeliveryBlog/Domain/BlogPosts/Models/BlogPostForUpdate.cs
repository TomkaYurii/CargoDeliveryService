namespace CargoDeliveryBlog.Domain.BlogPosts.Models;

using Destructurama.Attributed;

public sealed class BlogPostForUpdate
{
    public string Title { get; set; }
    public string Content { get; set; }

}
