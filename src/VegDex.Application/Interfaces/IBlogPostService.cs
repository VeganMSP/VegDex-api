namespace VegDex.Application.Interfaces;

public interface IBlogPostService
{
    Task<BlogPostModel> Create(BlogPostModel blogPost);
    Task Delete(BlogPostModel blogPost);
    Task<BlogPostModel> GetBlogCategoryById(int blogCategoryId);
    Task<IEnumerable<BlogPostModel>> GetBlogCategoryList();
    Task<IEnumerable<BlogPostModel>> GetBlogPosts();
    Task Update(BlogPostModel blogPost);
    Task<BlogPostModel> GetBlogPostById(int id);
}
