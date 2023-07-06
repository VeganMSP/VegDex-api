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
    /// <inheritdoc />
    public async Task<IEnumerable<LinkCategory>> GetLinkCategories()
    {
        var linkCategories = await _dbContext.Set<LinkCategory>()
            .ToListAsync();
        return linkCategories;
    }
    /// <inheritdoc />
    public async Task<LinkCategory> GetLinkCategoryWithLinksById(int id)
    {
        var spec = new LinkCategoryWithLinksByIdSpecification(id);
        var linkCategory = await GetAsync(spec);
        return linkCategory.First();
    }
}
