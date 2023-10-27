namespace CargoDeliveryBlog.Domain.BlogPosts.Services;

using CargoDeliveryBlog.Domain.BlogPosts;
using CargoDeliveryBlog.Databases;
using CargoDeliveryBlog.Services;

public interface IBlogPostRepository : IGenericRepository<BlogPost>
{
}

public sealed class BlogPostRepository : GenericRepository<BlogPost>, IBlogPostRepository
{
    private readonly DriverBlogDbContext _dbContext;

    public BlogPostRepository(DriverBlogDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
