using Microsoft.EntityFrameworkCore;
using VegDex.Core.Entities;
using VegDex.Core.Repositories;
using VegDex.Infrastructure.Context;
using VegDex.Infrastructure.Repositories.Base;

namespace VegDex.Infrastructure.Repositories;

public class LinkRepository : Repository<Link>, ILinkRepository
{
    /// <inheritdoc />
    public LinkRepository(VegDexContext dbContext) : base(dbContext) { }
    /// <inheritdoc />
    public async Task<IEnumerable<Link>> GetLinkListAsync()
    {
        var links = await _dbContext.Set<Link>()
            .ToListAsync();
        return links;
    }
}
