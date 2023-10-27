namespace CargoDeliveryBlog.Services;

using CargoDeliveryBlog.Databases;

public interface IUnitOfWork : ICargoDeliveryBlogScopedService
{
    Task<int> CommitChanges(CancellationToken cancellationToken = default);
}

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly DriverBlogDbContext _dbContext;

    public UnitOfWork(DriverBlogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CommitChanges(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
