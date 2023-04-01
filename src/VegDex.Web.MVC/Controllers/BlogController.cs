using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using VegDex.Web.MVC.Interfaces;
using ILogger = Serilog.ILogger;

namespace VegDex.Web.MVC.Controllers;

public class BlogController : Controller
{
    private static readonly ILogger _logger = Log.ForContext<BlogController>();
    private readonly IBlogPageService _blogPageService;
    public BlogController(IBlogPageService blogPageService)
    {
        _blogPageService =
            blogPageService ?? throw new ArgumentNullException(nameof(blogPageService));
    }
    // GET
    public IActionResult Index()
    {
        _logger.Debug("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        return View();
    }
}
