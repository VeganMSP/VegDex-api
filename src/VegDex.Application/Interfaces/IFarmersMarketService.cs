using VegDex.Application.Models;

namespace VegDex.Application.Interfaces;

public interface IFarmersMarketService
{
    Task<IEnumerable<FarmersMarketModel>> GetFarmersMarketList();
    Task<FarmersMarketModel> GetFarmersMarketById(int restaurantId);
    Task<FarmersMarketModel> Create(FarmersMarketModel farmersMarket);
    Task Update(FarmersMarketModel farmersMarket);
    Task Delete(FarmersMarketModel farmersMarket);
}
