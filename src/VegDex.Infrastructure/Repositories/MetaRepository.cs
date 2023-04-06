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
    public async Task<IEnumerable<Link>> GetLinkListAsync()
    {
        var links = await _dbContext.Set<Link>()
            .ToListAsync();
        return links;
    }
    /// <inheritdoc />
    public async Task<string> GetAboutPage()
    {
        string content = await _dbContext.Set<Meta>()
            .Select(m => m.AboutPage)
            .FirstAsync();
        return content;
    }
    /// <inheritdoc />
    public async Task<string> GetHomePage()
    {
        string content = await _dbContext.Set<Meta>()
            .Select(m => m.HomePage)
            .FirstAsync();
        return content;
    }
    /// <inheritdoc />
    public Task UpdateAboutPageAsync(string content) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task UpdateHomePageAsync(string content) => throw new NotImplementedException();
}
