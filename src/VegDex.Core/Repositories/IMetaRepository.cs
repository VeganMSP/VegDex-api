using VegDex.Core.Entities;

namespace VegDex.Core.Repositories;

public interface IMetaRepository
{
    Task<AboutPage> GetAboutPage();
    Task<HomePage> GetHomePage();
    Task UpdateAboutPageAsync(string content);
    Task UpdateHomePageAsync(string content);
}
