using VegDex.Application.Interfaces;
using VegDex.Application.Models;

namespace VegDex.Application.Services;

public class CityService : ICityService
{
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
}
