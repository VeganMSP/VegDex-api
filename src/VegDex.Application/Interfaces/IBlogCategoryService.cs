using VegDex.Application.Models;

namespace VegDex.Application.Interfaces;

public interface IBlogCategoryService
{
    Task<IEnumerable<BlogCategoryModel>> GetBlogCategoryList();
    Task<BlogCategoryModel> GetBlogCategoryById(int blogCategoryId);
    Task<BlogCategoryModel> Create(BlogCategoryModel blogCategory);
    Task Update(BlogCategoryModel blogCategory);
    Task Delete(BlogCategoryModel blogCategory);
}
