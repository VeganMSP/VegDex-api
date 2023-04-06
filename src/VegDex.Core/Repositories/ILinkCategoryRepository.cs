using VegDex.Core.Entities;
using VegDex.Core.Repositories.Base;

namespace VegDex.Core.Repositories;

public interface ILinkCategoryRepository : IRepository<LinkCategory>
{
    Task<IEnumerable<LinkCategory>> GetLinkCategoriesWithLinks();
    Task<IEnumerable<LinkCategory>> GetLinkCategories();
    Task<LinkCategory> GetLinkCategoryWithLinksById(int id);
}
