namespace VegDex.Infrastructure.Repositories;

public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
{
    public RestaurantRepository(VegDexContext context) : base(context) { }
    /// <inheritdoc />
    public Task<Restaurant> GetRestaurantByNameAsync(string? restaurantName) => throw new NotImplementedException();
    /// <inheritdoc />
    public async Task<IEnumerable<Restaurant>> GetRestaurantListAsync()
    {
        var restaurants = await _dbContext.Set<Restaurant>()
            .ToListAsync();
        return restaurants;
    }
    /// <inheritdoc />
    public async Task<IEnumerable<Restaurant>> GetRestaurantsByCityListAsync(int locationId)
    {
        var restaurants = await _dbContext.Set<Restaurant>()
            .Where(r => r.City.Id == locationId)
            .ToListAsync();
        return restaurants;
    }
}
