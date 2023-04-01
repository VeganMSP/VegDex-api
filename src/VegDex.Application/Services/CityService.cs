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
    public Task<IEnumerable<CityModel>> GetCityList() => throw new NotImplementedException();
    /// <inheritdoc />
    public Task<CityModel> GetCityById(int cityId) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task<CityModel> Create(CityModel city) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task Update(CityModel city) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task Delete(CityModel city) => throw new NotImplementedException();
    /// <inheritdoc />
    public async Task<IEnumerable<CityModel>> GetCitiesWithRestaurants()
    {
        var citiesWithRestaurants = await _cityRepository.GetCitiesWithRestaurants();
        var mapped = ObjectMapper.Mapper.Map<IEnumerable<CityModel>>(citiesWithRestaurants);
        return mapped;
    }
}
