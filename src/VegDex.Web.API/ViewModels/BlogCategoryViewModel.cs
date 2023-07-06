using VegDex.Web.MVC.ViewModels.Base;

namespace VegDex.Web.MVC.ViewModels;

public class BlogCategoryViewModel : BaseViewModel
{
    public string? Name { get; set; }
    public string? Slug { get; set; }
}
