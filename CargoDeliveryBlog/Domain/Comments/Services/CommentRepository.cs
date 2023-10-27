namespace CargoDeliveryBlog.Domain.Comments.Services;

using CargoDeliveryBlog.Domain.Comments;
using CargoDeliveryBlog.Databases;
using CargoDeliveryBlog.Services;

public interface ICommentRepository : IGenericRepository<Comment>
{
}

public sealed class CommentRepository : GenericRepository<Comment>, ICommentRepository
{
    private readonly DriverBlogDbContext _dbContext;

    public CommentRepository(DriverBlogDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
