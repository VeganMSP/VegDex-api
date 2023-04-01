using VegDex.Core.Entities;
using VegDex.Core.Repositories.Base;

namespace VegDex.Core.Repositories;

public interface IBlogPostRepository : IRepository<BlogPost>
{
    Task<IEnumerable<BlogPost>> GetBlogPosts();
}
