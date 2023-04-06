using VegDex.Core.Entities;
using VegDex.Core.Repositories.Base;

namespace VegDex.Core.Repositories;

public interface IVeganCompanyRepository : IRepository<VeganCompany>
{
    Task<IEnumerable<VeganCompany>> GetVeganCompanies();
}
