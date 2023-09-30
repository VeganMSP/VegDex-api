namespace VegDex.Application.Services;

public class CityService : ICityService
{
    private static readonly ILogger _logger = Log.ForContext<CityService>();
    private ICityRepository _cityRepository;
    public CityService(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }
    /// <inheritdoc/>
    public async Task<IEnumerable<CityModel>> GetCities()
    {
        var cities = await _cityRepository.GetAllAsync();
        var mapped = ObjectMapper.Mapper.Map<IEnumerable<CityModel>>(cities);
        return mapped;
    }
    /// <inheritdoc/>
    public async Task<CityModel> GetCityById(int cityId)
    {
        var city = await _cityRepository.GetByIdAsync(cityId);
        var mapped = ObjectMapper.Mapper.Map<CityModel>(city);
        return mapped;
    }
    /// <inheritdoc/>
    public async Task<CityModel> Create(CityModel cityModel)
    {
        await ValidateCityIfExist(cityModel);

        var mappedEntity = ObjectMapper.Mapper.Map<City>(cityModel);
        if (mappedEntity == null)
            throw new ApplicationException("Entity could not be mapped");

        var newEntity = await _cityRepository.AddAsync(mappedEntity);
        _logger.Information("Entity successfully added: {@City}", newEntity);

        var newMappedEntity = ObjectMapper.Mapper.Map<CityModel>(newEntity);
        return newMappedEntity;
    }
    /// <inheritdoc/>
    public async Task Update(CityModel cityModel)
    {
        ValidateCityIfNotExist(cityModel);
        var editCity = await _cityRepository.GetByIdAsync(cityModel.Id);
        if (editCity == null)
            throw new ApplicationException("Entity could not be loaded.");
        ObjectMapper.Mapper.Map(cityModel, editCity);
        await _cityRepository.UpdateAsync(editCity);
        _logger.Information("Entity successfully updated");
    }
    /// <inheritdoc/>
    public async Task<CityModel> GetCityByName(string cityName)
    {
        var city = await _cityRepository.GetByNameAsync(cityName);
        var mapped = ObjectMapper.Mapper.Map<CityModel>(city);
        return mapped;
    }
    /// <inheritdoc/>
    public async Task Delete(CityModel cityModel)
    {
        ValidateCityIfNotExist(cityModel);
        var deletedCity = await _cityRepository.GetByIdAsync(cityModel.Id);
        if (deletedCity == null)
            throw new ApplicationException("Entity could not be loaded.");
        await _cityRepository.DeleteAsync(deletedCity);
        _logger.Information("Entity successfully deleted");
    }
    /// <inheritdoc/>
    public async Task<IEnumerable<CityModel>> GetCitiesWithRestaurants()
    {
        var citiesWithRestaurants = await _cityRepository.GetCitiesWithRestaurants();
        var mapped = ObjectMapper.Mapper.Map<IEnumerable<CityModel>>(citiesWithRestaurants);
        return mapped;
    }
    async private Task ValidateCityIfExist(CityModel cityModel)
    {
        var existingEntity = await _cityRepository.GetByIdAsync(cityModel.Id);
        if (existingEntity != null)
            throw new ApplicationException($"{cityModel} with this Id exists already");
    }
    private void ValidateCityIfNotExist(CityModel cityModel)
    {
        var existingEntity = _cityRepository.GetByIdAsync(cityModel.Id);
        if (existingEntity == null)
            throw new ApplicationException($"{cityModel} with this Id does not exist");
    }
}
