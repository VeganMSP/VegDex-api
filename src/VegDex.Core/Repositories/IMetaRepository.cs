namespace VegDex.Core.Repositories;

public interface IMetaRepository
{
    Task<string> GetAboutPage();
    Task<string> GetHomePage();
    Task UpdateAboutPageAsync(string content);
    Task UpdateHomePageAsync(string content);
}
