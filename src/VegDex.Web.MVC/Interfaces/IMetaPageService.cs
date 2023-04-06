using VegDex.Web.MVC.ViewModels.Meta;

namespace VegDex.Web.MVC.Interfaces;

public interface IMetaPageService
{
    Task<AboutPageViewModel> GetAboutPage();
    Task<HomePageViewModel> GetHomePage();
    Task UpdateAboutPage(string content);
    Task UpdateHomePage(string content);
}
