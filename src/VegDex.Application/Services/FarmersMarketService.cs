namespace VegDex.Application.Services;

public class FarmersMarketService : IFarmersMarketService
{
    private static readonly ILogger _logger = Log.ForContext<FarmersMarketService>();
    private IFarmersMarketRepository _farmersMarketRepository;
    public FarmersMarketService(IFarmersMarketRepository farmersMarketRepository)
    {
        _farmersMarketRepository = farmersMarketRepository;
    }
    /// <inheritdoc/>
    public async Task<IEnumerable<FarmersMarketModel>> GetFarmersMarkets()
    {
        var veganCompanies = await _farmersMarketRepository.GetFarmersMarkets();
        var mapped = ObjectMapper.Mapper.Map<IEnumerable<FarmersMarketModel>>(veganCompanies);
        return mapped;
    }
    /// <inheritdoc/>
    public async Task<FarmersMarketModel> GetFarmersMarketById(int farmersMarketId)
    {
        var farmersMarket = await _farmersMarketRepository.GetByIdAsync(farmersMarketId);
        var mapped = ObjectMapper.Mapper.Map<FarmersMarketModel>(farmersMarket);
        return mapped;
    }
    /// <inheritdoc/>
    public async Task<FarmersMarketModel> Create(FarmersMarketModel farmersMarketModel)
    {
        await ValidateFarmersMarketIfExist(farmersMarketModel);
        var mappedEntity = ObjectMapper.Mapper.Map<FarmersMarket>(farmersMarketModel);
        if (mappedEntity == null)
            throw new ApplicationException("Entity could not be mapped");
        var newEntity = await _farmersMarketRepository.AddAsync(mappedEntity);
        _logger.Information("Entity successfully added: {@FarmersMarket}", newEntity);

        var newMappedEntity = ObjectMapper.Mapper.Map<FarmersMarketModel>(newEntity);
        return newMappedEntity;
    }
    /// <inheritdoc/>
    public async Task Update(FarmersMarketModel farmersMarketModel)
    {
        ValidateFarmersMarketIfNotExist(farmersMarketModel);
        var editFarmersMarket = await _farmersMarketRepository.GetByIdAsync(farmersMarketModel.Id);
        if (editFarmersMarket == null)
            throw new ApplicationException("Entity could not be loaded");
        ObjectMapper.Mapper.Map(farmersMarketModel, editFarmersMarket);
        await _farmersMarketRepository.UpdateAsync(editFarmersMarket);
        _logger.Information("Entity successfully updated");
    }
    /// <inheritdoc/>
    public async Task Delete(FarmersMarketModel farmersMarketModel)
    {
        ValidateFarmersMarketIfNotExist(farmersMarketModel);
        var deletedFarmersMarket = await _farmersMarketRepository.GetByIdAsync(farmersMarketModel.Id);
        if (deletedFarmersMarket == null)
            throw new ApplicationException("Entity could not be loaded");
        await _farmersMarketRepository.DeleteAsync(deletedFarmersMarket);
        _logger.Information("Entity successfully deleted");
    }
    async private Task ValidateFarmersMarketIfExist(FarmersMarketModel farmersMarket)
    {
        var existingEntity = await _farmersMarketRepository.GetByIdAsync(farmersMarket.Id);
        if (existingEntity != null)
            throw new ApplicationException($"{farmersMarket} with this Id exists already");
    }
    private void ValidateFarmersMarketIfNotExist(FarmersMarketModel farmersMarketModel)
    {
        var existingEntity = _farmersMarketRepository.GetByIdAsync(farmersMarketModel.Id);
        if (existingEntity == null)
            throw new ApplicationException($"{farmersMarketModel} with this Id does not exist");
    }
}
