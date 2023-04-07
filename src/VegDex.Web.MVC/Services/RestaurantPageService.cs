using System.Reflection;
using AutoMapper;
using Serilog;
using VegDex.Application.Interfaces;
using VegDex.Application.Models;
using VegDex.Core.Utilities;
using VegDex.Web.MVC.Interfaces;
using VegDex.Web.MVC.ViewModels;
using ILogger = Serilog.ILogger;

namespace VegDex.Web.MVC.Services;

public class RestaurantPageService : IRestaurantsPageService
{
    private readonly ICityService _cityAppService;
    private readonly ILogger _logger = Log.ForContext<RestaurantPageService>();
    private readonly IMapper _mapper;
    private readonly IRestaurantService _restaurantAppService;
    public RestaurantPageService(IRestaurantService restaurantAppService, ICityService cityAppService, IMapper mapper)
    {
        _restaurantAppService = restaurantAppService ?? throw new ArgumentNullException(nameof(restaurantAppService));
        _cityAppService = cityAppService ?? throw new ArgumentNullException(nameof(cityAppService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    /// <inheritdoc />
    public async Task<IEnumerable<RestaurantViewModel>> GetRestaurants(string? restaurantName)
    {
        if (string.IsNullOrWhiteSpace(restaurantName))
        {
            var list = await _restaurantAppService.GetRestaurantList();
            var mapped = _mapper.Map<IEnumerable<RestaurantViewModel>>(list);
            return mapped;
        }
        _logger.Debug("{Method} with term {RestaurantName}", MethodBase.GetCurrentMethod()?.Name, restaurantName);
        var listByName = await _restaurantAppService.GetRestaurantByName(restaurantName);
        var mappedByName = _mapper.Map<IEnumerable<RestaurantViewModel>>(listByName);
        return mappedByName;
    }
    /// <inheritdoc />
    public async Task<IEnumerable<CityViewModel>> GetCitiesWithRestaurants()
    {
        var citiesWithRestaurants = await _cityAppService.GetCitiesWithRestaurants();
        var mapped = _mapper.Map<IEnumerable<CityViewModel>>(citiesWithRestaurants);
        return mapped;
    }
    /// <inheritdoc />
    public async Task<IEnumerable<CityModel>> GetCities()
    {
        var list = await _cityAppService.GetCities();
        var mapped = _mapper.Map<IEnumerable<CityModel>>(list);
        return mapped;
    }
    /// <inheritdoc />
    public async Task<RestaurantModel> CreateRestaurant(RestaurantModel restaurant)
    {
        var mapped = _mapper.Map<RestaurantModel>(restaurant);
        if (mapped == null)
            throw new Exception("Entity could not be mapped");
        mapped.Slug = mapped.Name.ToUrlSlug();
        var entityDto = await _restaurantAppService.Create(mapped);
        _logger.Information("Entity successfully added: {Restaurant}", restaurant);

        var mappedModel = _mapper.Map<RestaurantModel>(entityDto);
        return mappedModel;
    }
    /// <inheritdoc />
    public async Task<RestaurantModel> GetRestaurantById(int? id)
    {
        var restaurant = await _restaurantAppService.GetRestaurantById(id);
        var mapped = _mapper.Map<RestaurantModel>(restaurant);
        return mapped;
    }
    /// <inheritdoc />
    public async Task DeleteRestaurant(RestaurantModel restaurant)
    {
        var mapped = _mapper.Map<RestaurantModel>(restaurant);
        if (mapped == null)
            throw new Exception("Entity could not be mapped");

        await _restaurantAppService.Delete(mapped);
        _logger.Information("Entity successfully deleted: {Restaurant}", mapped);
    }
    /// <inheritdoc />
    public async Task UpdateRestaurant(RestaurantModel restaurant)
    {
        var mapped = _mapper.Map<RestaurantModel>(restaurant);
        if (mapped == null)
            throw new Exception("Entity could not be mapped");

        await _restaurantAppService.Update(mapped);
        _logger.Information("Entity successfully updated: {Restaurant}", mapped);
    }
    /// <inheritdoc />
    public async Task<IEnumerable<RestaurantViewModel>> GetRestaurants() => await GetRestaurants(null!);
}
