using VegDex.Core.Entities;
using VegDex.Core.Repositories;
using VegDex.Core.Specifications;
using VegDex.Infrastructure.Context;
using VegDex.Infrastructure.Repositories.Base;

namespace VegDex.Infrastructure.Repositories;

public class LinkCategoryRepository : Repository<LinkCategory>, ILinkCategoryRepository
{
    /// <inheritdoc />
    public LinkCategoryRepository(VegDexContext dbContext) : base(dbContext) { }
    /// <inheritdoc />
    public async Task<IEnumerable<LinkCategory>> GetLinkCategoriesWithLinks()
    {
        var spec = new LinkCategoriesWithLinksSpecification();
        var linkCategories = await GetAsync(spec);
        return linkCategories;
    }
}
