using System.Linq.Expressions;
using VegDex.Core.Entities;
using VegDex.Core.Repositories;
using VegDex.Core.Specifications.Base;

namespace VegDex.Infrastructure.Repositories;

public class AddressRepository : IAddressRepository
{
    /// <inheritdoc />
    public Task<IReadOnlyList<Address>> GetAllAsync() => throw new NotImplementedException();
    /// <inheritdoc />
    public Task<IReadOnlyList<Address>> GetAsync(Expression<Func<Address, bool>> predicate) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task<IReadOnlyList<Address>> GetAsync(
        Expression<Func<Address, bool>> predicate = null,
        Func<IQueryable<Address>, IOrderedQueryable<Address>> orderBy = null,
        string includeString = null,
        bool disableTracking = true) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task<IReadOnlyList<Address>> GetAsync(Expression<Func<Address, bool>> predicate = null, Func<IQueryable<Address>, IOrderedQueryable<Address>> orderBy = null, List<Expression<Func<Address, object>>> includes = null, bool disableTracking = true) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task<IReadOnlyList<Address>> GetAsync(ISpecification<Address> spec) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task<Address> GetByIdAsync(int id) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task<Address> AddAsync(Address entity) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task UpdateAsync(Address entity) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task DeleteAsync(Address entity) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task<int> CountAsync(ISpecification<Address> spec) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task<IEnumerable<Address>> GetAddressListAsync() => throw new NotImplementedException();
    /// <inheritdoc />
    public Task<IEnumerable<Address>> GetAddressByNameAsync(string addressName) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task<IEnumerable<Address>> GetAddressByIdAsync(int addressId) => throw new NotImplementedException();
}
