using Serilog;
using VegDex.Application.Interfaces;
using VegDex.Application.Mapper;
using VegDex.Application.Models;
using VegDex.Core.Repositories;

namespace VegDex.Application.Services;

public class LinkCategoryService : ILinkCategoryService
{
    private static readonly ILogger _logger = Log.ForContext<LinkCategoryService>();
    private ILinkCategoryRepository _linkCategoryRepository;
    public LinkCategoryService(ILinkCategoryRepository linkCategoryRepository)
    {
        _linkCategoryRepository = linkCategoryRepository;
    }
    /// <inheritdoc />
    public async Task<IEnumerable<LinkCategoryModel>> GetLinkCategoryList()
    {
        var linkCategories = await _linkCategoryRepository.GetLinkCategories();
        var mapped = ObjectMapper.Mapper.Map<IEnumerable<LinkCategoryModel>>(linkCategories);
        return mapped;
    }
    /// <inheritdoc />
    public Task<LinkCategoryModel> GetLinkCategoryById(int linkCategoryId) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task<LinkCategoryModel> Create(LinkCategoryModel linkCategory) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task Update(LinkCategoryModel linkCategory) => throw new NotImplementedException();
    /// <inheritdoc />
    public Task Delete(LinkCategoryModel linkCategory) => throw new NotImplementedException();
    /// <inheritdoc />
    public async Task<IEnumerable<LinkCategoryModel>> GetLinkCategoriesWithLinks()
    {
        var linkCategoriesWithLinks = await _linkCategoryRepository.GetLinkCategoriesWithLinks();
        var mapped = ObjectMapper.Mapper.Map<IEnumerable<LinkCategoryModel>>(linkCategoriesWithLinks);
        return mapped;
    }
}
