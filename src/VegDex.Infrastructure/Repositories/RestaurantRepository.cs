using VegDex.Core.Entities;
using VegDex.Core.Repositories;
using VegDex.Infrastructure.Context;
using VegDex.Infrastructure.Repositories.Base;

namespace VegDex.Infrastructure.Repositories;

public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
{
    public RestaurantRepository(VegDexContext context) : base(context) { }
    /// <inheritdoc />
    public Task<IEnumerable<Restaurant>> GetProductListAsync() => throw new NotImplementedException();
    /// <inheritdoc />
    public Task<IEnumerable<Restaurant>> GetProductByNameAsync(string productName) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task<Restaurant> GetRestaurantByNameAsync(string restaurantName) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task<IEnumerable<Restaurant>> GetRestaurantListAsync() => throw new NotImplementedException();
}
