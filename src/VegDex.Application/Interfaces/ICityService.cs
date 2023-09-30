namespace VegDex.Application.Interfaces;

public interface ICityService
{
    Task<CityModel> Create(CityModel city);
    Task Delete(CityModel city);
    Task<IEnumerable<CityModel>> GetCities();
    Task<IEnumerable<CityModel>> GetCitiesWithRestaurants();
    Task<CityModel> GetCityById(int cityId);
    Task<CityModel> GetCityByName(string cityName);
    Task Update(CityModel city);
}
