using VegDex.Core.Entities;
using VegDex.Core.Repositories.Base;

namespace VegDex.Core;

public interface IFarmersMarketRepository : IRepository<FarmersMarket>
{
    Task<IEnumerable<FarmersMarket>> GetFarmersMarkets();
}
