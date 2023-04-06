using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using VegDex.Web.MVC.Interfaces;
using ILogger = Serilog.ILogger;

namespace VegDex.Web.MVC.Controllers;

public class ShoppingController : Controller
{
    private static readonly ILogger _logger = Log.ForContext<ShoppingController>();
    private readonly IShoppingPageService _shoppingPageService;
    public ShoppingController(IShoppingPageService shoppingPageService)
    {
        _shoppingPageService =
            shoppingPageService ?? throw new ArgumentNullException(nameof(shoppingPageService));
    }
    // GET
    public async Task<IActionResult> Index()
    {
        _logger.Debug("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        var viewModel = await _shoppingPageService.GetPageInformation();
        return View(viewModel);
    }
    public IActionResult EditFarmersMarket()
    {
        throw new NotImplementedException();
    }
    public IActionResult DeleteFarmersMarket()
    {
        throw new NotImplementedException();
    }
}
