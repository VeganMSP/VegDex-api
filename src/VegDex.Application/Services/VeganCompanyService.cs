using Serilog;
using VegDex.Application.Interfaces;
using VegDex.Application.Models;

namespace VegDex.Application.Services;

public class VeganCompanyService : IVeganCompanyService
{
    /// <inheritdoc />
    public Task<IEnumerable<VeganCompanyModel>> GetVeganCompanyList() => throw new NotImplementedException();
    /// <inheritdoc />
    public Task<VeganCompanyModel> GetVeganCompanyById(int restaurantId) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task<VeganCompanyModel> Create(VeganCompanyModel veganCompany) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task Update(VeganCompanyModel veganCompany) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task Delete(VeganCompanyModel veganCompany) => throw new NotImplementedException();
}
