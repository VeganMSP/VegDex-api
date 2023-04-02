using System.Collections;
using VegDex.Application.Models;
using VegDex.Web.MVC.ViewModels;

namespace VegDex.Web.MVC.Interfaces;

public interface IRestaurantsPageService
{
    Task<IEnumerable<RestaurantViewModel>> GetRestaurants();
    Task<IEnumerable<RestaurantViewModel>> GetRestaurants(string restaurantName);
    Task<IEnumerable<CityViewModel>> GetCitiesWithRestaurants();
    Task<IEnumerable<CityModel>> GetCities();
    Task<RestaurantModel> CreateRestaurant(RestaurantModel restaurant);
}
