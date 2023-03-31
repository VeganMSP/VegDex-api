using VegDex.Web.MVC.Models;

namespace VegDex.Web.MVC.Interfaces;

public interface IRestaurantPageService
{
    Task<IEnumerable<RestaurantViewModel>> GetRestaurants(string restaurantName);
}
