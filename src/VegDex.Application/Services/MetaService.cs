using Serilog;
using VegDex.Application.Interfaces;
using VegDex.Application.Mapper;
using VegDex.Application.Models;
using VegDex.Core.Entities;
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
    public async Task<string> GetAboutPage() => await _metaRepository.GetAboutPage();
    /// <inheritdoc />
    public async Task<string> GetHomePage() => await _metaRepository.GetHomePage();
    /// <inheritdoc />
    public Task UpdateAboutPage(string content) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task UpdateHomePage(string content) => throw new NotImplementedException();
}
