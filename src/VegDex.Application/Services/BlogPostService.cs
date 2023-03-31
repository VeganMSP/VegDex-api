using VegDex.Application.Interfaces;
using VegDex.Application.Models;

namespace VegDex.Application.Services;

public class BlogPostService : IBlogPostService
{
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
}
