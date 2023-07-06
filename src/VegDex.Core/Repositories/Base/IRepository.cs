using System.Linq.Expressions;

namespace VegDex.Core.Repositories.Base;

public interface IRepository<T> where T : Entity
{
    Task<T> AddAsync(T entity);
    Task<int> CountAsync(ISpecification<T> spec);
    Task DeleteAsync(T entity);
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
    Task<IReadOnlyList<T>> GetAsync(
        Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includeString = null,
        bool disableTracking = true);
    Task<IReadOnlyList<T>> GetAsync(
        Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        List<Expression<Func<T, object>>> includes = null,
        bool disableTracking = true);
    Task<IReadOnlyList<T>> GetAsync(ISpecification<T> spec);
    Task<T> GetByIdAsync(int? id);
    Task UpdateAsync(T entity);
}
