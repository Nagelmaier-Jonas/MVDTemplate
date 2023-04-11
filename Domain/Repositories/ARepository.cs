using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Model.Configuration;

namespace Domain.Repositories;

public class ARepository<TEntity> : IRepository<TEntity> where TEntity : class{

    protected MyDbContext _context;
    protected DbSet<TEntity> _set;

    public ARepository(MyDbContext context){
        _context = context;
        _set = context.Set<TEntity>();
    }

    public async Task<TEntity?> ReadAsync(int id) => await _set.FindAsync(id);

    public async Task<List<TEntity>> ReadAllAsync() => await _set.ToListAsync();

    public async Task<List<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> filter) =>
        await _set.Where(filter).ToListAsync();

    public async Task<TEntity> CreateAsync(TEntity entity){
        await _set.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<List<TEntity>> CreateRangeAsync(List<TEntity> entities){
        await _set.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
        return entities;
    }

    public async Task UpdateAsync(TEntity entity){
        _context.ChangeTracker.Clear();
        _set.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateRangeAsync(List<TEntity> entities){
        _context.ChangeTracker.Clear();
        _set.UpdateRange(entities);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity){
        _set.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id){
        var entity = await ReadAsync(id);
        _context.ChangeTracker.Clear();
        if (entity != null) _set.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRangeAsync(List<TEntity> entities){
        _context.ChangeTracker.Clear();
        _set.RemoveRange(entities);
        await _context.SaveChangesAsync();
    }
}