using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using VegDex.Web.MVC.Interfaces;
using VegDex.Web.MVC.ViewModels;
using ILogger = Serilog.ILogger;

namespace VegDex.Web.MVC.Controllers;

public class RestaurantsController : Controller
{
    private static readonly ILogger _logger = Log.ForContext<RestaurantsController>();
    private readonly IRestaurantsPageService _restaurantsPageService;
    public RestaurantsController(IRestaurantsPageService restaurantsPageService)
    {
        _restaurantsPageService =
            restaurantsPageService ?? throw new ArgumentNullException(nameof(restaurantsPageService));
    }
    // GET
    public async Task<IActionResult> Index()
    {
        _logger.Debug("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        IEnumerable<CityViewModel> citiesWithRestaurants = await _restaurantsPageService.GetCitiesWithRestaurants();
        var viewModel = new RestaurantViewModel
        {
            Cities = citiesWithRestaurants
        };
        return View(viewModel);
    }
}
