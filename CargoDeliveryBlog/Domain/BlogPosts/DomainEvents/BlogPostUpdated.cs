namespace CargoDeliveryBlog.Domain.BlogPosts.DomainEvents;

public sealed class BlogPostUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            