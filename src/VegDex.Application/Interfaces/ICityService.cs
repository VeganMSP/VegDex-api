namespace VegDex.Application.Interfaces;

public interface ICityService
{
    Task<CityModel> Create(CityModel city);
    Task Delete(CityModel city);
    Task<CityModel> GetCityById(int cityId);
    Task<IEnumerable<CityModel>> GetCities();
    Task Update(CityModel city);
    Task<CityModel> GetCityByName(string cityName);
    Task<IEnumerable<CityModel>> GetCitiesWithRestaurants();
}
