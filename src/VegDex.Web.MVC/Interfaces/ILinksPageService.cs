using VegDex.Application.Models;
using VegDex.Web.MVC.ViewModels;

namespace VegDex.Web.MVC.Interfaces;

public interface ILinksPageService
{
    Task<LinkModel> CreateLink(LinkModel link);
    Task DeleteLink(LinkModel link);
    Task<LinkModel> GetLinkById(int? id);
    Task<IEnumerable<LinkCategoryModel>> GetLinkCategories();
    Task<IEnumerable<LinkCategoryViewModel>> GetLinkCategoriesWithLinks();
    Task<IEnumerable<LinkViewModel>> GetLinks(string linkName);
    Task<IEnumerable<LinkViewModel>> GetLinks();
    Task UpdateLink(LinkModel link);
}
