using VegDex.Application.Models;
using VegDex.Web.MVC.ViewModels;

namespace VegDex.Web.MVC.Interfaces;

public interface IBlogPageService
{
    Task<IEnumerable<BlogPostModel>> GetBlogPosts();
}
