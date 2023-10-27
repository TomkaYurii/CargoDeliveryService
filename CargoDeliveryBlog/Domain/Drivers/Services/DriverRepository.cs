namespace CargoDeliveryBlog.Domain.Drivers.Services;

using CargoDeliveryBlog.Domain.Drivers;
using CargoDeliveryBlog.Databases;
using CargoDeliveryBlog.Services;

public interface IDriverRepository : IGenericRepository<Driver>
{
}

public sealed class DriverRepository : GenericRepository<Driver>, IDriverRepository
{
    private readonly DriverBlogDbContext _dbContext;

    public DriverRepository(DriverBlogDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
