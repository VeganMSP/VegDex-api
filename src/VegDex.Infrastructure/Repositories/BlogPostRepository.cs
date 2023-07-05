namespace VegDex.Infrastructure.Repositories;

public class BlogPostRepository : Repository<BlogPost>, IBlogPostRepository
{
    /// <inheritdoc />
    public BlogPostRepository(VegDexContext dbContext) : base(dbContext) { }
    /// <inheritdoc />
    public async Task<IEnumerable<BlogPost>> GetBlogPosts()
    {
        var spec = new BlogPostWithCategorySpecification();
        return await GetAsync(spec);
    }
}
