using Drivers.DAL_EF.Entities.HelpModels;
using Drivers.DAL_EF.Entities;
using Drivers.DAL_EF.Helpers;
using System.Linq.Expressions;

namespace Drivers.DAL_EF.Contracts;

public interface IEFGenericRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<TEntity> GetByIdAsync(int id);

    Task<TEntity> GetCompleteEntityAsync(int id);

    Task AddAsync(TEntity entity);

    Task UpdateAsync(TEntity entity);

    Task DeleteByIdAsync(int id);

    Task DeleteAsync(TEntity entity);

    //Filters

    IQueryable<TEntity> FindAll();

    Task<IQueryable<TEntity>> FindByCondition(Expression<Func<TEntity, bool>> expression);
}
