using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    private bool BlogPostExists(int id)
    {
        var blogPost = _blogPageService.GetBlogPostById(id);
        return blogPost != null;
    }
    public async Task<IActionResult> Create()
    {
        _logger.Debug("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        var blogCategories = await _blogPageService.GetBlogCategories();
        var postStatuses = from PostStatus s in Enum.GetValues(typeof(PostStatus))
            select new
            {
                Id = (int)s,
                Name = s.ToString()
            };
        ViewData["BlogCategoryId"] = new SelectList(blogCategories, "Id", "Name");
        ViewData["PostStatus"] = new SelectList(postStatuses, "Id", "Name");
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(BlogPostModel blogPostModel)
    {
        if (ModelState.IsValid)
        {
            await _blogPageService.CreateBlogPost(blogPostModel);
            return RedirectToAction("Index");
        }
        var blogCategories = await _blogPageService.GetBlogCategories();
        var postStatuses = from PostStatus s in Enum.GetValues(typeof(PostStatus))
            select new
            {
                Id = (int)s,
                Name = s.ToString()
            };
        ViewData["BlogCategoryId"] = new SelectList(blogCategories, "Id", "Name");
        ViewData["PostStatus"] = new SelectList(postStatuses, "Id", "Name");
        return View(blogPostModel);
    }
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
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();
        var blogPost = await _blogPageService.GetBlogPostById(id.Value);
        if (blogPost == null)
            return NotFound();
        return View(blogPost);
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
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        if (id == null)
            return NotFound();
        var blogPost = await _blogPageService.GetBlogPostById(id.Value);
        if (blogPost == null)
            return NotFound();
        await _blogPageService.DeleteBlogPost(blogPost);
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();
        var blogPost = await _blogPageService.GetBlogPostById(id.Value);
        if (blogPost == null)
            return NotFound();
        var blogCategories = await _blogPageService.GetBlogCategories();
        var postStatuses = from PostStatus s in Enum.GetValues(typeof(PostStatus))
            select new
            {
                Id = (int)s,
                Name = s.ToString()
            };
        ViewData["BlogCategoryId"] = new SelectList(blogCategories, "Id", "Name");
        ViewData["PostStatus"] = new SelectList(postStatuses, "Id", "Name");
        return View(blogPost);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, BlogPostModel blogPostModel)
    {
        if (id != blogPostModel.Id)
            return NotFound();
        if (ModelState.IsValid)
        {
            try
            {
                await _blogPageService.UpdateBlogPost(blogPostModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogPostExists(blogPostModel.Id))
                    return NotFound();
                throw;
            }
            return RedirectToAction("Index");
        }
        var blogCategories = await _blogPageService.GetBlogCategories();
        var postStatuses = from PostStatus s in Enum.GetValues(typeof(PostStatus))
            select new
            {
                Id = (int)s,
                Name = s.ToString()
            };
        ViewData["BlogCategoryId"] = new SelectList(blogCategories, "Id", "Name");
        ViewData["PostStatus"] = new SelectList(postStatuses, "Id", "Name");
        return View(blogPostModel);
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
        var blogPosts = await _blogPageService.GetPublishedBlogPosts();
        var viewModel = new BlogViewModel
        {
            BlogPosts = blogPosts
        };
        return View(viewModel);
    }
}
