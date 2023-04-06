using VegDex.Core.Entities;
using VegDex.Core.Repositories.Base;

namespace VegDex.Core.Repositories;

public interface ILinkCategoryRepository : IRepository<LinkCategory>
{
    Task<IEnumerable<LinkCategory>> GetLinkCategories();
    Task<IEnumerable<LinkCategory>> GetLinkCategoriesWithLinks();
}
