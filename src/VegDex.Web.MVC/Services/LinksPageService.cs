using System.Reflection;
using AutoMapper;
using Serilog;
using VegDex.Application.Interfaces;
using VegDex.Web.MVC.Interfaces;
using VegDex.Web.MVC.ViewModels;
using ILogger = Serilog.ILogger;

namespace VegDex.Web.MVC.Services;

public class LinksPageService : ILinksPageService
{
    private readonly ILinkService _linkAppService;
    private readonly ILogger _logger = Log.ForContext<LinksPageService>();
    private readonly IMapper _mapper;
    public LinksPageService(ILinkService linkAppService, IMapper mapper)
    {
        _linkAppService = linkAppService ?? throw new ArgumentNullException(nameof(linkAppService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    /// <inheritdoc />
    public async Task<IEnumerable<LinkViewModel>> GetLinks() => await GetLinks(null!);
    /// <inheritdoc />
    public async Task<IEnumerable<LinkViewModel>> GetLinks(string? linkName)
    {
        if (string.IsNullOrWhiteSpace(linkName))
        {
            var list = await _linkAppService.GetLinkList();
            var mapped = _mapper.Map<IEnumerable<LinkViewModel>>(list);
            return mapped;
        }
        _logger.Debug("{Method} with term {LinksName}", MethodBase.GetCurrentMethod()?.Name, linkName);
        var listByName = await _linkAppService.GetLinkByName(linkName);
        var mappedByName = _mapper.Map<IEnumerable<LinkViewModel>>(listByName);
        return mappedByName;
    }
}
