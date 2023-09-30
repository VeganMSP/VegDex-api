using AutoMapper;
using Serilog;
using VegDex.Application.Interfaces;
using VegDex.Application.Models;
using VegDex.Core.Utilities;
using VegDex.Web.API.Interfaces;
using VegDex.Web.API.ViewModels;

namespace VegDex.Web.API.Services;

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
    /// <inheritdoc/>
    public async Task<BlogCategoryModel> GetBlogCategoryById(int id)
    {
        var category = await _blogCategoryAppService.GetBlogCategoryById(id);
        var mapped = _mapper.Map<BlogCategoryModel>(category);
        return mapped;
    }
    /// <inheritdoc/>
    public async Task<IEnumerable<BlogPostModel>> GetPublishedBlogPosts()
    {
        var posts = await _blogPostAppService.GetBlogPosts();
        var mapped = _mapper.Map<IEnumerable<BlogPostModel>>(posts);
        return mapped
            .Where(p => p.Status == PostStatus.Published);
    }
    /// <inheritdoc/>
    public async Task<IEnumerable<BlogPostModel>> GetAllBlogPosts()
    {
        var posts = await _blogPostAppService.GetBlogPosts();
        var mapped = _mapper.Map<IEnumerable<BlogPostModel>>(posts);
        return mapped;
    }
    /// <inheritdoc/>
    public async Task UpdateBlogCategory(BlogCategoryModel blogCategoryModel)
    {
        var mapped = _mapper.Map<BlogCategoryModel>(blogCategoryModel);
        if (mapped == null)
            throw new Exception("Entity could not be mapped");
        await _blogCategoryAppService.Update(mapped);
        _logger.Information("Entity successfully updated: {BlogCategory}", mapped);
    }
    /// <inheritdoc/>
    public async Task<BlogPostModel> GetBlogPostById(int id)
    {
        var post = await _blogPostAppService.GetBlogPostById(id);
        var mapped = _mapper.Map<BlogPostModel>(post);
        return mapped;
    }
    /// <inheritdoc/>
    public async Task DeleteBlogPost(BlogPostModel blogPostModel)
    {
        var mapped = _mapper.Map<BlogPostModel>(blogPostModel);
        if (mapped == null)
            throw new Exception("Entity could not be mapped");
        await _blogPostAppService.Delete(mapped);
        _logger.Information("Entity successfully deleted: {@BlogPost}", mapped);
    }
    /// <inheritdoc/>
    public async Task UpdateBlogPost(BlogPostModel blogPostModel)
    {
        var mapped = _mapper.Map<BlogPostModel>(blogPostModel);
        if (mapped == null)
            throw new Exception("Entity could not be mapped");
        await _blogPostAppService.Update(mapped);
        _logger.Information("Entity successfully updated: {@BlogPost}", mapped);
    }
    /// <inheritdoc/>
    public async Task<BlogPostModel> CreateBlogPost(BlogPostModel blogPostModel)
    {
        var mapped = _mapper.Map<BlogPostModel>(blogPostModel);
        if (mapped == null)
            throw new Exception("Entity could not be mapped");
        mapped.Slug = mapped.Title.ToUrlSlug();
        var entityDto = await _blogPostAppService.Create(mapped);
        _logger.Information("Entity successfully created: {@BlogPost}", blogPostModel);

        var mappedModel = _mapper.Map<BlogPostModel>(entityDto);
        return mappedModel;
    }
    /// <inheritdoc/>
    public async Task<BlogCategoryModel> CreateBlogCategory(BlogCategoryModel blogCategoryModel)
    {
        var mapped = _mapper.Map<BlogCategoryModel>(blogCategoryModel);
        if (mapped == null)
            throw new Exception("Entity could not be mapped");
        mapped.Slug = mapped.Name.ToUrlSlug();
        var entityDto = await _blogCategoryAppService.Create(mapped);
        _logger.Information("Entity successfully created: {BlogCategory}", blogCategoryModel);

        var mappedModel = _mapper.Map<BlogCategoryModel>(entityDto);
        return mappedModel;
    }
    /// <inheritdoc/>
    public async Task DeleteBlogCategory(BlogCategoryModel blogCategory)
    {
        var mapped = _mapper.Map<BlogCategoryModel>(blogCategory);
        if (mapped == null)
            throw new Exception("Entity could not be mapped");
        await _blogCategoryAppService.Delete(mapped);
        _logger.Information("Entity successfully deleted: {BlogCategory}", mapped);
    }
    /// <inheritdoc/>
    public async Task<IEnumerable<BlogCategoryViewModel>> GetBlogCategories()
    {
        var categories = await _blogCategoryAppService.GetBlogCategories();
        var mapped = _mapper.Map<IEnumerable<BlogCategoryViewModel>>(categories);
        return mapped;
    }
}
