using System.Diagnostics;
using System.Reflection;
using Markdig;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using VegDex.Web.MVC.Interfaces;
using VegDex.Web.MVC.ViewModels;
using ILogger = Serilog.ILogger;

namespace VegDex.Web.MVC.Controllers;

public class HomeController : Controller
{
    private static readonly ILogger _logger = Log.ForContext<HomeController>();
    private readonly IMetaPageService _metaPageService;

    public HomeController(IMetaPageService metaPageService)
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
        string content = await _metaPageService.GetHomePage();
        ViewData["content"] = Markdown.ToHtml(content);
        return View();
    }
    [Route("About")]
    public async Task<IActionResult> About()
    {
        _logger.Information("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        string content = await _metaPageService.GetAboutPage();
        ViewData["content"] = Markdown.ToHtml(content);
        return View();
    }
}
