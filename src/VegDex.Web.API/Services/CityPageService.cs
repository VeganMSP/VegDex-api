using AutoMapper;
using Serilog;
using VegDex.Application.Interfaces;
using VegDex.Application.Models;
using VegDex.Core.Utilities;
using VegDex.Web.API.Interfaces;
using VegDex.Web.API.ViewModels;

namespace VegDex.Web.API.Services;

public class CityPageService : ICityPageService
{
    private readonly ICityService _cityAppService;
    private readonly ILogger _logger = Log.ForContext<CityPageService>();
    private readonly IMapper _mapper;
    private readonly IRestaurantService _restaurantAppService;
    public CityPageService(ICityService cityAppService, IRestaurantService restaurantAppService, IMapper mapper)
    {
        _cityAppService = cityAppService ?? throw new ArgumentNullException(nameof(cityAppService));
        _restaurantAppService = restaurantAppService ?? throw new ArgumentNullException(nameof(restaurantAppService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    /// <inheritdoc/>
    public async Task<IEnumerable<CityViewModel>> GetCities()
    {
        var list = await _cityAppService.GetCities();
        var mapped = _mapper.Map<IEnumerable<CityViewModel>>(list);
        return mapped;
    }
    /// <inheritdoc/>
    public async Task<CityModel> CreateCity(CityModel city)
    {
        var mapped = _mapper.Map<CityModel>(city);
        if (mapped == null)
            throw new Exception("Entity could not be mapped");
        mapped.Slug = mapped.Name.ToUrlSlug();
        var entityDto = await _cityAppService.Create(mapped);
        _logger.Information("Entity successfully added: {City}", city);

        var mappedModel = _mapper.Map<CityModel>(entityDto);
        return mappedModel;
    }
    /// <inheritdoc/>
    public async Task<CityModel> GetCityById(int? id)
    {
        var city = await _cityAppService.GetCityById(id.Value);
        var mapped = _mapper.Map<CityModel>(city);
        return mapped;
    }
    /// <inheritdoc/>
    public async Task DeleteCity(CityModel city)
    {
        var mapped = _mapper.Map<CityModel>(city);
        if (mapped == null)
            throw new Exception("Entity could not be mapped");

        await _cityAppService.Delete(mapped);
        _logger.Information("Entity successfully deleted: {City}", mapped);
    }
    /// <inheritdoc/>
    public async Task UpdateCity(CityModel cityModel)
    {
        var mapped = _mapper.Map<CityModel>(cityModel);
        if (mapped == null)
            throw new Exception("Entity could not be mapped");

        await _cityAppService.Update(mapped);
        _logger.Information("Entity successfully updated: {City}", mapped);
    }
    /// <inheritdoc/>
    public async Task<IEnumerable<RestaurantModel>> GetRestaurantsInCityById(int id)
    {
        var restaurants = await _restaurantAppService.GetRestaurantsByLocation(id);
        var mapped = _mapper.Map<IEnumerable<RestaurantModel>>(restaurants);
        return mapped;
    }
}
