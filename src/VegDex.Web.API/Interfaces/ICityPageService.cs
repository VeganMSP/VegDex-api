using VegDex.Application.Models;
using VegDex.Web.API.ViewModels;

namespace VegDex.Web.API.Interfaces;

public interface ICityPageService
{
    Task<CityModel> CreateCity(CityModel cityModel);
    Task DeleteCity(CityModel cityModel);
    Task<IEnumerable<CityViewModel>> GetCities();
    Task<CityModel> GetCityById(int? id);
    Task<IEnumerable<RestaurantModel>> GetRestaurantsInCityById(int id);
    Task UpdateCity(CityModel cityModel);
}
