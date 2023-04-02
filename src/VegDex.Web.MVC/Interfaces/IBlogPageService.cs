using VegDex.Application.Models;

namespace VegDex.Web.MVC.Interfaces;

public interface IBlogPageService
{
    Task<IEnumerable<BlogPostModel>> GetBlogPosts();
}
