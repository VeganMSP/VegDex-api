namespace VegDex.Application.Interfaces;

public interface IVeganCompanyService
{
    Task<VeganCompanyModel> Create(VeganCompanyModel veganCompany);
    Task Delete(VeganCompanyModel veganCompany);
    Task<VeganCompanyModel> GetVeganCompanyById(int restaurantId);
    Task<IEnumerable<VeganCompanyModel>> GetVeganCompanies();
    Task Update(VeganCompanyModel veganCompany);
}
