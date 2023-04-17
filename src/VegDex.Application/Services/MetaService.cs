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
    public async Task UpdateHomePage(string content)
    {
        var page = await _metaRepository.GetHomePage();
        if (page == null)
            throw new ApplicationException("Entity could not be loaded.");
        page.Content = content;
        await _metaRepository.UpdatePageAsync(page);
        _logger.Information("Entity successfully updated");
    }
    /// <inheritdoc />
    public async Task UpdateAboutPage(string content)
    {
        var page = await _metaRepository.GetAboutPage();
        if (page == null)
            throw new ApplicationException("Entity could not be loaded.");
        page.Content = content;
        await _metaRepository.UpdatePageAsync(page);
        _logger.Information("Entity successfully updated");
    }
}
