using VegDex.Application.Models;
using VegDex.Web.API.ViewModels.Base;

namespace VegDex.Web.API.ViewModels;

public class LinkCategoryViewModel : BaseViewModel
{
    public string? Description { get; set; }
    public IEnumerable<LinkModel>? Links { get; set; }
    public string? Name { get; set; }
    public string? Slug { get; set; }
}
