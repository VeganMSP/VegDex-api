using System.Collections;
using VegDex.Application.Models;

namespace VegDex.Application.Interfaces;

public interface IBlogPostService
{
    Task<IEnumerable<BlogPostModel>> GetBlogCategoryList();
    Task<BlogPostModel> GetBlogCategoryById(int blogCategoryId);
    Task<BlogPostModel> Create(BlogPostModel blogPost);
    Task Update(BlogPostModel blogPost);
    Task Delete(BlogPostModel blogPost);
    Task<IEnumerable<BlogPostModel>> GetBlogPosts();
}
