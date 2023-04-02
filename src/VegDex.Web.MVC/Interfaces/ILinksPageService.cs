using System.Collections;
using VegDex.Application.Models;
using VegDex.Web.MVC.ViewModels;

namespace VegDex.Web.MVC.Interfaces;

public interface ILinksPageService
{
    Task<IEnumerable<LinkViewModel>> GetLinks(string linkName);
    Task<IEnumerable<LinkViewModel>> GetLinks();
    Task<IEnumerable<LinkCategoryViewModel>> GetLinkCategoriesWithLinks();
    Task<LinkModel> GetLinkById(int? id);
    Task<IEnumerable<LinkCategoryModel>> GetLinkCategories();
    Task<LinkModel> CreateLink(LinkModel link);
    Task DeleteLink(LinkModel link);
    Task UpdateLink(LinkModel link);
}
