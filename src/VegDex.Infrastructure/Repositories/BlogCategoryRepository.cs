namespace VegDex.Infrastructure.Repositories;

public class BlogCategoryRepository : Repository<BlogCategory>, IBlogCategoryRepository
{
    private static VegDexContext _dbContext;
    /// <inheritdoc />
    public BlogCategoryRepository(VegDexContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    /// <inheritdoc />
    public async Task<IEnumerable<BlogCategory>> GetBlogCategories()
    {
        var categories = await _dbContext.Set<BlogCategory>()
            .ToListAsync();
        return categories;
    }
}
