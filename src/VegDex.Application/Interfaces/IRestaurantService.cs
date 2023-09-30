namespace VegDex.Application.Interfaces;

public interface IRestaurantService
{
    Task<RestaurantModel> Create(RestaurantModel restaurant);
    Task Delete(RestaurantModel restaurant);
    Task<RestaurantModel> GetRestaurantById(int? restaurantId);
    Task<RestaurantModel> GetRestaurantByName(string? restaurantName);
    Task<IEnumerable<RestaurantModel>> GetRestaurantList();
    Task<IEnumerable<RestaurantModel>> GetRestaurantsByLocation(int locationId);
    Task Update(RestaurantModel restaurant);
}
