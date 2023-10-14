namespace VegDex.Application.Interfaces;

public interface IFarmersMarketService
{
    Task<FarmersMarketModel> Create(FarmersMarketModel farmersMarket);
    Task Delete(FarmersMarketModel farmersMarket);
    Task<FarmersMarketModel> GetFarmersMarketById(int? restaurantId);
    Task<IEnumerable<FarmersMarketModel>> GetFarmersMarkets();
    Task Update(FarmersMarketModel farmersMarket);
}
