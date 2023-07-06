namespace VegDex.Core.Repositories;

public interface ILinkCategoryRepository : IRepository<LinkCategory>
{
    Task<IEnumerable<LinkCategory>> GetLinkCategories();
    Task<IEnumerable<LinkCategory>> GetLinkCategoriesWithLinks();
    Task<LinkCategory> GetLinkCategoryWithLinksById(int id);
}
