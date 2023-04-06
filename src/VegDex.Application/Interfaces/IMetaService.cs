namespace VegDex.Application.Interfaces;

public interface IMetaService
{
    Task<string> GetAboutPage();
    Task<string> GetHomePage();
    Task UpdateAboutPage(string content);
    Task UpdateHomePage(string content);
}
