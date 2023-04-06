using VegDex.Application.Models;
using VegDex.Web.MVC.ViewModels;

namespace VegDex.Web.MVC.Interfaces;

public interface IBlogPageService
{
    Task<BlogCategoryModel> CreateBlogCategory(BlogCategoryModel blogCategoryModel);
    Task DeleteBlogCategory(BlogCategoryModel blogCategory);
    Task<IEnumerable<BlogCategoryViewModel>> GetBlogCategories();
    Task<BlogCategoryModel> GetBlogCategoryById(int id);
    Task<IEnumerable<BlogPostModel>> GetBlogPosts();
    Task UpdateBlogCategory(BlogCategoryModel blogCategoryModel);
    Task<BlogPostModel> GetBlogPostById(int id);
    Task DeleteBlogPost(BlogPostModel blogPostModel);
    Task UpdateBlogPost(BlogPostModel blogPostModel);
    Task<BlogPostModel> CreateBlogPost(BlogPostModel blogPostModel);
}
