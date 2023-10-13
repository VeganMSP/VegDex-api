using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using VegDex.Application.Models;
using VegDex.Web.API.Interfaces;
using VegDex.Web.API.ViewModels;

namespace VegDex.Web.API.Controllers;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
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
    [HttpGet]
    public IEnumerable<BlogCategoryViewModel> BlogCategoriesIndex()
    {
        _logger.Debug("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        var blogCategories = _blogPageService.GetBlogCategories().Result;
        return blogCategories;
    }
    private bool BlogCategoryExists(int id)
    {
        var blogCategory = _blogPageService.GetBlogCategoryById(id).Result;
        return blogCategory != null;
    }
    private bool BlogPostExists(int id)
    {
        var blogPost = _blogPageService.GetBlogPostById(id).Result;
        return blogPost != null;
    }
    [HttpPost]
    public StatusCodeResult Create(BlogPostModel blogPostModel)
    {
        if (ModelState.IsValid)
        {
            _blogPageService.CreateBlogPost(blogPostModel);
            return Ok();
        }
        return BadRequest();
    }
    [HttpPost]
    [Route("Blog/Category/Create")]
    public StatusCodeResult CreateBlogCategory(BlogCategoryModel blogCategoryModel)
    {
        if (!ModelState.IsValid) return BadRequest();
        _blogPageService.CreateBlogCategory(blogCategoryModel);
        return Ok();
    }
    [HttpDelete]
    [Route("Blog/Category/Delete")]
    public StatusCodeResult DeleteBlogCategoryConfirmed(int? id)
    {
        if (id == null)
            return NotFound();
        var blogCategory = _blogPageService.GetBlogCategoryById(id.Value).Result;
        if (blogCategory == null)
            return NotFound();
        _blogPageService.DeleteBlogCategory(blogCategory);
        return Ok();
    }
    [HttpDelete]
    [ValidateAntiForgeryToken]
    public StatusCodeResult DeleteConfirmed(int? id)
    {
        if (id == null)
            return NotFound();
        var blogPost = _blogPageService.GetBlogPostById(id.Value).Result;
        if (blogPost == null)
            return NotFound();
        _blogPageService.DeleteBlogPost(blogPost);
        return Ok();
    }
    [HttpPut]
    [ValidateAntiForgeryToken]
    public StatusCodeResult Edit(int? id, BlogPostModel blogPostModel)
    {
        if (id != blogPostModel.Id)
            return NotFound();
        if (ModelState.IsValid)
        {
            try
            {
                _blogPageService.UpdateBlogPost(blogPostModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogPostExists(blogPostModel.Id))
                    return NotFound();
                throw;
            }
            return Ok();
        }
        return BadRequest();
    }
    [HttpPut]
    [Route("Blog/Category/Edit")]
    [ValidateAntiForgeryToken]
    public StatusCodeResult EditBlogCategory(int? id, BlogCategoryModel blogCategoryModel)
    {
        if (id != blogCategoryModel.Id)
            return NotFound();
        if (ModelState.IsValid)
        {
            try
            {
                _blogPageService.UpdateBlogCategory(blogCategoryModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogCategoryExists(blogCategoryModel.Id))
                    return NotFound();
                throw;
            }
            return Ok();
        }
        return BadRequest();
    }
    [HttpGet]
    public BlogViewModel Index()
    {
        _logger.Debug("{Method} got GET", MethodBase.GetCurrentMethod()?.Name);
        var blogPosts = _blogPageService.GetPublishedBlogPosts().Result;
        var viewModel = new BlogViewModel
        { BlogPosts = blogPosts };
        return viewModel;
    }
}
