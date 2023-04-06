using VegDex.Application.Models;

namespace VegDex.Application.Interfaces;

public interface ICityService
{
    Task<CityModel> Create(CityModel city);
    Task Delete(CityModel city);
    Task<IEnumerable<CityModel>> GetCitiesWithRestaurants();
    Task<CityModel> GetCityById(int cityId);
    Task<IEnumerable<CityModel>> GetCityList();
    Task Update(CityModel city);
}
