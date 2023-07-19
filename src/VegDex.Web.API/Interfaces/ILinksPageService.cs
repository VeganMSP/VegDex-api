using VegDex.Application.Models;
using VegDex.Web.API.ViewModels;

namespace VegDex.Web.API.Interfaces;

public interface ILinksPageService
{
    Task<LinkModel> CreateLink(LinkModel link);
    Task<LinkCategoryModel> CreateLinkCategory(LinkCategoryModel linkCategoryModel);
    Task DeleteLink(LinkModel link);
    Task DeleteLinkCategory(LinkCategoryModel linkCategoryModel);
    Task<LinkModel> GetLinkById(int? id);
    Task<IEnumerable<LinkCategoryViewModel>> GetLinkCategories();
    Task<IEnumerable<LinkCategoryViewModel>> GetLinkCategoriesWithLinks();
    Task<LinkCategoryModel> GetLinkCategoryById(int id);
    Task<LinkCategoryViewModel> GetLinkCategoryWithLinksById(int id);
    Task<IEnumerable<LinkViewModel>> GetLinks(string linkName);
    Task<IEnumerable<LinkViewModel>> GetLinks();
    Task UpdateLink(LinkModel link);
    Task UpdateLinkCategory(LinkCategoryModel linkCategoryModel);
}
