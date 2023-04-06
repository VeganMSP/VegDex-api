using VegDex.Application.Models;
using VegDex.Web.MVC.ViewModels;

namespace VegDex.Web.MVC.Interfaces;

public interface ILinksPageService
{
    Task<IEnumerable<LinkViewModel>> GetLinks(string linkName);
    Task<IEnumerable<LinkViewModel>> GetLinks();
    Task<IEnumerable<LinkCategoryViewModel>> GetLinkCategoriesWithLinks();
    Task<LinkModel> GetLinkById(int? id);
    Task<IEnumerable<LinkCategoryViewModel>> GetLinkCategories();
    Task<LinkModel> CreateLink(LinkModel link);
    Task DeleteLink(LinkModel link);
    Task UpdateLink(LinkModel link);
    Task<LinkCategoryModel> CreateLinkCategory(LinkCategoryModel linkCategoryModel);
    Task<LinkCategoryModel> GetLinkCategoryById(int id);
    Task DeleteLinkCategory(LinkCategoryModel linkCategoryModel);
    Task UpdateLinkCategory(LinkCategoryModel linkCategoryModel);
    Task<LinkCategoryViewModel> GetLinkCategoryWithLinksById(int id);
}
