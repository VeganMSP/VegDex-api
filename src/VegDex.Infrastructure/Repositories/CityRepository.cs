namespace VegDex.Infrastructure.Repositories;

public class CityRepository : Repository<City>, ICityRepository
{
    /// <inheritdoc />
    public CityRepository(VegDexContext dbContext) : base(dbContext) { }
    /// <inheritdoc />
    public async Task<IEnumerable<City>> GetCitiesWithRestaurants()
    {
        var spec = new CitiesWithRestaurantsSpecification();
        var cities = await GetAsync(spec);
        return cities;
    }
    /// <inheritdoc />
    public async Task<City> GetByNameAsync(string cityName)
    {
        var city = await _dbContext.Set<City>()
            .Where(c => c.Name == cityName)
            .FirstAsync();
        return city;
    }
}
