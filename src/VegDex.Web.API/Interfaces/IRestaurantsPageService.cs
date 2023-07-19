using VegDex.Application.Models;
using VegDex.Web.API.ViewModels;

namespace VegDex.Web.API.Interfaces;

public interface IRestaurantsPageService
{
    Task<RestaurantModel> CreateRestaurant(RestaurantModel restaurant);
    Task DeleteRestaurant(RestaurantModel restaurant);
    Task<IEnumerable<CityModel>> GetCities();
    Task<IEnumerable<CityViewModel>> GetCitiesWithRestaurants();
    Task<RestaurantModel> GetRestaurantById(int? id);
    Task<IEnumerable<RestaurantViewModel>> GetRestaurants();
    Task<IEnumerable<RestaurantViewModel>> GetRestaurants(string restaurantName);
    Task UpdateRestaurant(RestaurantModel restaurant);
}
