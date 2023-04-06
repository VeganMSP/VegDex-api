using Microsoft.EntityFrameworkCore;
using VegDex.Core.Entities;
using VegDex.Core.Repositories;
using VegDex.Infrastructure.Context;

namespace VegDex.Infrastructure.Repositories;

public class MetaRepository : IMetaRepository
{
    private readonly VegDexContext _dbContext;
    /// <inheritdoc />
    public MetaRepository(VegDexContext dbContext)
    {
        _dbContext = dbContext;
    }
    /// <inheritdoc />
    public async Task<AboutPage> GetAboutPage()
    {
        var page = await _dbContext.Set<AboutPage>()
            .FirstAsync();
        return page;
    }
    /// <inheritdoc />
    public async Task<HomePage> GetHomePage()
    {
        var page = await _dbContext.Set<HomePage>()
            .FirstAsync();
        return page;
    }
    /// <inheritdoc />
    public async Task UpdatePageAsync(dynamic page)
    {
        var now = DateTime.Now;
        page.DateUpdated = now;
        _dbContext.Entry(page).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
    /// <inheritdoc />
    public async Task<IEnumerable<Link>> GetLinkListAsync()
    {
        var links = await _dbContext.Set<Link>()
            .ToListAsync();
        return links;
    }
}