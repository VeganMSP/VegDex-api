using VegDex.Application.Models;

namespace VegDex.Application.Interfaces;

public interface IVeganCompanyService
{
    Task<IEnumerable<VeganCompanyModel>> GetVeganCompanyList();
    Task<VeganCompanyModel> GetVeganCompanyById(int restaurantId);
    Task<VeganCompanyModel> Create(VeganCompanyModel veganCompany);
    Task Update(VeganCompanyModel veganCompany);
    Task Delete(VeganCompanyModel veganCompany);
}
