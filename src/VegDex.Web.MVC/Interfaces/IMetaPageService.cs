namespace VegDex.Web.MVC.Interfaces;

public interface IMetaPageService
{
    Task<string> GetAboutPage();
    Task<string> GetHomePage();
    Task UpdateAboutPage(string content);
    Task UpdateHomePage(string content);
}
