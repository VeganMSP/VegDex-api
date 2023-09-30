namespace VegDex.Core.Repositories;

public interface ICityRepository : IRepository<City>
{
    Task<City> GetByNameAsync(string cityName);
    Task<IEnumerable<City>> GetCitiesWithRestaurants();
}
