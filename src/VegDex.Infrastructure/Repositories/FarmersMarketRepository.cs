using Microsoft.EntityFrameworkCore;
using Serilog;
using VegDex.Core;
using VegDex.Core.Entities;
using VegDex.Infrastructure.Context;
using VegDex.Infrastructure.Repositories.Base;

namespace VegDex.Infrastructure.Repositories;

public class FarmersMarketRepository : Repository<FarmersMarket>, IFarmersMarketRepository
{
    private static readonly ILogger _logger = Log.ForContext<FarmersMarketRepository>();
    private VegDexContext _dbContext;
    /// <inheritdoc />
    public FarmersMarketRepository(VegDexContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    /// <inheritdoc />
    public async Task<IEnumerable<FarmersMarket>> GetFarmersMarkets()
    {
        var farmersMarkets = await _dbContext.Set<FarmersMarket>()
            .ToListAsync();
        return farmersMarkets;
    }
}
