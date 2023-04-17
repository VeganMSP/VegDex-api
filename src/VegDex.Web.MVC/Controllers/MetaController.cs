using System.Diagnostics;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using VegDex.Web.MVC.Interfaces;
using VegDex.Web.MVC.ViewModels;
using VegDex.Web.MVC.ViewModels.Meta;

namespace VegDex.Web.MVC.Controllers;

public class MetaController : Controller
{
    private static readonly ILogger _logger = Log.ForContext<MetaController>();
    private readonly IMetaPageService _metaPageService;
    public MetaController(IMetaPageService metaPageService)
    {
        _metaPageService = metaPageService;
    }
    [Route("About")]
    public async Task<IActionResult> About()
    {
        _logger.Information("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        var pageViewModel = await _metaPageService.GetAboutPage();
        return View(pageViewModel);
    }
    [Route("About/Edit")]
    public async Task<IActionResult> EditAboutPage()
    {
        var page = await _metaPageService.GetAboutPage();
        return View(page);
    }
    [HttpPost]
    [Route("About/Edit")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditAboutPage(AboutPageViewModel page)
    {
        if (!ModelState.IsValid) return View(page);
        await _metaPageService.UpdateAboutPage(page.Content);
        return RedirectToAction("Index");
    }
    [Route("Home/Edit")]
    public async Task<IActionResult> EditHomePage()
    {
        var page = await _metaPageService.GetHomePage();
        return View(page);
    }
    [HttpPost]
    [Route("Home/Edit")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditHomePage(HomePageViewModel page)
    {
        if (!ModelState.IsValid) return View(page);
        await _metaPageService.UpdateHomePage(page.Content);
        return RedirectToAction("Index");
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
}
