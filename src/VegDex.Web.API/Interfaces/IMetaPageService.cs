using VegDex.Web.API.ViewModels.Meta;

namespace VegDex.Web.API.Interfaces;

public interface IMetaPageService
{
    Task<AboutPageViewModel> GetAboutPage();
    Task<HomePageViewModel> GetHomePage();
    Task UpdateAboutPage(string content);
    Task UpdateHomePage(string content);
}
