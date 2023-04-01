using VegDex.Web.MVC.ViewModels.Base;

namespace VegDex.Web.MVC.ViewModels;

public class RestaurantViewModel : BaseViewModel
{
    public bool AllVegan { get; set; }
    public string Description { get; set; }
    public CityViewModel Location { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public string Website { get; set; }
}
