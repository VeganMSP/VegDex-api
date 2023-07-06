using VegDex.Application.Models;

namespace VegDex.Web.MVC.ViewModels;

public class BlogViewModel
{
    public IEnumerable<BlogPostModel>? BlogPosts { get; set; }
}
