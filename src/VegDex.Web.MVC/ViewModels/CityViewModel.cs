using VegDex.Application.Models;

namespace VegDex.Web.MVC.ViewModels;

public class CityViewModel
{
    public string Name { get; set; }
    public string Slug { get; set; }
    public IEnumerable<RestaurantModel> Restaurants { get; set; }
}
