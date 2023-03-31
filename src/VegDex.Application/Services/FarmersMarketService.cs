using VegDex.Application.Interfaces;
using VegDex.Application.Models;

namespace VegDex.Application.Services;

public class FarmersMarketService : IFarmersMarketService
{
    /// <inheritdoc />
    public Task<IEnumerable<FarmersMarketModel>> GetFarmersMarketList() => throw new NotImplementedException();
    /// <inheritdoc />
    public Task<FarmersMarketModel> GetFarmersMarketById(int restaurantId) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task<FarmersMarketModel> Create(FarmersMarketModel farmersMarket) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task Update(FarmersMarketModel farmersMarket) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task Delete(FarmersMarketModel farmersMarket) => throw new NotImplementedException();
}
