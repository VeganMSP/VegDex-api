using AutoMapper;
using Serilog;
using VegDex.Application.Interfaces;
using VegDex.Application.Models;
using VegDex.Web.MVC.Interfaces;
using VegDex.Web.MVC.ViewModels;
using ILogger = Serilog.ILogger;

namespace VegDex.Web.MVC.Services;

public class BlogPageService : IBlogPageService
{
    private readonly IBlogCategoryService _blogCategoryAppService;
    private readonly IBlogPostService _blogPostAppService;
    private readonly ILogger _logger = Log.ForContext<BlogPageService>();
    private readonly IMapper _mapper;
    public BlogPageService(
        IBlogPostService blogPostAppService,
        IBlogCategoryService blogCategoryAppService,
        IMapper mapper)
    {
        _blogPostAppService = blogPostAppService ?? throw new ArgumentNullException(nameof(blogPostAppService));
        _blogCategoryAppService =
            blogCategoryAppService ?? throw new ArgumentNullException(nameof(blogCategoryAppService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    /// <inheritdoc />
    public async Task<IEnumerable<BlogPostModel>> GetBlogPosts()
    {
        var posts = await _blogPostAppService.GetBlogPosts();
        var mapped = _mapper.Map<IEnumerable<BlogPostModel>>(posts);
        return mapped;
    }
    /// <inheritdoc />
    public async Task<IEnumerable<BlogCategoryViewModel>> GetBlogCategories()
    {
        var categories = await _blogCategoryAppService.GetBlogCategories();
        var mapped = _mapper.Map<IEnumerable<BlogCategoryViewModel>>(categories);
        return mapped;
    }
}
