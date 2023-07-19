using VegDex.Application.Models;
using VegDex.Web.API.ViewModels;

namespace VegDex.Web.API.Interfaces;

public interface IBlogPageService
{
    Task<BlogCategoryModel> CreateBlogCategory(BlogCategoryModel blogCategoryModel);
    Task<BlogPostModel> CreateBlogPost(BlogPostModel blogPostModel);
    Task DeleteBlogCategory(BlogCategoryModel blogCategory);
    Task DeleteBlogPost(BlogPostModel blogPostModel);
    Task<IEnumerable<BlogPostModel>> GetAllBlogPosts();
    Task<IEnumerable<BlogCategoryViewModel>> GetBlogCategories();
    Task<BlogCategoryModel> GetBlogCategoryById(int id);
    Task<BlogPostModel> GetBlogPostById(int id);
    Task<IEnumerable<BlogPostModel>> GetPublishedBlogPosts();
    Task UpdateBlogCategory(BlogCategoryModel blogCategoryModel);
    Task UpdateBlogPost(BlogPostModel blogPostModel);
}
