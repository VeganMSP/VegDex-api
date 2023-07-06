namespace VegDex.Core.Repositories;

public interface ICityRepository : IRepository<City>
{
    Task<IEnumerable<City>> GetCitiesWithRestaurants();
    Task<City> GetByNameAsync(string cityName);
}
