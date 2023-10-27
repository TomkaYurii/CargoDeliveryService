namespace CargoDeliveryBlog.Domain.BlogPosts.DomainEvents;

public sealed class BlogPostCreated : DomainEvent
{
    public BlogPost BlogPost { get; set; } 
}
            