using AutoMapper;
using VegDex.Application.Interfaces;
using VegDex.Web.API.Interfaces;
using VegDex.Web.API.ViewModels.Meta;

namespace VegDex.Web.API.Services;

public class MetaPageService : IMetaPageService
{
    private readonly IMapper _mapper;
    private readonly IMetaService _metaAppService;
    public MetaPageService(IMetaService metaAppService, IMapper mapper)
    {
        _mapper = mapper;
        _metaAppService = metaAppService ?? throw new ArgumentNullException(nameof(metaAppService));
    }
    /// <inheritdoc />
    public async Task<AboutPageViewModel> GetAboutPage()
    {
        var page = await _metaAppService.GetAboutPage();
        var mapped = _mapper.Map<AboutPageViewModel>(page);
        return mapped;
    }
    /// <inheritdoc />
    public async Task<HomePageViewModel> GetHomePage()
    {
        var page = await _metaAppService.GetHomePage();
        var mapped = _mapper.Map<HomePageViewModel>(page);
        return mapped;
    }
    /// <inheritdoc />
    public async Task UpdateAboutPage(string content) => await _metaAppService.UpdateAboutPage(content);
    /// <inheritdoc />
    public async Task UpdateHomePage(string content) => await _metaAppService.UpdateHomePage(content);
}
