namespace Drivers.DAL_EF.Contracts;

public interface IEFGenericRepository<TEntity> where TEntity : class
{
    IQueryable<TEntity> FindAll();

    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<TEntity> GetByIdAsync(int id);

    Task<TEntity> GetCompleteEntityAsync(int id);

    Task AddAsync(TEntity entity);

    Task UpdateAsync(TEntity entity);

    Task DeleteByIdAsync(int id);

    Task DeleteAsync(TEntity entity);
}
