using VegDex.Application.Models;

namespace VegDex.Web.API.ViewModels;

public class BlogViewModel
{
    public IEnumerable<BlogPostModel>? BlogPosts { get; set; }
}
