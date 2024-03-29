namespace VegDex.Core.Repositories;

public interface IVeganCompanyRepository : IRepository<VeganCompany>
{
    Task<IEnumerable<VeganCompany>> GetVeganCompanies();
}
