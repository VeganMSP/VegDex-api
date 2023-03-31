using VegDex.Application.Models;

namespace VegDex.Application.Interfaces;

public interface IRestaurantService
{
    Task<IEnumerable<RestaurantModel>> GetRestaurantList();
    Task<RestaurantModel> GetRestaurantById(int restaurantId);
    Task<IEnumerable<RestaurantModel>> GetRestaurantByLocation(int locationId);
    Task<RestaurantModel> Create(RestaurantModel restaurant);
    Task Update(RestaurantModel restaurant);
    Task Delete(RestaurantModel restaurant);
    Task<RestaurantModel> GetRestaurantByName(string restaurantName);
}
