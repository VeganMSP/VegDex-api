namespace VegDex.Application.Interfaces;

public interface IVeganCompanyService
{
    Task<VeganCompanyModel> Create(VeganCompanyModel veganCompany);
    Task Delete(VeganCompanyModel veganCompany);
    Task<IEnumerable<VeganCompanyModel>> GetVeganCompanies();
    Task<VeganCompanyModel> GetVeganCompanyById(int? restaurantId);
    Task Update(VeganCompanyModel veganCompany);
}
