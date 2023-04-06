using System.Reflection;
using AutoMapper;
using Serilog;
using VegDex.Application.Interfaces;
using VegDex.Application.Models;
using VegDex.Core.Utilities;
using VegDex.Web.MVC.Interfaces;
using VegDex.Web.MVC.ViewModels;
using ILogger = Serilog.ILogger;

namespace VegDex.Web.MVC.Services;

public class MetaPageService : IMetaPageService
{
    private readonly ILogger _logger = Log.ForContext<LinksPageService>();
    private readonly IMetaService _metaAppService;
    public MetaPageService(IMetaService metaAppService)
    {
        _metaAppService = metaAppService ?? throw new ArgumentNullException(nameof(metaAppService));
    }
    /// <inheritdoc />
    public async Task<string> GetAboutPage() => await _metaAppService.GetAboutPage();
    /// <inheritdoc />
    public async Task<string> GetHomePage() => await _metaAppService.GetHomePage();
    /// <inheritdoc />
    public async Task UpdateAboutPage(string content) => await _metaAppService.UpdateAboutPage(content);
    /// <inheritdoc />
    public async Task UpdateHomePage(string content) => await _metaAppService.UpdateHomePage(content);
}
