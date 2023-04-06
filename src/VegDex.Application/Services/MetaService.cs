using Serilog;
using VegDex.Application.Interfaces;
using VegDex.Application.Mapper;
using VegDex.Application.Models;
using VegDex.Core.Repositories;

namespace VegDex.Application.Services;

public class MetaService : IMetaService
{
    private static readonly ILogger _logger = Log.ForContext<MetaService>();
    private readonly IMetaRepository _metaRepository;
    public MetaService(IMetaRepository metaRepository)
    {
        _metaRepository = metaRepository;
    }
    /// <inheritdoc />
    public async Task<AboutPageModel> GetAboutPage()
    {
        var page = await _metaRepository.GetAboutPage();
        var mapped = ObjectMapper.Mapper.Map<AboutPageModel>(page);
        return mapped;
    }
    /// <inheritdoc />
    public async Task<HomePageModel> GetHomePage()
    {
        var page = await _metaRepository.GetHomePage();
        var mapped = ObjectMapper.Mapper.Map<HomePageModel>(page);
        return mapped;
    }
/// <inheritdoc />
    public Task UpdateAboutPage(string content) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task UpdateHomePage(string content) => throw new NotImplementedException();
}
