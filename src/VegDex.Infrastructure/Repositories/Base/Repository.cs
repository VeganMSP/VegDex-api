using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using VegDex.Core.Entities.Base;
using VegDex.Core.Repositories.Base;
using VegDex.Core.Specifications.Base;
using VegDex.Infrastructure.Context;

namespace VegDex.Infrastructure.Repositories.Base;

public class Repository<T> : IRepository<T> where T : Entity
{
    protected readonly VegDexContext _dbContext;
    public Repository(VegDexContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }
    public async Task<IReadOnlyList<T>> GetAllAsync() => await _dbContext.Set<T>().ToListAsync();
    public async Task<IReadOnlyList<T>> GetAsync(ISpecification<T> spec) =>
        await ApplySpecification(spec).ToListAsync();
    public async Task<int> CountAsync(ISpecification<T> spec) => await ApplySpecification(spec).CountAsync();
    public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate) =>
        await _dbContext.Set<T>().Where(predicate).ToListAsync();
    public async Task<IReadOnlyList<T>> GetAsync(
        Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includeString = null,
        bool disableTracking = true)
    {
        IQueryable<T> query = _dbContext.Set<T>();
        if (disableTracking) query = query.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

        if (predicate != null) query = query.Where(predicate);

        if (orderBy != null)
            return await orderBy(query).ToListAsync();
        return await query.ToListAsync();
    }
    public async Task<IReadOnlyList<T>> GetAsync(
        Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        List<Expression<Func<T, object>>> includes = null,
        bool disableTracking = true)
    {
        IQueryable<T> query = _dbContext.Set<T>();
        if (disableTracking) query = query.AsNoTracking();

        if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

        if (predicate != null) query = query.Where(predicate);

        if (orderBy != null)
            return await orderBy(query).ToListAsync();
        return await query.ToListAsync();
    }
    public async virtual Task<T> GetByIdAsync(int id) => await _dbContext.Set<T>().FindAsync(id);
    public async Task<T> AddAsync(T entity)
    {
        _dbContext.Set<T>().Add(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }
    public async Task UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
    private IQueryable<T> ApplySpecification(ISpecification<T> spec) =>
        SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
}
