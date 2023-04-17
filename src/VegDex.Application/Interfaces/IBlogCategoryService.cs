namespace VegDex.Application.Interfaces;

public interface IBlogCategoryService
{
    Task<BlogCategoryModel> Create(BlogCategoryModel blogCategory);
    Task Delete(BlogCategoryModel blogCategory);
    Task<IEnumerable<BlogCategoryModel>> GetBlogCategories();
    Task<BlogCategoryModel> GetBlogCategoryById(int blogCategoryId);
    Task Update(BlogCategoryModel blogCategory);
}
