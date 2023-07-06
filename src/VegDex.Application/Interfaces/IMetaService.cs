namespace VegDex.Application.Interfaces;

public interface IMetaService
{
    Task<AboutPageModel> GetAboutPage();
    Task<HomePageModel> GetHomePage();
    Task UpdateAboutPage(string content);
    Task UpdateHomePage(string content);
}
