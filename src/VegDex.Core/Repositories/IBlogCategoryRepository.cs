using VegDex.Core.Entities;

namespace VegDex.Core.Repositories;

public interface IBlogCategoryRepository
{
    Task<IEnumerable<BlogCategory>> GetBlogCategories();
}
