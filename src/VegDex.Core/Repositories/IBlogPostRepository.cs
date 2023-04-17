namespace VegDex.Core.Repositories;

public interface IBlogPostRepository : IRepository<BlogPost>
{
    Task<IEnumerable<BlogPost>> GetBlogPosts();
}
