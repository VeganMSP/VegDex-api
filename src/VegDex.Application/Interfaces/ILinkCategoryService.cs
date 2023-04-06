using VegDex.Application.Models;

namespace VegDex.Application.Interfaces;

public interface ILinkCategoryService
{
    Task<LinkCategoryModel> Create(LinkCategoryModel linkCategory);
    Task Delete(LinkCategoryModel linkCategory);
    Task<IEnumerable<LinkCategoryModel>> GetLinkCategoriesWithLinks();
    Task<LinkCategoryModel> GetLinkCategoryById(int linkCategoryId);
    Task<IEnumerable<LinkCategoryModel>> GetLinkCategoryList();
    Task<LinkCategoryModel> GetLinkCategoryWithLinksById(int id);
    Task Update(LinkCategoryModel linkCategory);
}
