using Serilog;
using VegDex.Application.Interfaces;
using VegDex.Application.Mapper;
using VegDex.Application.Models;
using VegDex.Core;
using VegDex.Core.Entities;

namespace VegDex.Application.Services;

public class FarmersMarketService : IFarmersMarketService
{
    private static readonly ILogger _logger = Log.ForContext<FarmersMarketService>();
    private IFarmersMarketRepository _farmersMarketRepository;
    public FarmersMarketService(IFarmersMarketRepository farmersMarketRepository)
    {
        _farmersMarketRepository = farmersMarketRepository;
    }
    /// <inheritdoc />
    public async Task<IEnumerable<FarmersMarketModel>> GetFarmersMarkets()
    {
        var veganCompanies = await _farmersMarketRepository.GetFarmersMarkets();
        var mapped = ObjectMapper.Mapper.Map<IEnumerable<FarmersMarketModel>>(veganCompanies);
        return mapped;
    }
    /// <inheritdoc />
    public Task<FarmersMarketModel> GetFarmersMarketById(int restaurantId) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task<FarmersMarketModel> Create(FarmersMarketModel farmersMarket) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task Update(FarmersMarketModel farmersMarket) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task Delete(FarmersMarketModel farmersMarket) => throw new NotImplementedException();
}
