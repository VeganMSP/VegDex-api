namespace VegDex.Core.Repositories;

public interface IRestaurantRepository : IRepository<Restaurant>
{
    Task<Restaurant> GetRestaurantByNameAsync(string? restaurantName);
    Task<IEnumerable<Restaurant>> GetRestaurantListAsync();
    Task<IEnumerable<Restaurant>> GetRestaurantsByCityListAsync(int locationId);
}
