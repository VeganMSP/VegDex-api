namespace VegDex.Infrastructure.Repositories;

public class MetaRepository : IMetaRepository
{
    private readonly VegDexContext _dbContext;
    public MetaRepository(VegDexContext dbContext)
    {
        _dbContext = dbContext;
    }
    /// <inheritdoc/>
    public async Task<AboutPage> GetAboutPage()
    {
        var page = await _dbContext.Set<AboutPage>()
            .FirstAsync();
        return page;
    }
    /// <inheritdoc/>
    public async Task<HomePage> GetHomePage()
    {
        var page = await _dbContext.Set<HomePage>()
            .FirstAsync();
        return page;
    }
    /// <inheritdoc/>
    public async Task UpdatePageAsync(dynamic page)
    {
        var now = DateTime.Now;
        page.DateUpdated = now;
        _dbContext.Entry(page).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
}
