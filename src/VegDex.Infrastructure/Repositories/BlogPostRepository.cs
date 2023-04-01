using Microsoft.EntityFrameworkCore;
using VegDex.Core.Entities;
using VegDex.Core.Repositories;
using VegDex.Core.Specifications;
using VegDex.Infrastructure.Context;
using VegDex.Infrastructure.Repositories.Base;

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
