namespace VegDex.Application.Interfaces;

public interface IRestaurantService
{
    Task<RestaurantModel> Create(RestaurantModel restaurant);
    Task Delete(RestaurantModel restaurant);
    Task<RestaurantModel> GetRestaurantById(int? restaurantId);
    Task<IEnumerable<RestaurantModel>> GetRestaurantsByLocation(int locationId);
    Task<RestaurantModel> GetRestaurantByName(string? restaurantName);
    Task<IEnumerable<RestaurantModel>> GetRestaurantList();
    Task Update(RestaurantModel restaurant);
}
