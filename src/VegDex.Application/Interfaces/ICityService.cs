using VegDex.Application.Models;

namespace VegDex.Application.Interfaces;

public interface ICityService
{
    Task<IEnumerable<CityModel>> GetCityList();
    Task<CityModel> GetCityById(int cityId);
    Task<CityModel> Create(CityModel city);
    Task Update(CityModel city);
    Task Delete(CityModel city);
}
