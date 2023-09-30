using System.Reflection;
using AutoMapper;
using Serilog;
using VegDex.Application.Interfaces;
using VegDex.Application.Models;
using VegDex.Core.Utilities;
using VegDex.Web.API.Interfaces;
using VegDex.Web.API.ViewModels;

namespace VegDex.Web.API.Services;

public class LinksPageService : ILinksPageService
{
    private readonly ILinkService _linkAppService;
    private readonly ILinkCategoryService _linkCategoryAppService;
    private readonly ILogger _logger = Log.ForContext<LinksPageService>();
    private readonly IMapper _mapper;
    public LinksPageService(ILinkService linkAppService, ILinkCategoryService linkCategoryAppService, IMapper mapper)
    {
        _linkAppService = linkAppService ?? throw new ArgumentNullException(nameof(linkAppService));
        _linkCategoryAppService =
            linkCategoryAppService ?? throw new ArgumentNullException(nameof(linkCategoryAppService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    /// <inheritdoc/>
    public async Task<IEnumerable<LinkViewModel>> GetLinks() => await GetLinks(null!);
    /// <inheritdoc/>
    public async Task<IEnumerable<LinkCategoryViewModel>> GetLinkCategoriesWithLinks()
    {
        var linkCategoriesWithLinks = await _linkCategoryAppService.GetLinkCategoriesWithLinks();
        var mapped = _mapper.Map<IEnumerable<LinkCategoryViewModel>>(linkCategoriesWithLinks);
        return mapped;
    }
    /// <inheritdoc/>
    public async Task<LinkModel> GetLinkById(int? id)
    {
        var link = await _linkAppService.GetLinkById(id);
        var mapped = _mapper.Map<LinkModel>(link);
        return mapped;
    }
    /// <inheritdoc/>
    public async Task<LinkModel> CreateLink(LinkModel link)
    {
        var mapped = _mapper.Map<LinkModel>(link);
        if (mapped == null)
            throw new Exception("Entity could not be mapped");
        mapped.Slug = mapped.Name.ToUrlSlug();
        var entityDto = await _linkAppService.Create(mapped);
        _logger.Information("Entity successfully added: {Link}", link);

        var mappedModel = _mapper.Map<LinkModel>(entityDto);
        return mappedModel;
    }
    /// <inheritdoc/>
    public async Task DeleteLink(LinkModel link)
    {
        var mapped = _mapper.Map<LinkModel>(link);
        if (mapped == null)
            throw new Exception("Entity could not be mapped");

        await _linkAppService.Delete(mapped);
        _logger.Information("Entity successfully deleted: {Link}", mapped);
    }
    /// <inheritdoc/>
    public async Task UpdateLink(LinkModel link)
    {
        var mapped = _mapper.Map<LinkModel>(link);
        if (mapped == null)
            throw new Exception("Entity could not be mapped");

        await _linkAppService.Update(mapped);
        _logger.Information("Entity successfully updated: {Restaurant}", mapped);
    }
    /// <inheritdoc/>
    public async Task<LinkCategoryModel> CreateLinkCategory(LinkCategoryModel linkCategoryModel)
    {
        var mapped = _mapper.Map<LinkCategoryModel>(linkCategoryModel);
        if (mapped == null)
            throw new Exception("Entity could not be mapped");
        mapped.Slug = mapped.Name.ToUrlSlug();
        var entityDto = await _linkCategoryAppService.Create(mapped);
        _logger.Information("Entity successfully created: {LinkCategory}", linkCategoryModel);

        var mappedModel = _mapper.Map<LinkCategoryModel>(entityDto);
        return mappedModel;
    }
    /// <inheritdoc/>
    public async Task<LinkCategoryModel> GetLinkCategoryById(int id)
    {
        var linkCategory = await _linkCategoryAppService.GetLinkCategoryById(id);
        var mapped = _mapper.Map<LinkCategoryModel>(linkCategory);
        return mapped;
    }
    /// <inheritdoc/>
    public async Task DeleteLinkCategory(LinkCategoryModel linkCategory)
    {
        var mapped = _mapper.Map<LinkCategoryModel>(linkCategory);
        if (mapped == null)
            throw new Exception("Entity could not be mapped");
        await _linkCategoryAppService.Delete(mapped);
        _logger.Information("Entity successfully deleted: {LinkCategory}", mapped);
    }
    /// <inheritdoc/>
    public async Task UpdateLinkCategory(LinkCategoryModel linkCategoryViewModel)
    {
        var mapped = _mapper.Map<LinkCategoryModel>(linkCategoryViewModel);
        if (mapped == null)
            throw new Exception("Entity could not be mapped");
        await _linkCategoryAppService.Update(mapped);
        _logger.Information("Entity successfully updated: {LinkCategory}", mapped);
    }
    /// <inheritdoc/>
    public async Task<LinkCategoryViewModel> GetLinkCategoryWithLinksById(int id)
    {
        var linkCategoryWithLinks = await _linkCategoryAppService.GetLinkCategoryWithLinksById(id);
        var mapped = _mapper.Map<LinkCategoryViewModel>(linkCategoryWithLinks);
        return mapped;
    }
    /// <inheritdoc/>
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
    /// <inheritdoc/>
    public async Task<IEnumerable<LinkCategoryViewModel>> GetLinkCategories()
    {
        var linkCategories = await _linkCategoryAppService.GetLinkCategoryList();
        var mapped = _mapper.Map<IEnumerable<LinkCategoryViewModel>>(linkCategories);
        return mapped;
    }
}
