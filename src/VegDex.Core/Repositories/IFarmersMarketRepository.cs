namespace VegDex.Core.Repositories;

public interface IFarmersMarketRepository : IRepository<FarmersMarket>
{
    Task<IEnumerable<FarmersMarket>> GetFarmersMarkets();
}
