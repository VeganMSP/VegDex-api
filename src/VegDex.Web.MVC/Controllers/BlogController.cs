using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using VegDex.Web.MVC.Interfaces;
using VegDex.Web.MVC.ViewModels;
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
    public async Task<IActionResult> BlogCategoriesIndex()
    {
        _logger.Debug("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        var blogCategories = await _blogPageService.GetBlogCategories();
        return View(blogCategories);
    }
    public IActionResult CreateBlogCategory() => throw new NotImplementedException();
    public IActionResult DeleteBlogCategory() => throw new NotImplementedException();
    public IActionResult EditBlogCategory() => throw new NotImplementedException();
    // GET
    public async Task<IActionResult> Index()
    {
        _logger.Debug("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        var blogPosts = await _blogPageService.GetBlogPosts();
        var viewModel = new BlogViewModel
        {
            BlogPosts = blogPosts
        };
        return View(viewModel);
    }
    public IActionResult Create() => throw new NotImplementedException();
}
