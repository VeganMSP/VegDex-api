using VegDex.Application.Models;
using VegDex.Web.MVC.ViewModels;

namespace VegDex.Web.MVC.Interfaces;

public interface ICityPageService
{
    Task<CityModel> CreateCity(CityModel cityModel);
    Task DeleteCity(CityModel cityModel);
    Task<IEnumerable<CityViewModel>> GetCities();
    Task<CityModel> GetCityById(int? id);
    Task UpdateCity(CityModel cityModel);
    Task<IEnumerable<RestaurantModel>> GetRestaurantsInCityById(int id);
}
