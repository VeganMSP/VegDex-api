using VegDex.Core.Entities;
using VegDex.Core.Repositories.Base;

namespace VegDex.Core.Repositories;

public interface ICityRepository : IRepository<City>
{
    Task<IEnumerable<City>> GetCitiesWithRestaurants();
}
