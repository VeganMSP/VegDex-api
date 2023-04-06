using VegDex.Core.Entities;

namespace VegDex.Core.Repositories;

public interface IMetaRepository
{
    Task<AboutPage> GetAboutPage();
    Task<HomePage> GetHomePage();
    Task UpdatePageAsync(dynamic page);
}
