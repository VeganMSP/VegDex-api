using Serilog;
using VegDex.Application.Interfaces;
using VegDex.Application.Mapper;
using VegDex.Application.Models;
using VegDex.Core.Entities;
using VegDex.Core.Repositories;

namespace VegDex.Application.Services;

public class RestaurantService : IRestaurantService
{
    private static readonly ILogger _logger = Log.ForContext<RestaurantService>();
    private readonly IRestaurantRepository _restaurantRepository;
    public RestaurantService(IRestaurantRepository restaurantRepository)
    {
        _restaurantRepository = restaurantRepository;
    }
    /// <inheritdoc />
    public async Task<IEnumerable<RestaurantModel>> GetRestaurantList()
    {
        var restaurantList = await _restaurantRepository.GetRestaurantListAsync();
        var mapped = ObjectMapper.Mapper.Map<IEnumerable<RestaurantModel>>(restaurantList);
        return mapped;
    }
    /// <inheritdoc />
    public async Task<RestaurantModel> GetRestaurantById(int restaurantId)
    {
        var restaurant = await _restaurantRepository.GetByIdAsync(restaurantId);
        var mapped = ObjectMapper.Mapper.Map<RestaurantModel>(restaurant);
        return mapped;
    }
    /// <inheritdoc />
    public Task<IEnumerable<RestaurantModel>> GetRestaurantByLocation(int locationId) =>
        throw new NotImplementedException();
    /// <inheritdoc />
    public async Task<RestaurantModel> Create(RestaurantModel restaurantModel)
    {
        await ValidateRestaurantIfExist(restaurantModel);

        var mappedEntity = ObjectMapper.Mapper.Map<Restaurant>(restaurantModel);
        if (mappedEntity == null)
            throw new ApplicationException($"Entity could not be mapped.");

        var newEntity = await _restaurantRepository.AddAsync(mappedEntity);
        _logger.Information($"Entity successfully added");

        var newMappedEntity = ObjectMapper.Mapper.Map<RestaurantModel>(newEntity);
        return newMappedEntity;
    }
    /// <inheritdoc />
    public async Task Update(RestaurantModel restaurantModel)
    {
        ValidateRestaurantIfNotExist(restaurantModel);

        var editRestaurant = await _restaurantRepository.GetByIdAsync(restaurantModel.Id);
        if (editRestaurant == null)
            throw new ApplicationException($"Entity could not be loaded.");

        ObjectMapper.Mapper.Map<RestaurantModel, Restaurant>(restaurantModel, editRestaurant);

        await _restaurantRepository.UpdateAsync(editRestaurant);
        _logger.Information($"Entity successfully updated");
    }
    /// <inheritdoc />
    public async Task Delete(RestaurantModel restaurantModel)
    {
        ValidateRestaurantIfNotExist(restaurantModel);
        var deletedRestaurant = await _restaurantRepository.GetByIdAsync(restaurantModel.Id);
        if (deletedRestaurant == null)
            throw new ApplicationException($"Entity could not be loaded.");

        await _restaurantRepository.DeleteAsync(deletedRestaurant);
        _logger.Information($"Entity successfully deleted");
    }
    /// <inheritdoc />
    public async Task<RestaurantModel> GetRestaurantByName(string? restaurantName)
    {
        var restaurantList = await _restaurantRepository.GetRestaurantByNameAsync(restaurantName);
        var mapped = ObjectMapper.Mapper.Map<RestaurantModel>(restaurantList);
        return mapped;
    }
    async private Task ValidateRestaurantIfExist(RestaurantModel restaurantModel)
    {
        var existingEntity = await _restaurantRepository.GetByIdAsync(restaurantModel.Id);
        if (existingEntity != null)
            throw new ApplicationException($"{restaurantModel.ToString()} with this id already exists");
    }
    private void ValidateRestaurantIfNotExist(RestaurantModel restaurantModel)
    {
        var existingEntity = _restaurantRepository.GetByIdAsync(restaurantModel.Id);
        if (existingEntity == null)
            throw new ApplicationException($"{restaurantModel.ToString()} with this id is not exists");
    }
}
