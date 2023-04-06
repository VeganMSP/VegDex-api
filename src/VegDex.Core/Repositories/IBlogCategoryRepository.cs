using VegDex.Core.Entities;
using VegDex.Core.Repositories.Base;

namespace VegDex.Core.Repositories;

public interface IBlogCategoryRepository : IRepository<BlogCategory>
{
    Task<IEnumerable<BlogCategory>> GetBlogCategories();
}
