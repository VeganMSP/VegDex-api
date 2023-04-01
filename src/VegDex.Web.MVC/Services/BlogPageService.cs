using AutoMapper;
using Serilog;
using VegDex.Application.Interfaces;
using VegDex.Application.Models;
using VegDex.Web.MVC.Interfaces;
using ILogger = Serilog.ILogger;

namespace VegDex.Web.MVC.Services;

public class BlogPageService : IBlogPageService
{
    private readonly ILogger _logger = Log.ForContext<BlogPageService>();
    private readonly IMapper _mapper;
    private readonly IBlogPostService _blogPostAppService;
    public BlogPageService(IBlogPostService blogPostAppService, IMapper mapper)
    {
        _blogPostAppService = blogPostAppService ?? throw new ArgumentNullException(nameof(blogPostAppService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    /// <inheritdoc />
    public async Task<IEnumerable<BlogPostModel>> GetBlogPosts()
    {
        var posts = await _blogPostAppService.GetBlogPosts();
        var mapped = _mapper.Map<IEnumerable<BlogPostModel>>(posts);
        return mapped;
    }
}
