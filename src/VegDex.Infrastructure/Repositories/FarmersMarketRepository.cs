namespace VegDex.Infrastructure.Repositories;

public class FarmersMarketRepository : Repository<FarmersMarket>, IFarmersMarketRepository
{
    private VegDexContext _dbContext;
    /// <inheritdoc/>
    public FarmersMarketRepository(VegDexContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    /// <inheritdoc/>
    public async Task<IEnumerable<FarmersMarket>> GetFarmersMarkets()
    {
        var farmersMarkets = await _dbContext.Set<FarmersMarket>()
            .ToListAsync();
        return farmersMarkets;
    }
}
