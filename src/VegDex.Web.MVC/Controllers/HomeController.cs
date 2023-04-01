using System.Diagnostics;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using VegDex.Web.MVC.Models;
using ILogger = Serilog.ILogger;

namespace VegDex.Web.MVC.Controllers;

public class HomeController : Controller
{
    private static readonly ILogger _logger = Log.ForContext<HomeController>();
    public HomeController()
    {
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => View(new ErrorViewModel
    {
        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
    });
    public IActionResult Index()
    {
        _logger.Information("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        return View();
    }
    [Route("About")]
    public IActionResult About()
    {
        _logger.Information("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        return View();
    }
}
