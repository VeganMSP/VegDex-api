using VegDex.Web.MVC.ViewModels;

namespace VegDex.Web.MVC.Interfaces;

public interface IBlogPageService
{
    Task<IEnumerable<RestaurantViewModel>> GetRestaurants(string restaurantName);
}
