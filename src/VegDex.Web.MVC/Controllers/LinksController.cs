using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using VegDex.Web.MVC.Interfaces;
using VegDex.Web.MVC.ViewModels;
using ILogger = Serilog.ILogger;

namespace VegDex.Web.MVC.Controllers;

public class LinksController : Controller
{
    private static readonly ILogger _logger = Log.ForContext<LinksController>();
    private readonly ILinksPageService _linksPageService;
    public LinksController(ILinksPageService linksPageService)
    {
        _linksPageService =
            linksPageService ?? throw new ArgumentNullException(nameof(linksPageService));
    }
    // GET
    public async Task<IActionResult> Index()
    {
        _logger.Debug("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        var linkList = await _linksPageService.GetLinks();
        return View(linkList);
    }
}