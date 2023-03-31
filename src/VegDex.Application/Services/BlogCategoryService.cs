using VegDex.Application.Interfaces;
using VegDex.Application.Models;

namespace VegDex.Application.Services;

public class BlogCategoryService : IBlogCategoryService
{
    /// <inheritdoc />
    public Task<IEnumerable<BlogCategoryModel>> GetBlogCategoryList() => throw new NotImplementedException();
    /// <inheritdoc />
    public Task<BlogCategoryModel> GetBlogCategoryById(int blogCategoryId) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task<BlogCategoryModel> Create(BlogCategoryModel blogCategory) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task Update(BlogCategoryModel blogCategory) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task Delete(BlogCategoryModel blogCategory) => throw new NotImplementedException();
}
