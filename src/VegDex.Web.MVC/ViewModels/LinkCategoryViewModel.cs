using VegDex.Application.Models;
using VegDex.Web.MVC.ViewModels.Base;

namespace VegDex.Web.MVC.ViewModels;

public class LinkCategoryViewModel : BaseViewModel
{
    public string Name { get; set; }
    public string? Slug { get; set; }
    public string? Description { get; set; }
    public IEnumerable<LinkModel>? Links { get; set; }
}
