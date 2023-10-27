namespace CargoDeliveryBlog.Domain.Users.Services;

using CargoDeliveryBlog.Domain.Users;
using CargoDeliveryBlog.Databases;
using CargoDeliveryBlog.Services;

public interface IUserRepository : IGenericRepository<User>
{
}

public sealed class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly DriverBlogDbContext _dbContext;

    public UserRepository(DriverBlogDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
