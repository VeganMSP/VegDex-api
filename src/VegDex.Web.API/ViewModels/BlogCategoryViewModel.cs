using VegDex.Web.API.ViewModels.Base;

namespace VegDex.Web.API.ViewModels;

public class BlogCategoryViewModel : BaseViewModel
{
    public string? Name { get; set; }
    public string? Slug { get; set; }
}
