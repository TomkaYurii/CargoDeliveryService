using System.Linq.Expressions;

namespace Drivers.DAL.EF.Repositories.Contracts;

public interface IEFGenericRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<TEntity> GetByIdAsync(int id);

    Task<TEntity> GetCompleteEntityAsync(int id);

    Task<TEntity> AddAsync(TEntity entity);

    Task UpdateAsync(TEntity entity);

    Task DeleteByIdAsync(int id);

    Task DeleteAsync(TEntity entity);

    //Filters

    IQueryable<TEntity> FindAll();

    Task<IQueryable<TEntity>> FindByCondition(Expression<Func<TEntity, bool>> expression);
}
