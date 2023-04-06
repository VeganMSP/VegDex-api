using System.Diagnostics;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using VegDex.Web.MVC.Interfaces;
using VegDex.Web.MVC.ViewModels;
using ILogger = Serilog.ILogger;

namespace VegDex.Web.MVC.Controllers;

public class MetaController : Controller
{
    private static readonly ILogger _logger = Log.ForContext<MetaController>();
    private readonly IMetaPageService _metaPageService;

    public MetaController(IMetaPageService metaPageService)
    {
        _metaPageService = metaPageService;
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => View(new ErrorViewModel
    {
        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
    });
    public async Task<IActionResult> Index()
    {
        _logger.Information("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        var pageViewModel = await _metaPageService.GetHomePage();
        return View(pageViewModel);
    }
    [Route("About")]
    public async Task<IActionResult> About()
    {
        _logger.Information("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        var pageViewModel = await _metaPageService.GetAboutPage();
        return View(pageViewModel);
    }
}
