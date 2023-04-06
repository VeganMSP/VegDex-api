using VegDex.Application.Models;

namespace VegDex.Application.Interfaces;

public interface IBlogCategoryService
{
    Task<BlogCategoryModel> Create(BlogCategoryModel blogCategory);
    Task Delete(BlogCategoryModel blogCategory);
    Task<BlogCategoryModel> GetBlogCategoryById(int blogCategoryId);
    Task<IEnumerable<BlogCategoryModel>> GetBlogCategoryList();
    Task Update(BlogCategoryModel blogCategory);
}
