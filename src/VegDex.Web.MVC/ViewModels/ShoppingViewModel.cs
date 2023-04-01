using VegDex.Web.MVC.ViewModels.Base;

namespace VegDex.Web.MVC.ViewModels;

public class ShoppingViewModel : BaseViewModel
{
    public string? Description { get; set; }
    public string Name { get; set; }
    public string? Website { get; set; }
    public string Slug { get; set; }
}
