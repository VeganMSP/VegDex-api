using Serilog;
using VegDex.Application.Interfaces;
using VegDex.Application.Mapper;
using VegDex.Application.Models;
using VegDex.Core.Repositories;

namespace VegDex.Application.Services;

public class BlogCategoryService : IBlogCategoryService
{
    private static readonly ILogger _logger = Log.ForContext<BlogCategoryService>();
    private IBlogCategoryRepository _blogCategoryRepository;
    public BlogCategoryService(IBlogCategoryRepository blogCategoryRepository)
    {
        _blogCategoryRepository = blogCategoryRepository;
    }
    /// <inheritdoc />
    public async Task<IEnumerable<BlogCategoryModel>> GetBlogCategories()
    {
        var blogCategories = await _blogCategoryRepository.GetBlogCategories();
        var mapped = ObjectMapper.Mapper.Map<IEnumerable<BlogCategoryModel>>(blogCategories);
        return mapped;
    }
    /// <inheritdoc />
    public Task<BlogCategoryModel> GetBlogCategoryById(int blogCategoryId) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task<BlogCategoryModel> Create(BlogCategoryModel blogCategory) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task Update(BlogCategoryModel blogCategory) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task Delete(BlogCategoryModel blogCategory) => throw new NotImplementedException();
}
