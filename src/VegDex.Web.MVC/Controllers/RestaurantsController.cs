using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Serilog;
using VegDex.Application.Models;
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
    public async Task<IActionResult> Create()
    {
        var cities = await _restaurantsPageService.GetCities();
        ViewData["CityId"] = new SelectList(cities, "Id", "Name");
        return View(); 
    }
    [HttpPost]
    public async Task<IActionResult> Create(RestaurantModel restaurant)
    {
        if (ModelState.IsValid)
        {
            _restaurantsPageService.CreateRestaurant(restaurant);
            return RedirectToAction("Index");
        }
        var cities = await _restaurantsPageService.GetCities();
        ViewData["CityId"] = new SelectList(cities, "Id", "Name");
        return View(restaurant);
        
        
    }
}
