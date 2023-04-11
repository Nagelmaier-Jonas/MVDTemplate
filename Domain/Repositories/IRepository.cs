using System.Linq.Expressions;

namespace Domain.Repositories;

public interface IRepository<TEntity> where TEntity : class{

    Task<TEntity?> ReadAsync(int id);

    Task<List<TEntity>> ReadAllAsync();

    Task<List<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> filter);

    Task<TEntity> CreateAsync(TEntity entity);

    Task<List<TEntity>> CreateRangeAsync(List<TEntity> entities);

    Task UpdateAsync(TEntity entity);

    Task UpdateRangeAsync(List<TEntity> entities);

    Task DeleteAsync(TEntity entity);

    Task DeleteAsync(int id);

    Task DeleteRangeAsync(List<TEntity> entities);

}