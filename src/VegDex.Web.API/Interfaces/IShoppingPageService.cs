using VegDex.Application.Models;
using VegDex.Web.API.ViewModels;

namespace VegDex.Web.API.Interfaces;

public interface IShoppingPageService
{
    Task<FarmersMarketModel> CreateFarmersMarket(FarmersMarketModel farmersMarketModel);
    Task<VeganCompanyModel> CreateVeganCompany(VeganCompanyModel veganCompanyModel);
    Task DeleteFarmersMarket(FarmersMarketModel farmersMarket);
    Task DeleteVeganCompany(VeganCompanyModel veganCompany);
    Task<FarmersMarketModel> GetFarmersMarketById(int id);
    Task<ShoppingViewModel> GetPageInformation();
    Task<VeganCompanyModel> GetVeganCompanyById(int id);
    Task UpdateFarmersMarket(FarmersMarketModel farmersMarketModel);
    Task UpdateVeganCompany(VeganCompanyModel veganCompanyModel);
}
