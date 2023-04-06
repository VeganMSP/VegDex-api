using VegDex.Application.Models;
using VegDex.Web.MVC.ViewModels;

namespace VegDex.Web.MVC.Interfaces;

public interface IShoppingPageService
{
    Task<ShoppingViewModel> GetPageInformation();
    Task<VeganCompanyModel> GetVeganCompanyById(int id);
    Task DeleteVeganCompany(VeganCompanyModel veganCompany);
    Task UpdateVeganCompany(VeganCompanyModel veganCompanyModel);
    Task<VeganCompanyModel> CreateVeganCompany(VeganCompanyModel veganCompanyModel);
}
