using VegDex.Web.MVC.ViewModels;

namespace VegDex.Web.MVC.Interfaces;

public interface IShoppingPageService
{
    Task<IEnumerable<ShoppingViewModel>> GetVeganCompanies(string veganCompanyName);
}
