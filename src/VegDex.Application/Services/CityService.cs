using Serilog;
using VegDex.Application.Interfaces;
using VegDex.Application.Mapper;
using VegDex.Application.Models;
using VegDex.Core.Repositories;

namespace VegDex.Application.Services;

public class CityService : ICityService
{
    private static readonly ILogger _logger = Log.ForContext<CityService>();
    private ICityRepository _cityRepository;
    public CityService(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }
    /// <inheritdoc />
    public async Task<IEnumerable<CityModel>> GetCities()
    {
        var cities = await _cityRepository.GetAllAsync();
        var mapped = ObjectMapper.Mapper.Map<IEnumerable<CityModel>>(cities);
        return mapped;
    }
    /// <inheritdoc />
    public async Task<CityModel> GetCityById(int cityId)
    {
        var city = await _cityRepository.GetByIdAsync(cityId);
        var mapped = ObjectMapper.Mapper.Map<CityModel>(city);
        return mapped;
    }
    /// <inheritdoc />
    public async Task<CityModel> Create(CityModel city) => throw new NotImplementedException();
    /// <inheritdoc />
    public async Task Update(CityModel city) => throw new NotImplementedException();
    /// <inheritdoc />
    public async Task<CityModel> GetCityByName(string cityName)
    {
        var city = await _cityRepository.GetByNameAsync(cityName);
        var mapped = ObjectMapper.Mapper.Map<CityModel>(city);
        return mapped;
    }
    /// <inheritdoc />
    public async Task Delete(CityModel city) => throw new NotImplementedException();
    /// <inheritdoc />
    public async Task<IEnumerable<CityModel>> GetCitiesWithRestaurants()
    {
        var citiesWithRestaurants = await _cityRepository.GetCitiesWithRestaurants();
        var mapped = ObjectMapper.Mapper.Map<IEnumerable<CityModel>>(citiesWithRestaurants);
        return mapped;
    }
}
