using Serilog;
using VegDex.Application.Interfaces;
using VegDex.Application.Mapper;
using VegDex.Application.Models;
using VegDex.Core.Repositories;

namespace VegDex.Application.Services;

public class BlogPostService : IBlogPostService
{
    private static readonly ILogger _logger = Log.ForContext<BlogPostService>();
    private readonly IBlogPostRepository _blogPostRepository;
    public BlogPostService(IBlogPostRepository blogPostRepository)
    {
        _blogPostRepository = blogPostRepository;
    }
    /// <inheritdoc />
    public Task<IEnumerable<BlogPostModel>> GetBlogCategoryList() => throw new NotImplementedException();
    /// <inheritdoc />
    public Task<BlogPostModel> GetBlogCategoryById(int blogCategoryId) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task<BlogPostModel> Create(BlogPostModel blogPost) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task Update(BlogPostModel blogPost) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task Delete(BlogPostModel blogPost) => throw new NotImplementedException();
    /// <inheritdoc />
    public async Task<IEnumerable<BlogPostModel>> GetBlogPosts()
    {
        var blogPosts = await _blogPostRepository.GetBlogPosts();
        var mapped = ObjectMapper.Mapper.Map<IEnumerable<BlogPostModel>>(blogPosts);
        return mapped;
    }
}
