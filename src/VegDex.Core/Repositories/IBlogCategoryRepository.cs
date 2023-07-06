namespace VegDex.Core.Repositories;

public interface IBlogCategoryRepository : IRepository<BlogCategory>
{
    Task<IEnumerable<BlogCategory>> GetBlogCategories();
}
