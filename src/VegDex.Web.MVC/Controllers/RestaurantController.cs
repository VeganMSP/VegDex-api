using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using VegDex.Web.MVC.Interfaces;
using ILogger = Serilog.ILogger;

namespace VegDex.Web.MVC.Controllers;

public class RestaurantController : Controller
{
    private static readonly ILogger _logger = Log.ForContext<RestaurantController>();
    private readonly IRestaurantPageService _restaurantPageService;
    public RestaurantController(IRestaurantPageService restaurantPageService)
    {
        _restaurantPageService =
            restaurantPageService ?? throw new ArgumentNullException(nameof(restaurantPageService));
    }
    // GET
    public IActionResult Index()
    {
        _logger.Debug("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        return View();
    }
}
