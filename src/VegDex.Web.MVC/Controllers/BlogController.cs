using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using VegDex.Application.Models;
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
    [Route("Blog/Categories")]
    public async Task<IActionResult> BlogCategoriesIndex()
    {
        _logger.Debug("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        var blogCategories = await _blogPageService.GetBlogCategories();
        return View(blogCategories);
    }
    private bool BlogCategoryExists(int id)
    {
        var blogCategory = _blogPageService.GetBlogCategoryById(id);
        return blogCategory != null;
    }
    public IActionResult Create() => throw new NotImplementedException();
    [Route("Blog/Category/Create")]
    public async Task<IActionResult> CreateBlogCategory()
    {
        _logger.Debug("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        return View();
    }
    [HttpPost]
    [Route("Blog/Category/Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateBlogCategory(BlogCategoryModel blogCategoryModel)
    {
        if (!ModelState.IsValid) return View(blogCategoryModel);
        _blogPageService.CreateBlogCategory(blogCategoryModel);
        return RedirectToAction("BlogCategoriesIndex");
    }
    [Route("Blog/Category/Delete")]
    public async Task<IActionResult> DeleteBlogCategory(int? id)
    {
        if (id == null)
            return NotFound();
        var blogCategory = await _blogPageService.GetBlogCategoryById(id.Value);
        if (blogCategory == null)
            return NotFound();
        return View(blogCategory);
    }
    [HttpPost]
    [Route("Blog/Category/Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteBlogCategoryConfirmed(int? id)
    {
        if (id == null)
            return NotFound();
        var blogCategory = await _blogPageService.GetBlogCategoryById(id.Value);
        if (blogCategory == null)
            return NotFound();
        await _blogPageService.DeleteBlogCategory(blogCategory);
        return RedirectToAction("BlogCategoriesIndex");
    }
    [Route("Blog/Category/Edit")]
    public async Task<IActionResult> EditBlogCategory(int? id)
    {
        if (id == null)
            return NotFound();
        var blogCategory = await _blogPageService.GetBlogCategoryById(id.Value);
        if (blogCategory == null)
            return NotFound();
        return View(blogCategory);
    }
    [HttpPost]
    [Route("Blog/Category/Edit")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditBlogCategory(int? id, BlogCategoryModel blogCategoryModel)
    {
        if (id != blogCategoryModel.Id)
            return NotFound();
        if (ModelState.IsValid)
        {
            try
            {
                await _blogPageService.UpdateBlogCategory(blogCategoryModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogCategoryExists(blogCategoryModel.Id))
                    return NotFound();
                throw;
            }
            return RedirectToAction("BlogCategoriesIndex");
        }
        return View(blogCategoryModel);
    }
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
}
