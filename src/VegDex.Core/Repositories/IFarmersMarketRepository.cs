namespace VegDex.Core;

public interface IFarmersMarketRepository : IRepository<FarmersMarket>
{
    Task<IEnumerable<FarmersMarket>> GetFarmersMarkets();
}
