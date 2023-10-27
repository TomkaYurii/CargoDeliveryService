namespace CargoDeliveryBlog.Domain.Likes.Services;

using CargoDeliveryBlog.Domain.Likes;
using CargoDeliveryBlog.Databases;
using CargoDeliveryBlog.Services;

public interface ILikeRepository : IGenericRepository<Like>
{
}

public sealed class LikeRepository : GenericRepository<Like>, ILikeRepository
{
    private readonly DriverBlogDbContext _dbContext;

    public LikeRepository(DriverBlogDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
