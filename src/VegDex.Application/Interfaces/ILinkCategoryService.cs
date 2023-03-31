using VegDex.Application.Models;

namespace VegDex.Application.Interfaces;

public interface ILinkCategoryService
{
    Task<IEnumerable<LinkCategoryModel>> GetLinkCategoryList();
    Task<LinkCategoryModel> GetLinkCategoryById(int linkCategoryId);
    Task<LinkCategoryModel> Create(LinkCategoryModel linkCategory);
    Task Update(LinkCategoryModel linkCategory);
    Task Delete(LinkCategoryModel linkCategory);
}
