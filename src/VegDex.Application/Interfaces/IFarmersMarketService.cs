using VegDex.Application.Models;

namespace VegDex.Application.Interfaces;

public interface IFarmersMarketService
{
    Task<FarmersMarketModel> Create(FarmersMarketModel farmersMarket);
    Task Delete(FarmersMarketModel farmersMarket);
    Task<FarmersMarketModel> GetFarmersMarketById(int restaurantId);
    Task<IEnumerable<FarmersMarketModel>> GetFarmersMarketList();
    Task Update(FarmersMarketModel farmersMarket);
}
